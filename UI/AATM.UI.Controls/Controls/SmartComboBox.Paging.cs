using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;

namespace AATM.UI.Controls
{
    public partial class SmartComboBox
    {
        // Paging logic only. All fields are defined in SmartComboBox.Core.cs

        //private async Task RunInitialSearchAsync(string filter, CancellationToken token = default)
        //{
        //    _pageCache.Clear();
        //    _currentItems.Clear();
        //    var trimmed = (filter ?? string.Empty).Trim();
        //    _lastFilter = trimmed;
        //    _suppressPageIndexChanged = true;
        //    PageIndex =0;
        //    _suppressPageIndexChanged = false;
        //    if (token.IsCancellationRequested) return;
        //    if (trimmed.Length < MinSearchLength && !(ShowAllOnBlank && string.IsNullOrEmpty(trimmed)))
        //    {
        //        HasNextPage = false;
        //        return;
        //    }
        //    await AppendPageAsync(0, token);
        //    if (!token.IsCancellationRequested && _listBox != null && _currentItems.Count >0 && _listBox.SelectedIndex <0)
        //    {
        //        _listBox.SelectedIndex =0;
        //        var first = _currentItems[0];
        //        SelectedId = first.IdNo;
        //        SelectedCode = first.Code;
        //        SelectedName = first.Name;
        //        UpdateSelectedValueFromRecord(first);
        //        _updatingSelectedItem = true;
        //        try { SelectedItem = first.Raw ?? (object)first; }
        //        finally { _updatingSelectedItem = false; }
        //        _listBox.ScrollIntoView(first);
        //    }
        //}

        private async Task AppendPageAsync(int pageIndex, CancellationToken token = default)
        {
            if (token.IsCancellationRequested) return;
            var filterIsBlank = string.IsNullOrEmpty(_lastFilter?.Trim());
            // Always allow blank filter if ShowAllOnBlank is true
            var safeFilter = (_lastFilter ?? string.Empty).Trim();
            if (safeFilter.Length < MinSearchLength && !(ShowAllOnBlank && filterIsBlank))
            {
                HasNextPage = false;
                return;
            }
            if (pageIndex > 0) _forceFirstSelectionOnLoad = false;
            // Fix: Add null-coalescing for IsRemoteConfigured (assume false if not defined)
            bool isRemoteConfigured = false;
#if ISREMOTECONFIGURED_FIELD
            isRemoteConfigured = IsRemoteConfigured;
#endif
            bool remote = UseRemoteFetch || (_localMaster.Count == 0 && isRemoteConfigured) || _localMaster.Count > AutoRemoteThreshold;
            int pageSize = EffectivePageSize;
            if (remote)
            {
                try
                {
                    await Application.Current.Dispatcher.InvokeAsync(() => IsBusy = true);
                    // Fix: Remove explicit null assignment, just declare variable
                    List<ComboRecord> pageData;
                    try
                    {
                        // Fix: Pass non-null filter argument
                        pageData = await FetchRemoteRecordsAsync(safeFilter, token, pageIndex, pageSize).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Suppress error: cancellation is expected when a new search starts
                        await Application.Current.Dispatcher.InvokeAsync(() => ClearError());
                        return;
                    }
                    if (token.IsCancellationRequested) return;
                    _pageCache[pageIndex] = pageData;
                    await Application.Current.Dispatcher.InvokeAsync(() => EvictCacheIfNeeded());
                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        UpdateHasNext(pageIndex, pageData.Count, pageSize);
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
                    await Application.Current.Dispatcher.InvokeAsync(() => IsBusy = false);
                }
            }
            else
            {
                var filterSnapshot = safeFilter;
                var indexSnapshot = pageIndex;
                IsBusy = true;
                if (UseBackgroundFiltering)
                {
                    await Task.Run(() =>
                    {
                        var skip = indexSnapshot * pageSize;
                        // Fix: Pass non-null filter argument
                        var result = FilterEngine.FilterPage(_localMaster, filterSnapshot, skip, pageSize);
                        return result;
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
                            UpdateHasNext(indexSnapshot, pageDataLocal.Count, pageSize);
                            bool appendMode = _pagingDown && indexSnapshot > 0;
                            if (appendMode) _appendInsertIndex = _currentItems.Count;
                            AppendToCurrent(pageDataLocal, append: appendMode);
                        }
                        finally
                        {
                            IsBusy = false;
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    var skip = indexSnapshot * pageSize;
                    // Fix: Pass non-null filter argument
                    var result = FilterEngine.FilterPage(_localMaster, filterSnapshot, skip, pageSize);
                    _totalFilteredCount = result.Total;
                    TotalCount = _totalFilteredCount;
                    var pageDataLocal = result.Page;
                    _pageCache[indexSnapshot] = pageDataLocal;
                    _pageCache[-1] = new List<ComboRecord>();
                    EvictCacheIfNeeded();
                    UpdateHasNext(indexSnapshot, pageDataLocal.Count, pageSize);
                    bool appendMode = _pagingDown && indexSnapshot > 0;
                    if (appendMode) _appendInsertIndex = _currentItems.Count;
                    AppendToCurrent(pageDataLocal, append: appendMode);
                    IsBusy = false;
                }
            }
        }

        private void UpdateHasNext(int pageIndex, int itemCount, int pageSize)
        {
            HasNextPage = itemCount >= pageSize;
            UpdateLoadMoreVisibility();
        }

        public void ClearPageCache()
        {
            _pageCache.Clear();
            HasNextPage = false;
        }

        private void EvictCacheIfNeeded()
        {
            if (CachePageLimit <=0) return;
            var normalKeys = _pageCache.Keys.Where(k => k >=0).OrderBy(k => k).ToList();
            if (normalKeys.Count <= CachePageLimit) return;
            int removeCount = normalKeys.Count - CachePageLimit;
            foreach (var k in normalKeys.Take(removeCount))
            {
                _pageCache.Remove(k);
            }
        }

        private int EffectivePageSize => PageSize >0 ? PageSize : RemoteTake;
    }
}
