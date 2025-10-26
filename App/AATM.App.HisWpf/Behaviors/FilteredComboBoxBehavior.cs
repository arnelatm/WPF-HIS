using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace AATM.App.HisWpf.Behaviors
{
    public static class FilteredComboBoxBehavior
    {
        // Enable behavior
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(FilteredComboBoxBehavior),
                new PropertyMetadata(false, OnIsEnabledChanged));

        // Master items source (bind to ViewModel.AvailableXxx)
        public static readonly DependencyProperty MasterItemsSourceProperty =
            DependencyProperty.RegisterAttached("MasterItemsSource", typeof(IEnumerable), typeof(FilteredComboBoxBehavior),
                new PropertyMetadata(null, OnMasterItemsSourceChanged));

        // Debounce
        public static readonly DependencyProperty FilterDebounceMillisecondsProperty =
            DependencyProperty.RegisterAttached("FilterDebounceMilliseconds", typeof(int), typeof(FilteredComboBoxBehavior),
                new PropertyMetadata(120));

        // Readonly IsBusy (so ProgressBar can bind to it)
        private static readonly DependencyPropertyKey IsBusyPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly("IsBusy", typeof(bool), typeof(FilteredComboBoxBehavior),
                new PropertyMetadata(false));
        public static readonly DependencyProperty IsBusyProperty = IsBusyPropertyKey.DependencyProperty;

        // per-instance storage
        private class State
        {
            public ListCollectionView? EditView;
            public CancellationTokenSource? Cts;
            public IEnumerable? MasterSnapshot;
            // store the TextChanged handler so it can be removed on detach
            public TextChangedEventHandler? TextChangedHandler;
        }

        private static readonly DependencyProperty StateProperty =
            DependencyProperty.RegisterAttached("State", typeof(State), typeof(FilteredComboBoxBehavior), new PropertyMetadata(null));

        public static void SetIsEnabled(DependencyObject d, bool v) => d.SetValue(IsEnabledProperty, v);
        public static bool GetIsEnabled(DependencyObject d) => (bool)d.GetValue(IsEnabledProperty);

        public static void SetMasterItemsSource(DependencyObject d, IEnumerable v) => d.SetValue(MasterItemsSourceProperty, v);
        public static IEnumerable GetMasterItemsSource(DependencyObject d) => (IEnumerable)d.GetValue(MasterItemsSourceProperty);

        public static void SetFilterDebounceMilliseconds(DependencyObject d, int v) => d.SetValue(FilterDebounceMillisecondsProperty, v);
        public static int GetFilterDebounceMilliseconds(DependencyObject d) => (int)d.GetValue(FilterDebounceMillisecondsProperty);

        private static void SetIsBusy(DependencyObject d, bool v) => d.SetValue(IsBusyPropertyKey, v);
        public static bool GetIsBusy(DependencyObject d) => (bool)d.GetValue(IsBusyProperty);

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ComboBox cb) return;
            var enabled = (bool)e.NewValue;
            if (enabled)
            {
                Attach(cb);
            }
            else
            {
                Detach(cb);
            }
        }

        private static void OnMasterItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ComboBox cb) return;
            // If not editing, show master source
            var state = GetState(cb) ?? new State();
            cb.ItemsSource = e.NewValue as IEnumerable;
            state.MasterSnapshot = e.NewValue as IEnumerable;
            SetState(cb, state);
        }

        private static void Attach(ComboBox cb)
        {
            if (GetState(cb) != null) return;
            var s = new State();
            SetState(cb, s);

            cb.GotKeyboardFocus += Cb_GotKeyboardFocus;  
            cb.PreviewMouseDown += Cb_PreviewMouseDown;
            cb.DropDownClosed += Cb_DropDownClosed;

            // create and store the TextChanged handler so it can be removed cleanly later
            TextChangedEventHandler handler = (s2, e) => OnEditableTextChanged(cb);
            s.TextChangedHandler = handler;
            cb.AddHandler(TextBox.TextChangedEvent, handler);
        }

        private static void Detach(ComboBox cb)
        {
            cb.GotKeyboardFocus -= Cb_GotKeyboardFocus;
            cb.PreviewMouseDown -= Cb_PreviewMouseDown;
            cb.DropDownClosed -= Cb_DropDownClosed;
            // cancel outstanding work (use atomic swap to avoid races)
            var state = GetState(cb);
            if (state != null)
            {
                // remove stored TextChanged handler if present
                try
                {
                    if (state.TextChangedHandler is not null)
                    {
                        cb.RemoveHandler(TextBox.TextChangedEvent, state.TextChangedHandler);
                        state.TextChangedHandler = null;
                    }
                }
                catch { /* ignore removal failures */ }

                var cts = Interlocked.Exchange(ref state.Cts, null);
                if (cts != null)
                {
                    try { cts.Cancel(); }
                    catch (ObjectDisposedException) { /* already disposed - ignore */ }
                    try { cts.Dispose(); } catch { /* ignore */ }
                }
            }
            SetState(cb, null);
        }

        private static State? GetState(DependencyObject d) => (State?)d.GetValue(StateProperty);
        private static void SetState(DependencyObject d, State? s) => d.SetValue(StateProperty, s);

        private static void Cb_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
        {
            if (sender is ComboBox cb && !cb.IsDropDownOpen) EnsureEditView(cb);
        }

        private static void Cb_GotKeyboardFocus(object? sender, RoutedEventArgs e)
        {
            if (sender is ComboBox cb) EnsureEditView(cb);
        }

        private static void EnsureEditView(ComboBox cb)
        {
            var state = GetState(cb)!;
            if (state.EditView != null) return;

            var master = GetMasterItemsSource(cb) ?? cb.ItemsSource;
            var snapshot = master?.Cast<object?>().ToList() ?? new List<object?>();
            state.MasterSnapshot = snapshot;
            state.EditView = new ListCollectionView((System.Collections.IList)snapshot);
            cb.ItemsSource = state.EditView;
        }

        private static void Cb_DropDownClosed(object? sender, EventArgs e)
        {
            if (sender is ComboBox cb)
            {
                RestoreMaster(cb);
            }
        }

        private static void RestoreMaster(ComboBox cb)
        {
            var state = GetState(cb);
            if (state != null)
            {
                // atomically take ownership of the CTS so other code won't touch it
                var cts = System.Threading.Interlocked.Exchange(ref state.Cts, null);
                if (cts != null)
                {
                    try { cts.Cancel(); }
                    catch (ObjectDisposedException) { /* already disposed - ignore */ }
                    try { cts.Dispose(); } catch { /* rare - ignore or log */ }
                }
            }

            if (GetMasterItemsSource(cb) != null)
                cb.ItemsSource = GetMasterItemsSource(cb);
            else if (state?.MasterSnapshot != null)
                cb.ItemsSource = state.MasterSnapshot;
            if (state != null) state.EditView = null;
        }

        private static void OnEditableTextChanged(ComboBox cb)
        {
            if (!cb.IsEditable) return;
            var tb = cb.Template.FindName("PART_EditableTextBox", cb) as TextBox;
            if (tb == null) return;

            // Only start filtering for user-driven edits (textbox has keyboard focus).
            // This prevents binding/VM updates (e.g. selecting rows in DataGrid) from
            // triggering filtering and stealing focus.
            if (!tb.IsFocused) return;

            var text = tb.Text ?? string.Empty;
            var state = GetState(cb)!;

            // create and assign new CTS atomically and dispose the previous one
            var newCts = new CancellationTokenSource();
            var old = Interlocked.Exchange(ref state.Cts, newCts);
            if (old != null)
            {
                try { old.Cancel(); }
                catch (ObjectDisposedException) { /* already disposed - ok */ }
                try { old.Dispose(); } catch { /* ignore */ }
            }

            var token = newCts.Token;
            SetIsBusy(cb, true);
            var debounce = GetFilterDebounceMilliseconds(cb);

            // capture snapshot from state.MasterSnapshot (which was set on focus)
            var masterSnapshot = state.MasterSnapshot?.Cast<object?>().ToList() ?? new List<object?>();

            _ = Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(Math.Max(25, debounce), token).ConfigureAwait(false);
                    IEnumerable<object?> results;
                    var f = text.Trim();
                    if (string.IsNullOrEmpty(f))
                    {
                        results = masterSnapshot;
                    }
                    else
                    {
                        // Try to filter by string properties (simple generic approach)
                        results = masterSnapshot.Where(item =>
                        {
                            if (item == null) return false;
                            var props = item.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                            foreach (var p in props)
                            {
                                if (p.PropertyType == typeof(string))
                                {
                                    var v = p.GetValue(item) as string;
                                    if (!string.IsNullOrEmpty(v) && v.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0) return true;
                                }
                            }
                            // fallback to ToString()
                            var ts = item.ToString();
                            return !string.IsNullOrEmpty(ts) && ts.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0;
                        }).ToList();
                    }

                    await cb.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            SetIsBusy(cb, false);
                            return;
                        }

                        var snapshot = results.ToList();
                        state.EditView = new ListCollectionView((System.Collections.IList)snapshot);
                        cb.ItemsSource = state.EditView;

                        // Only open dropdown and adjust caret if the combobox still has keyboard focus.
                        if (cb.IsKeyboardFocusWithin)
                        {
                            cb.IsDropDownOpen = true;

                            var tb2 = cb.Template.FindName("PART_EditableTextBox", cb) as TextBox;
                            if (tb2 != null)
                            {
                                // move caret to end if the text box already has focus; do not force focus
                                if (tb2.IsFocused)
                                {
                                    tb2.SelectionStart = tb2.Text?.Length ?? 0;
                                    tb2.SelectionLength = 0;
                                }
                                else
                                {
                                    tb2.SelectionStart = tb2.Text?.Length ?? 0;
                                    tb2.SelectionLength = 0;
                                }
                            }
                        }

                        SetIsBusy(cb, false);
                    }), DispatcherPriority.Background).Task.ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    await cb.Dispatcher.BeginInvoke((Action)(() => SetIsBusy(cb, false)));
                }
                catch
                {
                    await cb.Dispatcher.BeginInvoke((Action)(() => SetIsBusy(cb, false)));
                }
            });
        }
    }
}