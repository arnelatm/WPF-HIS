using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Controls;
using System.Windows; // keep this if you use Application.Current
using System.Windows.Threading; // <-- FIX: Correct namespace for Dispatcher

namespace AATM.UI.Controls
{
    public partial class SmartComboBox
    {
        // Paging logic only. All fields are defined in SmartComboBox.Core.cs
        private Task _localBackgroundFillTask; // background fill for local mode

        private async Task AppendPageAsync(int pageIndex, CancellationToken token = default)
        {
            if (token.IsCancellationRequested) return;
            var filterIsBlank = string.IsNullOrEmpty(_lastFilter?.Trim());
            var safeFilter = (_lastFilter ?? string.Empty).Trim();
            if (safeFilter.Length < MinSearchLength && !(ShowAllOnBlank && filterIsBlank) && !(LoadAllOnBlank && filterIsBlank))
            {
                HasNextPage = false;
                return;
            }
            if (pageIndex > 0) _forceFirstSelectionOnLoad = false;

            bool remote = IsRemoteConfigured && (UseRemoteFetch || _localMaster.Count == 0 || _localMaster.Count > AutoRemoteThreshold);
            int pageSize = EffectivePageSize;

            if (remote)
            {
                bool showBusy = pageIndex == 0; // only show busy spinner for first page
                try
                {
                    if (showBusy)
                        await Application.Current.Dispatcher.InvokeAsync(() => IsBusy = true);

                    List<ComboRecord> pageData;
                    try
                    {
                        pageData = await FetchRemoteRecordsAsync(safeFilter, token, pageIndex, pageSize).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        if (showBusy)
                            await Application.Current.Dispatcher.InvokeAsync(() => ClearError());
                        return;
                    }
                    if (token.IsCancellationRequested) return;

                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        _pageCache[pageIndex] = pageData;
                        EvictCacheIfNeeded();
                        RecalculateHasNextRemote(pageIndex, pageData.Count, pageSize);
                        bool appendMode = _pagingDown && pageIndex > 0;
                        if (appendMode) _appendInsertIndex = _currentItems.Count;
                        AppendToCurrent(pageData, append: appendMode);
                    });
                }
                catch (Exception ex)
                {
                    await Application.Current.Dispatcher.InvokeAsync(() => SetError($"Error fetching data: {ex.Message}"));
                }
                finally
                {
                    if (showBusy)
                        await Application.Current.Dispatcher.InvokeAsync(() => IsBusy = false);
                }
            }
            else
            {
                var filterSnapshot = safeFilter;
                var indexSnapshot = pageIndex;
                bool showBusy = pageIndex == 0;
                if (showBusy) IsBusy = true;

                if (UseBackgroundFiltering)
                {
                    await Task.Run(() =>
                    {
                        var skip = indexSnapshot * pageSize;
                        return FilterEngine.FilterPage(_localMaster, filterSnapshot, skip, pageSize);
                    }).ContinueWith(t =>
                    {
                        try
                        {
                            if (token.IsCancellationRequested || filterSnapshot != (_lastFilter ?? string.Empty).Trim()) return;
                            _totalFilteredCount = t.Result.Total;
                            TotalCount = _totalFilteredCount;
                            var pageDataLocal = t.Result.Page;
                            _pageCache[indexSnapshot] = pageDataLocal;
                            _pageCache[-1] = new List<ComboRecord>();
                            EvictCacheIfNeeded();
                            UpdateHasNextLocal(indexSnapshot, pageDataLocal.Count, pageSize, _totalFilteredCount);
                            bool appendMode = _pagingDown && indexSnapshot > 0;
                            if (appendMode) _appendInsertIndex = _currentItems.Count;
                            AppendToCurrent(pageDataLocal, append: appendMode);

                            // Kick off background fill of remaining pages for local mode if enabled and first page
                            if ((AutoBackgroundFill || (LoadAllOnBlank && filterIsBlank)) && indexSnapshot == 0 && _localBackgroundFillTask == null)
                            {
                                _localBackgroundFillTask = PrefillRemainingLocalPagesAsync(filterSnapshot, pageSize, _totalFilteredCount, token);
                            }
                        }
                        finally
                        {
                            if (showBusy) IsBusy = false;
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    var skip = indexSnapshot * pageSize;
                    var result = FilterEngine.FilterPage(_localMaster, filterSnapshot, skip, pageSize);
                    _totalFilteredCount = result.Total;
                    TotalCount = _totalFilteredCount;
                    var pageDataLocal = result.Page;
                    _pageCache[indexSnapshot] = pageDataLocal;
                    _pageCache[-1] = new List<ComboRecord>();
                    EvictCacheIfNeeded();
                    UpdateHasNextLocal(indexSnapshot, pageDataLocal.Count, pageSize, _totalFilteredCount);
                    bool appendMode = _pagingDown && indexSnapshot > 0;
                    if (appendMode) _appendInsertIndex = _currentItems.Count;
                    AppendToCurrent(pageDataLocal, append: appendMode);
                    if (showBusy) IsBusy = false;

                    if (AutoBackgroundFill && indexSnapshot == 0 && _localBackgroundFillTask == null)
                    {
                        _localBackgroundFillTask = PrefillRemainingLocalPagesAsync(filterSnapshot, pageSize, _totalFilteredCount, token);
                    }
                }
            }
        }

        private async Task PrefillRemainingLocalPagesAsync(string filter, int pageSize, int totalFiltered, CancellationToken token)
        {
            // Background fill remaining pages sequentially
            try
            {
                for (int p = 1; !token.IsCancellationRequested; p++)
                {
                    int skip = p * pageSize;
                    if (skip >= totalFiltered) break;
                    var result = FilterEngine.FilterPage(_localMaster, filter, skip, pageSize);
                    if (token.IsCancellationRequested) break;
                    var pageData = result.Page;
                    if (pageData.Count == 0) break;

                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        _pageCache[p] = pageData;
                        EvictCacheIfNeeded();
                        // Always append when background filling
                        _pagingDown = true;
                        _appendInsertIndex = _currentItems.Count;
                        AppendToCurrent(pageData, append: true);
                        UpdateHasNextLocal(p, pageData.Count, pageSize, totalFiltered);
                    });
                }
            }
            finally
            {
                _localBackgroundFillTask = null;
            }
        }

