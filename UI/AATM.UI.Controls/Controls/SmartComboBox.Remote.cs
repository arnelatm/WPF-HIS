using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AATM.DataAccess.Sql;

namespace AATM.UI.Controls
{
    public partial class SmartComboBox
    {
        private bool IsRemoteConfigured => !string.IsNullOrEmpty(ConnectionString) && !string.IsNullOrEmpty(RemoteQueryTemplate);

        private int _remoteTotal = -1; // cache total rows for current filter
        private Task _prefetchTask; // background prefetch of next pages

        private async Task<List<ComboRecord>> FetchRemoteRecordsAsync(string filter, CancellationToken token, int pageIndex, int pageSize)
        {
            if (!IsRemoteConfigured) return new List<ComboRecord>();
            try
            {
                var repo = new ComboRecordRepository(ConnectionString);
                if (pageIndex == 0)
                {
                    _remoteTotal = await repo.FetchTotalCountAsync(RemoteQueryTemplate, FilterCodeField, FilterNameField, filter ?? string.Empty, token).ConfigureAwait(false);
                    await Application.Current.Dispatcher.InvokeAsync(() => TotalCount = _remoteTotal);
                }

                var sqlPage = await repo.FetchRemoteRecordsAsync(RemoteQueryTemplate, FilterCodeField, FilterNameField, filter ?? string.Empty, pageIndex, pageSize, token).ConfigureAwait(false);

                var page = new List<ComboRecord>(sqlPage.Count);
                foreach (var r in sqlPage)
                {
                    page.Add(new ComboRecord
                    {
                        IdNo = r.IdNo,
                        Code = r.Code ?? string.Empty,
                        Name = r.Name ?? string.Empty,
                        Raw = r.Raw,
                    });
                }

                if (_remoteTotal >= 0)
                {
                    int fetchedSoFar = (pageIndex * pageSize) + page.Count;
                    bool hasNext = fetchedSoFar < _remoteTotal;
                    await Application.Current.Dispatcher.InvokeAsync(() => HasNextPage = hasNext);

                    if (hasNext && _prefetchTask == null)
                    {
                        int startPrefetch = pageIndex + 1;
                        int prefetchPages = Math.Max(1, PrefetchPages);
                        _prefetchTask = Task.Run(async () =>
                        {
                            try
                            {
                                for (int p = startPrefetch; p < startPrefetch + prefetchPages && !_cts?.IsCancellationRequested == true; p++)
                                {
                                    if (_pageCache.ContainsKey(p)) continue;
                                    var nextSqlPage = await repo.FetchRemoteRecordsAsync(RemoteQueryTemplate, FilterCodeField, FilterNameField, filter ?? string.Empty, p, pageSize, token).ConfigureAwait(false);
                                    if (token.IsCancellationRequested || nextSqlPage.Count == 0) break;

                                    var nextUiPage = new List<ComboRecord>(nextSqlPage.Count);
                                    foreach (var rr in nextSqlPage)
                                    {
                                        nextUiPage.Add(new ComboRecord
                                        {
                                            IdNo = rr.IdNo,
                                            Code = rr.Code ?? string.Empty,
                                            Name = rr.Name ?? string.Empty,
                                            Raw = rr.Raw,
                                        });
                                    }
                                    _pageCache[p] = nextUiPage;
                                    if (_remoteTotal >= 0)
                                    {
                                        int fs = (p * pageSize) + nextUiPage.Count;
                                        if (fs >= _remoteTotal) break; // reached end
                                    }
                                }
                            }
                            catch { }
                            finally { _prefetchTask = null; }
                        }, token);
                    }
                }
                return page;
            }
            catch (OperationCanceledException)
            {
                return new List<ComboRecord>();
            }
            catch (Exception ex)
            {
                SetError($"Error fetching data: {ex.Message}");
                return new List<ComboRecord>();
            }
        }
    }
}
