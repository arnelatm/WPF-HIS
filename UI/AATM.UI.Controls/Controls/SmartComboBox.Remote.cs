using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AATM.UI.Controls
{
    public partial class SmartComboBox
    {
        /// <summary>
        /// Consumer-provided async fetch delegate for remote data. Should return a list of ComboRecord for the given filter, page, and size.
        /// </summary>
        public Func<string, int, int, CancellationToken, Task<(IEnumerable<ComboRecord> Records, int TotalCount)>>? RemoteFetchAsync { get; set; }

        private int _remoteTotal = -1; // cache total rows for current filter
        private Task _prefetchTask; // background prefetch of next pages

        private async Task<List<ComboRecord>> FetchRemoteRecordsAsync(string filter, CancellationToken token, int pageIndex, int pageSize)
        {
            if (RemoteFetchAsync == null)
                return new List<ComboRecord>();
            try
            {
                // Consumer must provide: (records, totalCount)
                var (records, totalCount) = await RemoteFetchAsync(filter, pageIndex, pageSize, token).ConfigureAwait(false);
                _remoteTotal = totalCount;
                await Application.Current.Dispatcher.InvokeAsync(() => TotalCount = _remoteTotal);
                var page = new List<ComboRecord>(records);

                if (_remoteTotal >= 0)
                {
                    int fetchedSoFar = (pageIndex * pageSize) + page.Count;
                    bool hasNext = fetchedSoFar < _remoteTotal;
                    await Application.Current.Dispatcher.InvokeAsync(() => HasNextPage = hasNext);
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