        private void RecalculateHasNextRemote(int pageIndex, int itemCount, int pageSize)
        {
            if (_remoteTotal >= 0)
            {
                int fetchedSoFar = (pageIndex * pageSize) + itemCount;
                HasNextPage = fetchedSoFar < _remoteTotal;
            }
            else
            {
                // fallback heuristic: if we got a full page assume more may exist
                HasNextPage = itemCount == pageSize;
            }
            UpdateLoadMoreVisibility();
        }

        private void UpdateHasNextLocal(int pageIndex, int itemCount, int pageSize, int totalFiltered)
        {
            int fetchedSoFar = (pageIndex * pageSize) + itemCount;
            HasNextPage = fetchedSoFar < totalFiltered;
            UpdateLoadMoreVisibility();
        }

        public void ClearPageCache()
        {
            _pageCache.Clear();
            HasNextPage = false;
        }

        private void EvictCacheIfNeeded()
        {
            if (CachePageLimit <= 0) return;
            var normalKeys = _pageCache.Keys.Where(k => k >= 0).OrderBy(k => k).ToList();
            if (normalKeys.Count <= CachePageLimit) return;
            int removeCount = normalKeys.Count - CachePageLimit;
            foreach (var k in normalKeys.Take(removeCount))
            {
                _pageCache.Remove(k);
            }
        }

        private int EffectivePageSize => PageSize > 0 ? PageSize : RemoteTake;

        // Add this property if it does not already exist in SmartComboBox.Core.cs or elsewhere
        private bool IsRemoteConfigured
        {
            get
            {
                // Replace this logic with the actual condition for remote configuration in your app
                return RemoteTake > 0; // Example: check if RemoteTake is set
            }
        }
    }
}
