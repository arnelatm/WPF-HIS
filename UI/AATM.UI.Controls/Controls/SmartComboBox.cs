using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Data.SqlClient;


namespace AATM.UI.Controls
{
    /// <summary>
    /// Hybrid SmartComboBox:
    /// - local async filtering (in-memory) when ItemsSource is small
    /// - remote async SQL fetching when UseRemoteFetch = true OR local is too big
    /// - exposes SelectedId, SelectedCode, SelectedName
    /// - expects columns/properties named: IdNo, Code, Name (SQL should alias to these)
    /// </summary>
    [TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_ListBox", Type = typeof(ListBox))]
    [TemplatePart(Name = "PART_Button", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
    [TemplatePart(Name = "PART_Arrow", Type = typeof(System.Windows.Shapes.Path))]
    [TemplatePart(Name = "PART_BusyText", Type = typeof(TextBlock))]
    public class SmartComboBox : Control
    {
        private TextBox _textBox;
        private ListBox _listBox;
        private Button _button;
        private Popup _popup;
        private TextBlock _busyText;

        // local master copy for in-memory filtering
        private List<ComboRecord> _localMaster = new();

        // current cancellation for async ops
        private CancellationTokenSource _cts;

        // threshold to auto-switch to remote mode (if local list too big)
        private const int AutoRemoteThreshold = 50000;

        static SmartComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SmartComboBox),
                new FrameworkPropertyMetadata(typeof(SmartComboBox)));
        }

        public SmartComboBox()
        {
            // default values
            RemoteTake = 200;
        }

        #region Dependency Properties

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                nameof(ItemsSource),
                typeof(IEnumerable),
                typeof(SmartComboBox),
                new PropertyMetadata(null, OnItemsSourceChanged));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb)
            {
                scb.BuildLocalMasterFromItemsSource();
                scb.TrySelectBySelectedValue();
            }
        }

        public static readonly DependencyProperty UseRemoteFetchProperty =
            DependencyProperty.Register(
                nameof(UseRemoteFetch),
                typeof(bool),
                typeof(SmartComboBox),
                new PropertyMetadata(false));

        /// <summary>
        /// If true, will query SQL instead of/local plus local filtering.
        /// </summary>
        public bool UseRemoteFetch
        {
            get => (bool)GetValue(UseRemoteFetchProperty);
            set => SetValue(UseRemoteFetchProperty, value);
        }

        public static readonly DependencyProperty ConnectionStringProperty =
            DependencyProperty.Register(
                nameof(ConnectionString),
                typeof(string),
                typeof(SmartComboBox),
                new PropertyMetadata(string.Empty));

        /// <summary>
        /// SQL Server connection string
        /// </summary>
        public string ConnectionString
        {
            get => (string)GetValue(ConnectionStringProperty);
            set => SetValue(ConnectionStringProperty, value);
        }

        public static readonly DependencyProperty SqlQueryTemplateProperty =
            DependencyProperty.Register(
                nameof(SqlQueryTemplate),
                typeof(string),
                typeof(SmartComboBox),
                new PropertyMetadata(string.Empty));

        /// <summary>
        /// SQL text to run. Must contain column names/aliases: IdNo, Code, Name.
        /// Must accept parameter @filter (we will add it).
        /// Example:
        /// SELECT TOP 100 CustomerId AS IdNo, CustCode AS Code, CustName AS Name
        /// FROM Customers
        /// WHERE CustCode LIKE @filter + '%' OR CustName LIKE @filter + '%'
        /// ORDER BY CustName
        /// </summary>
        public string SqlQueryTemplate
        {
            get => (string)GetValue(SqlQueryTemplateProperty);
            set => SetValue(SqlQueryTemplateProperty, value);
        }

        public static readonly DependencyProperty RemoteTakeProperty =
            DependencyProperty.Register(
                nameof(RemoteTake),
                typeof(int),
                typeof(SmartComboBox),
                new PropertyMetadata(200));

        /// <summary>
        /// Max rows to fetch from remote SQL.
        /// </summary>
        public int RemoteTake
        {
            get => (int)GetValue(RemoteTakeProperty);
            set => SetValue(RemoteTakeProperty, value);
        }

        // Selected values (output)
        public static readonly DependencyProperty SelectedIdProperty =
            DependencyProperty.Register(
                nameof(SelectedId),
                typeof(object),
                typeof(SmartComboBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public object SelectedId
        {
            get => GetValue(SelectedIdProperty);
            set => SetValue(SelectedIdProperty, value);
        }

        public static readonly DependencyProperty SelectedCodeProperty =
            DependencyProperty.Register(
                nameof(SelectedCode),
                typeof(string),
                typeof(SmartComboBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string SelectedCode
        {
            get => (string)GetValue(SelectedCodeProperty);
            set => SetValue(SelectedCodeProperty, value);
        }

        public static readonly DependencyProperty SelectedNameProperty =
            DependencyProperty.Register(
                nameof(SelectedName),
                typeof(string),
                typeof(SmartComboBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string SelectedName
        {
            get => (string)GetValue(SelectedNameProperty);
            set => SetValue(SelectedNameProperty, value);
        }

        // Placeholder (already in your XAML)
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                nameof(Placeholder),
                typeof(string),
                typeof(SmartComboBox),
                new PropertyMetadata("Type to search..."));

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        // Busy flag for "Searching..." in popup
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register(
                nameof(IsBusy),
                typeof(bool),
                typeof(SmartComboBox),
                new PropertyMetadata(false));

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        // Added: debounce milliseconds (configurable)
        public static readonly DependencyProperty DebounceMillisecondsProperty =
            DependencyProperty.Register(
                nameof(DebounceMilliseconds),
                typeof(int),
                typeof(SmartComboBox),
                new PropertyMetadata(220));

        public int DebounceMilliseconds
        {
            get => (int)GetValue(DebounceMillisecondsProperty);
            set => SetValue(DebounceMillisecondsProperty, value);
        }

        // Added: Text DP to expose current text
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(SmartComboBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb && scb._textBox != null)
            {
                var newText = e.NewValue as string ?? string.Empty;
                if (scb._textBox.Text != newText)
                    scb._textBox.Text = newText;
            }
        }

        // Added: SelectedValue/SelectedValuePath for classic ComboBox compatibility
        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register(
                nameof(SelectedValuePath),
                typeof(string),
                typeof(SmartComboBox),
                new PropertyMetadata(null, OnSelectedValuePathChanged));

        public string SelectedValuePath
        {
            get => (string)GetValue(SelectedValuePathProperty);
            set => SetValue(SelectedValuePathProperty, value);
        }

        private static void OnSelectedValuePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb)
            {
                scb.TrySelectBySelectedValue();
            }
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(
                nameof(SelectedValue),
                typeof(object),
                typeof(SmartComboBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedValueChanged));

        public object SelectedValue
        {
            get => GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb)
            {
                scb.TrySelectBySelectedValue();
            }
        }

        // Added: DisplayMemberPath for display control
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                nameof(DisplayMemberPath),
                typeof(string),
                typeof(SmartComboBox),
                new PropertyMetadata(null));

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _textBox = GetTemplateChild("PART_TextBox") as TextBox;
            _listBox = GetTemplateChild("PART_ListBox") as ListBox;
            _button = GetTemplateChild("PART_Button") as Button;
            _popup = GetTemplateChild("PART_Popup") as Popup;
            _busyText = GetTemplateChild("PART_BusyText") as TextBlock;

            if (_textBox != null)
            {
                _textBox.TextChanged += TextBox_TextChanged;
                _textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
                // sync initial Text DP to textbox
                var text = Text ?? string.Empty;
                if (_textBox.Text != text)
                    _textBox.Text = text;
            }

            if (_button != null)
            {
                _button.Click += (s, e) =>
                {
                    if (_popup != null)
                    {
                        if (_popup.IsOpen)
                        {
                            _popup.IsOpen = false;
                        }
                        else
                        {
                            // show all local items if any
                            if (_localMaster.Any())
                            {
                                _listBox.ItemsSource = _localMaster;
                                _popup.IsOpen = true;
                            }
                            else
                            {
                                // if no local items but remote is enabled, trigger empty search
                                if (UseRemoteFetch)
                                    _ = RunSearchAsync(string.Empty);
                                _popup.IsOpen = true;
                            }
                        }
                    }
                };
            }

            if (_listBox != null)
            {
                _listBox.MouseLeftButtonUp += (s, e) => CommitSelection();
                _listBox.SelectionChanged += (s, e) =>
                {
                    if (_listBox.SelectedItem is ComboRecord cr)
                    {
                        SelectedId = cr.IdNo;
                        SelectedCode = cr.Code;
                        SelectedName = cr.Name;
                        UpdateSelectedValueFromRecord(cr);
                    }
                };
            }

            // rebuild local list if ItemsSource already set
            BuildLocalMasterFromItemsSource();
            TrySelectBySelectedValue();
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_popup == null || _listBox == null) return;

            if (e.Key == Key.Down)
            {
                if (!_popup.IsOpen)
                {
                    _popup.IsOpen = true;
                }

                if (_listBox.Items.Count > 0)
                {
                    _listBox.Focus();
                    if (_listBox.SelectedIndex < 0) _listBox.SelectedIndex = 0;
                    _listBox.ScrollIntoView(_listBox.SelectedItem);
                }

                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                CommitSelection();
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                _popup.IsOpen = false;
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // keep Text DP in sync
            var current = _textBox.Text ?? string.Empty;
            if (Text != current)
                Text = current;

            // debounce and run hybrid search
            var text = _textBox.Text ?? string.Empty;
            _ = DebouncedSearchAsync(text);

            // show popup as the user types
            if (_popup != null && !_popup.IsOpen)
                _popup.IsOpen = true;

            // show/hide placeholder (in template we set it via code)
            var placeholder = GetTemplateChild("PART_Placeholder") as TextBlock;
            if (placeholder != null)
                placeholder.Visibility = string.IsNullOrEmpty(text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private async Task DebouncedSearchAsync(string filter)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            try
            {
                var delay = Math.Max(0, DebounceMilliseconds);
                await Task.Delay(TimeSpan.FromMilliseconds(delay), token); // debounce
                await RunSearchAsync(filter, token);
            }
            catch (TaskCanceledException)
            {
                // ignore
            }
        }

        private async Task RunSearchAsync(string filter, CancellationToken token = default)
        {
            IsBusy = true;

            try
            {
                // decide mode
                bool mustUseRemote = UseRemoteFetch;
                if (!mustUseRemote && _localMaster.Count > AutoRemoteThreshold)
                    mustUseRemote = true;

                List<ComboRecord> results;
                if (mustUseRemote)
                {
                    results = await FetchFromSqlAsync(filter, token);
                }
                else
                {
                    // local filtering
                    results = await Task.Run(() =>
                    {
                        return _localMaster
                            .Where(r => r.Matches(filter))
                            .Take(500) // cap for UI
                            .ToList();
                    }, token);
                }

                if (token.IsCancellationRequested) return;

                // update list in UI thread
                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (_listBox != null)
                    {
                        _listBox.ItemsSource = results;
                        if (results.Count > 0)
                            _listBox.SelectedIndex = 0;
                    }
                });
            }
            catch (TaskCanceledException)
            {
                // user typed again
            }
            catch (Exception ex)
            {
                // you could log here
                System.Diagnostics.Debug.WriteLine("SmartComboBox search error: " + ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task<List<ComboRecord>> FetchFromSqlAsync(string filter, CancellationToken token)
        {
            var list = new List<ComboRecord>();

            // if no connection or no query, return empty list (but don’t crash)
            if (string.IsNullOrWhiteSpace(ConnectionString) || string.IsNullOrWhiteSpace(SqlQueryTemplate))
                return list;

            // enforce TOP if user forgot
            string sql = SqlQueryTemplate;
            // we assume user will alias properly: IdNo, Code, Name

            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@filter", SqlDbType.NVarChar, 200) { Value = filter ?? string.Empty });

            await conn.OpenAsync(token);
            using var reader = await cmd.ExecuteReaderAsync(token);
            while (await reader.ReadAsync(token))
            {
                var rec = new ComboRecord
                {
                    Raw = reader, // raw reference for display path via SafeGet
                    IdNo = SafeGet(reader, "IdNo"),
                    Code = SafeGet(reader, "Code")?.ToString() ?? string.Empty,
                    Name = SafeGet(reader, "Name")?.ToString() ?? string.Empty
                };
                list.Add(rec);
                if (list.Count >= RemoteTake) break;
            }

            return list;
        }

        private object SafeGet(IDataRecord r, string field)
        {
            try
            {
                int ord = r.GetOrdinal(field);
                if (r.IsDBNull(ord)) return null;
                return r.GetValue(ord);
            }
            catch
            {
                return null;
            }
        }

        private void CommitSelection()
        {
            if (_listBox?.SelectedItem is ComboRecord cr)
            {
                SelectedId = cr.IdNo;
                SelectedCode = cr.Code;
                SelectedName = cr.Name;
                UpdateSelectedValueFromRecord(cr);

                if (_textBox != null)
                {
                    var display = GetDisplayText(cr);
                    _textBox.Text = display;
                    Text = display;
                    _textBox.CaretIndex = _textBox.Text.Length;
                    _textBox.Focus();
                }

                if (_popup != null)
                    _popup.IsOpen = false;
            }
        }

        private void BuildLocalMasterFromItemsSource()
        {
            _localMaster.Clear();

            if (ItemsSource == null) return;

            foreach (var item in ItemsSource)
            {
                // item could be: DataRowView, anonymous, DTO, your own entity, etc.
                var rec = ComboRecord.FromUnknown(item);
                if (rec != null)
                    _localMaster.Add(rec);
            }

            // if textbox text already has something, refilter
            if (_textBox != null && !string.IsNullOrEmpty(_textBox.Text))
            {
                _ = DebouncedSearchAsync(_textBox.Text);
            }
        }

        private void UpdateSelectedValueFromRecord(ComboRecord cr)
        {
            var path = SelectedValuePath;
            if (string.IsNullOrWhiteSpace(path)) return;

            var value = GetValueByPath(cr, path);
            SelectedValue = value;
        }

        private object GetValueByPath(ComboRecord cr, string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;

            // common shortcuts
            if (path.Equals("IdNo", StringComparison.OrdinalIgnoreCase)) return cr.IdNo;
            if (path.Equals("Code", StringComparison.OrdinalIgnoreCase)) return cr.Code;
            if (path.Equals("Name", StringComparison.OrdinalIgnoreCase)) return cr.Name;

            // try Raw item reflection / data row access
            var raw = cr.Raw;
            if (raw is DataRowView drv)
            {
                if (drv.Row.Table.Columns.Contains(path)) return drv[path];
            }
            else if (raw is DataRow dr)
            {
                if (dr.Table.Columns.Contains(path)) return dr[path];
            }
            else if (raw != null)
            {
                var t = raw.GetType();
                var p = t.GetProperty(path);
                if (p != null)
                    return p.GetValue(raw);
            }

            // fallback: try on record itself
            var rType = cr.GetType();
            var pr = rType.GetProperty(path);
            if (pr != null)
                return pr.GetValue(cr);

            return null;
        }

        private string GetDisplayText(ComboRecord cr)
        {
            var dmp = DisplayMemberPath;
            if (!string.IsNullOrWhiteSpace(dmp))
            {
                var val = GetValueByPath(cr, dmp);
                if (val != null) return val.ToString();
            }
            return cr.Display;
        }

        private void TrySelectBySelectedValue()
        {
            if (_listBox == null) return;

            var path = SelectedValuePath;
            var selVal = SelectedValue;
            if (string.IsNullOrWhiteSpace(path) || selVal == null) return;

            // search in local master
            var match = _localMaster.FirstOrDefault(r =>
            {
                var v = GetValueByPath(r, path);
                return EqualsSafe(v, selVal);
            });

            if (match != null)
            {
                _listBox.ItemsSource = _localMaster;
                _listBox.SelectedItem = match;
                var display = GetDisplayText(match);
                if (_textBox != null)
                {
                    _textBox.Text = display;
                    Text = display;
                }
                SelectedId = match.IdNo;
                SelectedCode = match.Code;
                SelectedName = match.Name;
            }
            else
            {
                // keep Text roughly synchronized if we can't resolve an item
                if (_textBox != null && selVal != null)
                {
                    var display = selVal.ToString();
                    if (!string.IsNullOrEmpty(display))
                    {
                        _textBox.Text = display;
                        Text = display;
                    }
                }
            }
        }

        private bool EqualsSafe(object a, object b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            return a.Equals(b);
        }

        // Internal representation
        private class ComboRecord
        {
            public object Raw { get; set; }
            public object IdNo { get; set; } = new object();
            public string Code { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;

            public string Display => string.IsNullOrEmpty(Code) ? Name : $"{Code} - {Name}";

            public bool Matches(string filter)
            {
                if (string.IsNullOrEmpty(filter)) return true;
                return (Code?.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    || (Name?.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            public static ComboRecord FromUnknown(object obj)
            {
                if (obj == null) return null;

                // if it's already our record
                if (obj is ComboRecord cr)
                    return cr;

                // DataRowView
                if (obj is DataRowView drv)
                {
                    return new ComboRecord
                    {
                        Raw = obj,
                        IdNo = drv["IdNo"],
                        Code = drv["Code"]?.ToString() ?? string.Empty,
                        Name = drv["Name"]?.ToString() ?? string.Empty
                    };
                }

                // DataRow
                if (obj is DataRow dr)
                {
                    return new ComboRecord
                    {
                        Raw = obj,
                        IdNo = dr["IdNo"],
                        Code = dr["Code"]?.ToString() ?? string.Empty,
                        Name = dr["Name"]?.ToString() ?? string.Empty
                    };
                }

                // POCO with IdNo/Code/Name
                var t = obj.GetType();
                var pId = t.GetProperty("IdNo");
                var pCode = t.GetProperty("Code");
                var pName = t.GetProperty("Name");
                if (pId != null || pCode != null || pName != null)
                {
                    return new ComboRecord
                    {
                        Raw = obj,
                        IdNo = pId?.GetValue(obj),
                        Code = pCode?.GetValue(obj)?.ToString() ?? string.Empty,
                        Name = pName?.GetValue(obj)?.ToString() ?? string.Empty
                    };
                }

                // fallback: treat as string
                return new ComboRecord
                {
                    Raw = obj,
                    IdNo = obj,
                    Code = string.Empty,
                    Name = obj.ToString() ?? string.Empty
                };
            }
        }
    }
}
