using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Concurrent;
using System.Reflection;
using System.Data;
using AATM.UI.Controls;
using Microsoft.Data.SqlClient; // SQL client
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

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
    [TemplatePart(Name = "PART_BusyText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_LoadMore", Type = typeof(Button))] // added for load more paging
    [TemplatePart(Name = "PART_ListBorder", Type = typeof(Border))] // ensure declared for template lookup
    public class SmartComboBox : Control
    {
        private TextBox _textBox;
        private ListBox _listBox;
        private Button _button;
        private Popup _popup;
        private TextBlock _busyText;
        private Button _loadMoreButton; // backing field for PART_LoadMore (kept for compatibility)
        private Border _listBorder;

        private CancellationTokenSource _cts;
        private List<ComboRecord> _localMaster = new();
        private BulkObservableCollection<ComboRecord> _currentItems = new();
        private readonly Dictionary<int, List<ComboRecord>> _pageCache = new();
        private int _totalFilteredCount;
        private ScrollViewer _scrollViewer;
        private DispatcherTimer _debounce;

        private const int AutoRemoteThreshold = 50000;
        private bool _suppressPageIndexChanged;
        private string _lastFilter = string.Empty;
        private bool _pendingPageDown;
        private bool _pendingPageUp; // new: track upward paging intent
        private bool _ignorePopupSync;
        private int _appendInsertIndex = -1; // index where newly appended items start
        private int _lastPageIndex = 0; // new: remember last page index
        private bool _pagingDown = true; // new: direction flag
        private bool _forceFirstSelectionOnLoad; // new: select first item after initial search results

        private bool _suspendCollectionChangedEvents = false; // suppress handler during bulk updates
        private bool _updatingSelectedItem; // guard reentrancy for SelectedItem

        static SmartComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SmartComboBox), new FrameworkPropertyMetadata(typeof(SmartComboBox)));
        }

        public SmartComboBox()
        {
            RemoteTake = 20;
            _currentItems.CollectionChanged += CurrentItems_CollectionChanged;
            this.Unloaded += SmartComboBox_Unloaded; // Dispose debounce timer
        }

        private void SmartComboBox_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_debounce != null)
            {
                _debounce.Stop();
                _debounce.Tick -= async (_, __) => { };
                _debounce = null;
            }
        }

        private void CurrentItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_suspendCollectionChangedEvents) return; // skip heavy UI actions when batching

            if (_listBox != null && _currentItems.Count > 0)
            {
                if (_pendingPageDown)
                {
                    var targetIndex = (_appendInsertIndex >= 0 && _appendInsertIndex < _currentItems.Count)
                    ? _appendInsertIndex
                    : 0;
                    _listBox.SelectedIndex = targetIndex;
                    _listBox.Focus();
                    // Defer ScrollIntoView to let layout batch
                    _ = _listBox.Dispatcher.BeginInvoke((Action)(() => _listBox.ScrollIntoView(_listBox.SelectedItem)), DispatcherPriority.Background);
                    _pendingPageDown = false;
                    _appendInsertIndex = -1;
                }
                else if (_pendingPageUp)
                {
                    // after loading previous page (replace), select last item
                    _listBox.SelectedIndex = _currentItems.Count - 1;
                    _listBox.Focus();
                    _ = _listBox.Dispatcher.BeginInvoke((Action)(() => _listBox.ScrollIntoView(_listBox.SelectedItem)), DispatcherPriority.Background);
                    _pendingPageUp = false;
                }
            }
            else if (_listBox != null && _currentItems.Count == 0)
            {
                _listBox.SelectedIndex = -1;
            }
        }

        #region Dependency Properties (removed DisplayMemberPath as unused)

        public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(SmartComboBox), new PropertyMetadata(null, OnItemsSourceChanged));

        /// <summary>
        /// Gets or sets the collection used as the source for items in the SmartComboBox.
        /// </summary>
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
                scb.TrySelectBySelectedItem();
            }
        }

        public static readonly DependencyProperty UseRemoteFetchProperty =
        DependencyProperty.Register(nameof(UseRemoteFetch), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value indicating whether remote SQL fetching is enabled.
        /// </summary>
        public bool UseRemoteFetch
        {
            get => (bool)GetValue(UseRemoteFetchProperty);
            set => SetValue(UseRemoteFetchProperty, value);
        }

        public static readonly DependencyProperty ConnectionStringProperty =
        DependencyProperty.Register(nameof(ConnectionString), typeof(string), typeof(SmartComboBox), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the SQL connection string for remote fetching.
        /// </summary>
        public string ConnectionString
        {
            get => (string)GetValue(ConnectionStringProperty);
            set => SetValue(ConnectionStringProperty, value);
        }

        public static readonly DependencyProperty SqlQueryTemplateProperty =
        DependencyProperty.Register(nameof(SqlQueryTemplate), typeof(string), typeof(SmartComboBox), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the SQL query template for remote fetching.
        /// </summary>
        public string SqlQueryTemplate
        {
            get => (string)GetValue(SqlQueryTemplateProperty);
            set => SetValue(SqlQueryTemplateProperty, value);
        }

        public static readonly DependencyProperty RemoteTakeProperty =
        DependencyProperty.Register(nameof(RemoteTake), typeof(int), typeof(SmartComboBox), new PropertyMetadata(20));

        /// <summary>
        /// Gets or sets the number of records to fetch per page in remote mode.
        /// </summary>
        public int RemoteTake
        {
            get => (int)GetValue(RemoteTakeProperty);
            set => SetValue(RemoteTakeProperty, value);
        }

        public static readonly DependencyProperty SelectedIdProperty =
        DependencyProperty.Register(nameof(SelectedId), typeof(object), typeof(SmartComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Gets or sets the selected item's Id value.
        /// </summary>
        public object SelectedId
        {
            get => GetValue(SelectedIdProperty);
            set => SetValue(SelectedIdProperty, value);
        }

        public static readonly DependencyProperty SelectedCodeProperty =
        DependencyProperty.Register(nameof(SelectedCode), typeof(string), typeof(SmartComboBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Gets or sets the selected item's Code value.
        /// </summary>
        public string SelectedCode
        {
            get => (string)GetValue(SelectedCodeProperty);
            set => SetValue(SelectedCodeProperty, value);
        }

        public static readonly DependencyProperty SelectedNameProperty =
        DependencyProperty.Register(nameof(SelectedName), typeof(string), typeof(SmartComboBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Gets or sets the selected item's Name value.
        /// </summary>
        public string SelectedName
        {
            get => (string)GetValue(SelectedNameProperty);
            set => SetValue(SelectedNameProperty, value);
        }

        public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(SmartComboBox), new PropertyMetadata("Type to search..."));

        /// <summary>
        /// Gets or sets the placeholder text shown when the input is empty.
        /// </summary>
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly DependencyProperty IsBusyProperty =
        DependencyProperty.Register(nameof(IsBusy), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value indicating whether the control is busy loading data.
        /// </summary>
        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        public static readonly DependencyProperty DebounceMillisecondsProperty =
        DependencyProperty.Register(nameof(DebounceMilliseconds), typeof(int), typeof(SmartComboBox), new PropertyMetadata(220));

        /// <summary>
        /// Gets or sets the debounce interval in milliseconds for search/filtering.
        /// </summary>
        public int DebounceMilliseconds
        {
            get => (int)GetValue(DebounceMillisecondsProperty);
            set => SetValue(DebounceMillisecondsProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(SmartComboBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged));

        /// <summary>
        /// Gets or sets the current text in the input box.
        /// </summary>
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

        public static readonly DependencyProperty SelectedValuePathProperty =
        DependencyProperty.Register(nameof(SelectedValuePath), typeof(string), typeof(SmartComboBox), new PropertyMetadata(null, OnSelectedValuePathChanged));

        /// <summary>
        /// Gets or sets the property name used for SelectedValue binding.
        /// </summary>
        public string SelectedValuePath
        {
            get => (string)GetValue(SelectedValuePathProperty);
            set => SetValue(SelectedValuePathProperty, value);
        }

        private static void OnSelectedValuePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb) scb.TrySelectBySelectedValue();
        }

        public static readonly DependencyProperty SelectedValueProperty =
        DependencyProperty.Register(nameof(SelectedValue), typeof(object), typeof(SmartComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedValueChanged));

        /// <summary>
        /// Gets or sets the selected value for the control.
        /// </summary>
        public object SelectedValue
        {
            get => GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb) scb.TrySelectBySelectedValue();
        }

        public static readonly DependencyProperty PageIndexProperty =
        DependencyProperty.Register(nameof(PageIndex), typeof(int), typeof(SmartComboBox), new PropertyMetadata(0, OnPageIndexChanged));

        /// <summary>
        /// Gets or sets the current page index for paging.
        /// </summary>
        public int PageIndex
        {
            get => (int)GetValue(PageIndexProperty);
            set => SetValue(PageIndexProperty, value);
        }

        public static readonly DependencyProperty HasNextPageProperty =
        DependencyProperty.Register(nameof(HasNextPage), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value indicating whether there is a next page available.
        /// </summary>
        public bool HasNextPage
        {
            get => (bool)GetValue(HasNextPageProperty);
            set => SetValue(HasNextPageProperty, value);
        }

        // New: Minimum characters required before any search/paging occurs
        public static readonly DependencyProperty MinSearchLengthProperty =
        DependencyProperty.Register(nameof(MinSearchLength), typeof(int), typeof(SmartComboBox), new PropertyMetadata(3)); // was2 -> now3

        /// <summary>
        /// Gets or sets the minimum number of characters required before search/paging occurs.
        /// </summary>
        public int MinSearchLength
        {
            get => (int)GetValue(MinSearchLengthProperty);
            set => SetValue(MinSearchLengthProperty, value);
        }

        // NEW: Toggle automatic paging when user scrolls to bottom (default disabled to prevent continuous paging)
        public static readonly DependencyProperty EnableAutoScrollPagingProperty =
        DependencyProperty.Register(nameof(EnableAutoScrollPaging), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(false, OnEnableAutoScrollPagingChanged));

        /// <summary>
        /// Gets or sets a value indicating whether automatic paging is enabled when scrolling.
        /// </summary>
        public bool EnableAutoScrollPaging
        {
            get => (bool)GetValue(EnableAutoScrollPagingProperty);
            set => SetValue(EnableAutoScrollPagingProperty, value);
        }

        // NEW: IsDropDownOpen DP with methods
        public static readonly DependencyProperty IsDropDownOpenProperty =
        DependencyProperty.Register(nameof(IsDropDownOpen), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(false, OnIsDropDownOpenChanged));

        /// <summary>
        /// Gets or sets a value indicating whether the dropdown is open.
        /// </summary>
        public bool IsDropDownOpen
        {
            get => (bool)GetValue(IsDropDownOpenProperty);
            set => SetValue(IsDropDownOpenProperty, value);
        }

        private static void OnIsDropDownOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb)
            {
                scb.SyncPopupOpenState((bool)e.NewValue);
            }
        }

        public void Open()
        {
            // Only allow opening if current text meets minimum
            var len = _textBox?.Text?.Trim().Length ?? 0;
            if (len >= MinSearchLength)
                IsDropDownOpen = true;
        }
        public void Close() => IsDropDownOpen = false;

        public static readonly DependencyProperty MaxDropDownHeightProperty =
        DependencyProperty.Register(nameof(MaxDropDownHeight), typeof(double), typeof(SmartComboBox), new PropertyMetadata(480.0));

        /// <summary>
        /// Gets or sets the maximum height of the dropdown list.
        /// </summary>
        public double MaxDropDownHeight
        {
            get => (double)GetValue(MaxDropDownHeightProperty);
            set => SetValue(MaxDropDownHeightProperty, value);
        }

        private static void OnEnableAutoScrollPagingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb && scb._scrollViewer != null)
            {
                scb._scrollViewer.ScrollChanged -= scb.ScrollViewer_ScrollChanged;
                if ((bool)e.NewValue)
                {
                    scb._scrollViewer.ScrollChanged += scb.ScrollViewer_ScrollChanged;
                }
            }
        }

        private static void OnPageIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb && !scb._suppressPageIndexChanged)
            {
                int oldIndex = e.OldValue is int oi ? oi : scb._lastPageIndex;
                int newIndex = e.NewValue is int ni ? ni : scb.PageIndex;
                scb._pagingDown = newIndex > oldIndex;
                scb._lastPageIndex = newIndex;
                // Important: use a non-cancellable token when paging via keyboard/scroll
                _ = scb.AppendPageAsync(scb.PageIndex, CancellationToken.None);
            }
        }

        //1. Add the dependency property
        public static readonly DependencyProperty ShowAllOnBlankProperty =
        DependencyProperty.Register(nameof(ShowAllOnBlank), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value indicating whether all items should be shown when the input is blank.
        /// </summary>
        public bool ShowAllOnBlank
        {
            get => (bool)GetValue(ShowAllOnBlankProperty);
            set => SetValue(ShowAllOnBlankProperty, value);
        }

        // New: ItemTemplate and ItemTemplateSelector for custom rendering
        public static readonly DependencyProperty ItemTemplateProperty =
        DependencyProperty.Register(nameof(ItemTemplate), typeof(DataTemplate), typeof(SmartComboBox), new PropertyMetadata(null, OnItemTemplateChanged));

        /// <summary>
        /// Gets or sets the DataTemplate used to display items in the dropdown list.
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        private static void OnItemTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb && scb._listBox != null)
            {
                scb._listBox.ItemTemplate = e.NewValue as DataTemplate;
            }
        }

        public static readonly DependencyProperty ItemTemplateSelectorProperty =
        DependencyProperty.Register(nameof(ItemTemplateSelector), typeof(DataTemplateSelector), typeof(SmartComboBox), new PropertyMetadata(null, OnItemTemplateSelectorChanged));

        /// <summary>
        /// Gets or sets the DataTemplateSelector used to choose a template for each item.
        /// </summary>
        public DataTemplateSelector ItemTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty);
            set => SetValue(ItemTemplateSelectorProperty, value);
        }

        private static void OnItemTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb && scb._listBox != null)
            {
                scb._listBox.ItemTemplateSelector = e.NewValue as DataTemplateSelector;
            }
        }

        // New: SelectedItem to expose underlying object selection
        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(SmartComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

        /// <summary>
        /// Gets or sets the selected item object.
        /// </summary>
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SmartComboBox scb)
            {
                scb.OnSelectedItemChangedCore(e.NewValue);
            }
        }

        private void OnSelectedItemChangedCore(object newValue)
        {
            if (_updatingSelectedItem) return;
            _updatingSelectedItem = true;
            try { TrySelectBySelectedItem(newValue); }
            finally { _updatingSelectedItem = false; }
        }

        public static readonly DependencyProperty HasErrorProperty =
        DependencyProperty.Register(nameof(HasError), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(false));
        /// <summary>
        /// Gets or sets a value indicating whether the control is in an error state.
        /// </summary>
        public bool HasError
        {
            get => (bool)GetValue(HasErrorProperty);
            set => SetValue(HasErrorProperty, value);
        }

        public static readonly DependencyProperty ErrorMessageProperty =
        DependencyProperty.Register(nameof(ErrorMessage), typeof(string), typeof(SmartComboBox), new PropertyMetadata(string.Empty));
        /// <summary>
        /// Gets or sets the error message to display as a tooltip when in error state.
        /// </summary>
        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set => SetValue(ErrorMessageProperty, value);
        }

        // PAGE SIZE //

        public static readonly DependencyProperty PageSizeProperty =
        DependencyProperty.Register(nameof(PageSize), typeof(int), typeof(SmartComboBox), new PropertyMetadata(0));
        /// <summary>
        /// Gets or sets the logical page size used for paging (overrides RemoteTake if >0).
        /// </summary>
        public int PageSize
        {
            get => (int)GetValue(PageSizeProperty);
            set => SetValue(PageSizeProperty, value);
        }

        // CACHE LIMIT //

        public static readonly DependencyProperty CachePageLimitProperty =
        DependencyProperty.Register(nameof(CachePageLimit), typeof(int), typeof(SmartComboBox), new PropertyMetadata(50));
        /// <summary>
        /// Gets or sets the maximum number of pages retained in the in-memory page cache. Older pages are evicted once exceeded.
        /// </summary>
        public int CachePageLimit
        {
            get => (int)GetValue(CachePageLimitProperty);
            set => SetValue(CachePageLimitProperty, value);
        }

        // TOTAL COUNT //

        public static readonly DependencyProperty TotalCountProperty =
        DependencyProperty.Register(nameof(TotalCount), typeof(int), typeof(SmartComboBox), new PropertyMetadata(0));
        /// <summary>
        /// Gets the total number of filtered records (local filter mode) or last remote reported size if available.
        /// </summary>
        public int TotalCount
        {
            get => (int)GetValue(TotalCountProperty);
            private set => SetValue(TotalCountProperty, value);
        }

        // BACKGROUND FILTERING //

        public static readonly DependencyProperty UseBackgroundFilteringProperty =
        DependencyProperty.Register(nameof(UseBackgroundFiltering), typeof(bool), typeof(SmartComboBox), new PropertyMetadata(true));
        /// <summary>
        /// Gets or sets whether local filtering work is performed on a background thread (recommended for large lists).
        /// </summary>
        public bool UseBackgroundFiltering
        {
            get => (bool)GetValue(UseBackgroundFilteringProperty);
            set => SetValue(UseBackgroundFilteringProperty, value);
        }

        // NEW: Field names for remote filtering
        public static readonly DependencyProperty FilterCodeFieldProperty =
        DependencyProperty.Register(nameof(FilterCodeField), typeof(string), typeof(SmartComboBox), new PropertyMetadata("ProductCode"));
        /// <summary>
        /// Gets or sets the field name used for code filtering in remote SQL mode.
        /// </summary>
        public string FilterCodeField
        {
            get => (string)GetValue(FilterCodeFieldProperty);
            set => SetValue(FilterCodeFieldProperty, value);
        }

        public static readonly DependencyProperty FilterNameFieldProperty =
        DependencyProperty.Register(nameof(FilterNameField), typeof(string), typeof(SmartComboBox), new PropertyMetadata("ProductName"));
        /// <summary>
        /// Gets or sets the field name used for name filtering in remote SQL mode.
        /// </summary>
        public string FilterNameField
        {
            get => (string)GetValue(FilterNameFieldProperty);
            set => SetValue(FilterNameFieldProperty, value);
        }

        #endregion

        private bool IsRemoteConfigured =>
        !string.IsNullOrWhiteSpace(ConnectionString) &&
        !string.IsNullOrWhiteSpace(SqlQueryTemplate);

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _textBox = GetTemplateChild("PART_TextBox") as TextBox;
            _listBox = GetTemplateChild("PART_ListBox") as ListBox;
            _button = GetTemplateChild("PART_Button") as Button;
            _popup = GetTemplateChild("PART_Popup") as Popup;
            _busyText = GetTemplateChild("PART_BusyText") as TextBlock;
            _loadMoreButton = GetTemplateChild("PART_LoadMore") as Button; // cache
            _listBorder = GetTemplateChild("PART_ListBorder") as Border;

            if (_loadMoreButton != null)
            {
                _loadMoreButton.Click += async (_, _) =>
                {
                    if (HasNextPage)
                    {
                        _pendingPageDown = true;
                        _appendInsertIndex = _currentItems.Count;
                        PageIndex++;
                        await AppendPageAsync(PageIndex, _cts?.Token ?? CancellationToken.None);
                    }
                };
                UpdateLoadMoreVisibility();
            }

            if (_popup != null)
            {
                // Prevent auto-close when focus momentarily shifts (e.g., arrow at edges)
                _popup.StaysOpen = true;
                _popup.Opened += (_, __) =>
                {
                    if (_ignorePopupSync) return;
                    _ignorePopupSync = true; IsDropDownOpen = true; _ignorePopupSync = false;
                    // Ensure current selection is highlighted / first item selected.
                    EnsureListBoxSelection();

                    // Constrain navigation within popup visual tree
                    if (_popup.Child is UIElement child)
                    {
                        KeyboardNavigation.SetDirectionalNavigation(child, KeyboardNavigationMode.Contained);
                        KeyboardNavigation.SetTabNavigation(child, KeyboardNavigationMode.Contained);
                    }
                };
                _popup.Closed += (_, __) =>
                {
                    if (_ignorePopupSync) return;
                    _ignorePopupSync = true; IsDropDownOpen = false; _ignorePopupSync = false;
                };
                // Swallow edge arrow keys so focus does not leave and popup does not close
                _popup.PreviewKeyDown += Popup_PreviewKeyDown;
                SyncPopupOpenState(IsDropDownOpen);
            }

            if (_listBox != null)
            {
                _listBox.ItemsSource = _currentItems;
                // apply custom item template(s)
                _listBox.ItemTemplate = ItemTemplate;
                _listBox.ItemTemplateSelector = ItemTemplateSelector;

                // Use Contained to prevent focus from leaving and avoid implicit wrapping
                KeyboardNavigation.SetDirectionalNavigation(_listBox, KeyboardNavigationMode.Contained);
                KeyboardNavigation.SetTabNavigation(_listBox, KeyboardNavigationMode.Contained);

                _listBox.MouseLeftButtonUp += (s, e) => CommitSelection();
                _listBox.SelectionChanged += (s, e) =>
                {
                    if (_listBox.SelectedItem is ComboRecord cr)
                    {
                        SelectedId = cr.IdNo;
                        SelectedCode = cr.Code;
                        SelectedName = cr.Name;
                        UpdateSelectedValueFromRecord(cr);
                        _updatingSelectedItem = true;
                        try { SelectedItem = cr.Raw ?? (object)cr; }
                        finally { _updatingSelectedItem = false; }
                    }
                };
                _listBox.Loaded += (_, _) => AttachScrollViewer();
                _listBox.PreviewKeyDown += ListBox_PreviewKeyDown;
            }

            if (_textBox != null)
            {
                _textBox.TextChanged += TextBox_TextChanged;
                _textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
                if (_textBox.Text != Text) _textBox.Text = Text;
            }

            if (_button != null)
            {
                _button.Click += (s, e) =>
                {
                    var text = _textBox?.Text?.Trim() ?? string.Empty;
                    if (!IsDropDownOpen)
                    {
                        // Show all records if ShowAllOnBlank is enabled and textbox is blank
                        if (ShowAllOnBlank && string.IsNullOrEmpty(text))
                        {
                            IsDropDownOpen = true;
                            _ = StartSearchAsync(string.Empty); // triggers search with empty filter
                            return;
                        }
                        if (text.Length < MinSearchLength)
                        {
                            // Do not open; ignore click until threshold met
                            return;
                        }
                        IsDropDownOpen = true;
                        _ = StartSearchAsync(text);
                    }
                    else
                    {
                        IsDropDownOpen = false;
                    }
                };
            }

            BuildLocalMasterFromItemsSource();
            TrySelectBySelectedValue();
            TrySelectBySelectedItem();
        }

        private void SyncPopupOpenState(bool open)
        {
            if (_popup == null) return;
            _ignorePopupSync = true;
            _popup.IsOpen = open;
            _ignorePopupSync = false;
        }

        private void ListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_listBox == null) return;

            int pageSize = EffectivePageSize;
            if (e.Key == Key.Down)
            {
                if (_listBox.SelectedIndex == _currentItems.Count -1)
                {
                    if (HasNextPage)
                    {
                        _pendingPageDown = true;
                        _appendInsertIndex = _currentItems.Count;
                        PageIndex++;
                        e.Handled = true;
                    }
                    else
                    {
                        // At last item, do nothing
                        e.Handled = true;
                    }
                    return;
                }
                if (_listBox.SelectedIndex < _currentItems.Count -1 && _listBox.SelectedIndex >=0)
                {
                    _listBox.SelectedIndex++;
                    _listBox.ScrollIntoView(_listBox.SelectedItem);
                    e.Handled = true;
                    return;
                }
                if (_listBox.SelectedIndex <0 && _currentItems.Count >0)
                {
                    _listBox.SelectedIndex =0;
                    _listBox.ScrollIntoView(_listBox.SelectedItem);
                    e.Handled = true;
                    return;
                }
            }
            else if (e.Key == Key.Up)
            {
                if (_listBox.SelectedIndex <=0 && PageIndex ==0)
                {
                    // Only set selection if not already at0
                    if (_listBox.SelectedIndex !=0 && _currentItems.Count >0)
                    {
                        _listBox.SelectedIndex =0;
                        _listBox.ScrollIntoView(_listBox.SelectedItem);
                    }
                    // Do NOT set focus or scroll again if already at0
                    e.Handled = true;
                    return;
                }
                if (_listBox.SelectedIndex ==0 && PageIndex >0)
                {
                    _pendingPageDown = false;
                    _pendingPageUp = true;
                    PageIndex--;
                    e.Handled = true;
                    return;
                }
                if (_listBox.SelectedIndex >0)
                {
                    _listBox.SelectedIndex--;
                    _listBox.ScrollIntoView(_listBox.SelectedItem);
                    e.Handled = true;
                    return;
                }
            }
            else if (e.Key == Key.PageDown)
            {
                if (_listBox.SelectedIndex == _currentItems.Count -1)
                {
                    if (HasNextPage)
                    {
                        _pendingPageDown = true;
                        _appendInsertIndex = _currentItems.Count;
                        PageIndex++;
                    }
                    e.Handled = true;
                    return;
                }
                int chunk = Math.Max(5, Math.Min(pageSize, _currentItems.Count));
                int target = Math.Min(_currentItems.Count -1, Math.Max(0, _listBox.SelectedIndex) + chunk);
                _listBox.SelectedIndex = target;
                _listBox.ScrollIntoView(_listBox.SelectedItem);
                e.Handled = true;
                return;
            }
            else if (e.Key == Key.PageUp)
            {
                if (_listBox.SelectedIndex <=0)
                {
                    e.Handled = true;
                    return;
                }
                int chunk = Math.Max(5, Math.Min(pageSize, _currentItems.Count));
                int target = Math.Max(0, _listBox.SelectedIndex - chunk);
                _listBox.SelectedIndex = target;
                _listBox.ScrollIntoView(_listBox.SelectedItem);
                e.Handled = true;
                return;
            }
            else if (e.Key == Key.Enter)
            {
                CommitSelection();
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                if (_popup != null)
                    IsDropDownOpen = false;
                if (_textBox != null)
                    _textBox.Focus();
                e.Handled = true;
            }
        }

        private void AttachScrollViewer()
        {
            if (_listBox == null) return;
            _scrollViewer = FindDescendant<ScrollViewer>(_listBox);
            if (_scrollViewer != null)
            {
                if (EnableAutoScrollPaging)
                    _scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
            }
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!EnableAutoScrollPaging) return;
            if (e.VerticalOffset + e.ViewportHeight >= e.ExtentHeight -2)
            {
                if (HasNextPage)
                {
                    _pendingPageDown = true;
                    _appendInsertIndex = _currentItems.Count;
                    PageIndex++;
                }
            }
        }

        private T FindDescendant<T>(DependencyObject root) where T : DependencyObject
        {
            if (root == null) return null;
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is T t) return t;
                var result = FindDescendant<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_popup == null || _listBox == null) return;
            var currentText = _textBox?.Text ?? string.Empty;
            int pageSize = EffectivePageSize;

            if (e.Key == Key.Up)
            {
                if (IsDropDownOpen)
                {
                    _listBox.Focus();
                    if (_listBox.Items.Count >0 && _listBox.SelectedIndex <0)
                        _listBox.SelectedIndex =0;
                    _listBox.ScrollIntoView(_listBox.SelectedItem);
                    e.Handled = true;
                    return;
                }
            }
            else if (e.Key == Key.Down)
            {
                // Only open with Down if threshold met
                if (!IsDropDownOpen)
                {
                    if (!ShouldActivateDropDown(currentText))
                    {
                        e.Handled = true; // swallow to prevent focus jumping
                        return;
                    }
                    IsDropDownOpen = true;
                    _ = StartSearchAsync(currentText);
                }
                if (_listBox.Items.Count >0)
                {
                    _listBox.Focus();
                    // Always highlight first record when entering list from textbox via Down
                    _listBox.SelectedIndex =0;
                    var first = _listBox.SelectedItem as ComboRecord;
                    if (first != null)
                    {
                        SelectedId = first.IdNo;
                        SelectedCode = first.Code;
                        SelectedName = first.Name;
                        UpdateSelectedValueFromRecord(first);
                        _updatingSelectedItem = true;
                        try { SelectedItem = first.Raw ?? (object)first; }
                        finally { _updatingSelectedItem = false; }
                    }
                    _listBox.ScrollIntoView(_listBox.SelectedItem);
                }
                e.Handled = true;
            }
            else if (e.Key == Key.PageDown)
            {
                if (!ShouldActivateDropDown(currentText)) { e.Handled = true; return; }
                if (HasNextPage)
                {
                    _pendingPageDown = true;
                    _appendInsertIndex = _currentItems.Count;
                    PageIndex++;
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.PageUp)
            {
                if (!ShouldActivateDropDown(currentText)) { e.Handled = true; return; }
                if (PageIndex >0)
                {
                    _suppressPageIndexChanged = true;
                    PageIndex--;
                    _suppressPageIndexChanged = false;
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.Enter)
            {
                if (!ShouldActivateDropDown(currentText)) { e.Handled = true; return; }
                CommitSelection();
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                IsDropDownOpen = false;
                e.Handled = true;
            }
        }

        private bool ShouldActivateDropDown(string txt)
        {
            return (txt?.Trim().Length ?? 0) >= MinSearchLength;
        }

        private async Task StartSearchAsync(string filter)
        {
            var old = Interlocked.Exchange(ref _cts, new CancellationTokenSource());
            try { old?.Cancel(); } finally { old?.Dispose(); }
            _forceFirstSelectionOnLoad = true; // next population should select first result
            await RunInitialSearchAsync(filter, _cts.Token);
        }

        private async Task RunInitialSearchAsync(string filter, CancellationToken token = default)
        {
            _pageCache.Clear();
            _currentItems.Clear();

            var trimmed = (filter ?? string.Empty).Trim();
            _lastFilter = trimmed;

            _suppressPageIndexChanged = true;
            PageIndex = 0;
            _suppressPageIndexChanged = false;

            if (token.IsCancellationRequested) return;

            // If below threshold do not populate list, unless ShowAllOnBlank is true and filter is blank
            if (trimmed.Length < MinSearchLength && !(ShowAllOnBlank && string.IsNullOrEmpty(trimmed)))
            {
                HasNextPage = false;
                return;
            }

            await AppendPageAsync(0, token);

            // Ensure first record is selected/highlighted after load
            if (!token.IsCancellationRequested && _listBox != null && _currentItems.Count > 0 && _listBox.SelectedIndex < 0)
            {
                _listBox.SelectedIndex = 0;
                var first = _currentItems[0];
                SelectedId = first.IdNo;
                SelectedCode = first.Code;
                SelectedName = first.Name;
                UpdateSelectedValueFromRecord(first);
                _updatingSelectedItem = true;
                try { SelectedItem = first.Raw ?? (object)first; }
                finally { _updatingSelectedItem = false; }
                _listBox.ScrollIntoView(first);
            }
        }

        private async Task AppendPageAsync(int pageIndex, CancellationToken token = default)
        {
            if (token.IsCancellationRequested) return;

            // abort if current filter below threshold, unless ShowAllOnBlank is true and filter is blank
            if ((_lastFilter ?? string.Empty).Trim().Length < MinSearchLength && !(ShowAllOnBlank && string.IsNullOrEmpty(_lastFilter)))
            {
                HasNextPage = false;
                return;
            }
            // For pages >0 do not auto-select first
            if (pageIndex >0) _forceFirstSelectionOnLoad = false;
            // Decide mode once per call
            bool remote = UseRemoteFetch || (_localMaster.Count ==0 && IsRemoteConfigured) || _localMaster.Count > AutoRemoteThreshold;
            int pageSize = EffectivePageSize;

            if (remote)
            {
                try
                {
                    // Set IsBusy on UI thread before starting async work
                    await Application.Current.Dispatcher.InvokeAsync(() => IsBusy = true);

                    List<ComboRecord> pageData = await FetchFromSqlAsync(_lastFilter, token, pageIndex, pageSize).ConfigureAwait(false);
                    if (token.IsCancellationRequested) return;
                    _pageCache[pageIndex] = pageData;
                    await Application.Current.Dispatcher.InvokeAsync(() => EvictCacheIfNeeded());
                    // back to UI thread
                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        UpdateHasNext(pageIndex, pageData.Count, pageSize);
                        bool appendMode = _pagingDown && pageIndex >0;
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
                // Local filtering; optionally run on background thread
                var filterSnapshot = _lastFilter;
                var indexSnapshot = pageIndex;
                IsBusy = true;

                if (UseBackgroundFiltering)
                {
                    await Task.Run(() =>
                    {
                        var skip = indexSnapshot * pageSize;
                        var result = FilterEngine.FilterPage(_localMaster, filterSnapshot, skip, pageSize);
                        return result;
                    }).ContinueWith(t =>
                    {
                        try
                        {
                            if (token.IsCancellationRequested || filterSnapshot != _lastFilter) return;

                            _totalFilteredCount = t.Result.Total;
                            TotalCount = _totalFilteredCount;
                            var pageDataLocal = t.Result.Page;
                            _pageCache[indexSnapshot] = pageDataLocal;
                            _pageCache[-1] = new List<ComboRecord>();
                            EvictCacheIfNeeded();
                            UpdateHasNext(indexSnapshot, pageDataLocal.Count, pageSize);

                            bool appendMode = _pagingDown && indexSnapshot >0;
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
                    var result = FilterEngine.FilterPage(_localMaster, filterSnapshot, skip, pageSize);
                    _totalFilteredCount = result.Total;
                    TotalCount = _totalFilteredCount;
                    var pageDataLocal = result.Page;
                    _pageCache[indexSnapshot] = pageDataLocal;
                    _pageCache[-1] = new List<ComboRecord>();
                    EvictCacheIfNeeded();
                    UpdateHasNext(indexSnapshot, pageDataLocal.Count, pageSize);
                    bool appendMode = _pagingDown && indexSnapshot >0;
                    if (appendMode) _appendInsertIndex = _currentItems.Count;
                    AppendToCurrent(pageDataLocal, append: appendMode);
                    IsBusy = false;
                }
            }
        }

        /// <summary>
        /// Updates the HasNextPage property based on the current page, number of items, and page size.
        /// </summary>
        /// <param name="pageIndex">The current page index.</param>
        /// <param name="itemCount">The number of items returned for the current page.</param>
        /// <param name="pageSize">The configured page size.</param>
        private void UpdateHasNext(int pageIndex, int itemCount, int pageSize)
        {
            // If the number of items returned equals the page size, assume there may be a next page.
            HasNextPage = itemCount >= pageSize;
            UpdateLoadMoreVisibility();
        }

        private void EnsureListBoxSelection(object previousId = null)
        {
            if (_listBox == null) return;
            if (_currentItems.Count == 0)
            {
                _listBox.SelectedIndex = -1;
                return;
            }

            // Try restore previous by Id
            if (previousId != null)
            {
                var restored = _currentItems.FirstOrDefault(r => EqualsSafe(r.IdNo, previousId));
                if (restored != null)
                {
                    _listBox.SelectedItem = restored;
                    _listBox.ScrollIntoView(restored);
                    return;
                }
            }

            // Keep existing selection if still present
            if (_listBox.SelectedItem is ComboRecord existing && _currentItems.Contains(existing))
            {
                _listBox.ScrollIntoView(existing);
                return;
            }

            // If externally bound SelectedId matches any item select it
            if (SelectedId != null)
            {
                var match = _currentItems.FirstOrDefault(r => EqualsSafe(r.IdNo, SelectedId));
                if (match != null)
                {
                    _listBox.SelectedItem = match;
                    _listBox.ScrollIntoView(match);
                    return;
                }
            }

            // Do NOT force select first item anymore; leave no selection for clarity
            _listBox.SelectedIndex = -1;
        }

        private void AppendToCurrent(IEnumerable<ComboRecord> records, bool append = false)
        {
            object previousId = SelectedId; // try retain selection across refresh

            var newList = records?.ToList() ?? new List<ComboRecord>();

            // If there is nothing to add and not replacing, leave as-is
            if (!append && newList.Count ==0)
            {
                // ensure selection restored
                EnsureListBoxSelection(previousId);
                return;
            }

            // Use BulkObservableCollection operations so the ListBox receives a single Reset notification
            if (!append)
            {
                _currentItems.ReplaceAll(newList);
            }
            else
            {
                // remember where append starts so selection can be restored
                _appendInsertIndex = _currentItems.Count;
                _currentItems.AddRange(newList);
            }

            // After replacing collection, perform selection logic on UI thread and defer ScrollIntoView
            if (_listBox != null && _forceFirstSelectionOnLoad && !append && _currentItems.Count >0)
            {
                var first = _currentItems[0];
                _listBox.SelectedIndex =0;
                SelectedId = first.IdNo;
                SelectedCode = first.Code;
                SelectedName = first.Name;
                UpdateSelectedValueFromRecord(first);
                _updatingSelectedItem = true;
                try { SelectedItem = first.Raw ?? (object)first; }
                finally { _updatingSelectedItem = false; }
                // Defer scrolling to batch layout
                _ = _listBox.Dispatcher.BeginInvoke((Action)(() => _listBox.ScrollIntoView(first)), DispatcherPriority.Background);
                _forceFirstSelectionOnLoad = false; // consumed
                return; // explicit selection done
            }

            // If a pending page-down/up intent exists, ensure selection reflects that immediately
            if (_listBox != null)
            {
                if (_pendingPageDown)
                {
                    var targetIndex = (_appendInsertIndex >=0 && _appendInsertIndex < _currentItems.Count) ? _appendInsertIndex :0;
                    _listBox.SelectedIndex = targetIndex;
                    _listBox.Focus();
                    _ = _listBox.Dispatcher.BeginInvoke((Action)(() => _listBox.ScrollIntoView(_listBox.SelectedItem)), DispatcherPriority.Background);
                    _pendingPageDown = false;
                    _appendInsertIndex = -1;
                }
                else if (_pendingPageUp)
                {
                    _listBox.SelectedIndex = _currentItems.Count -1;
                    _listBox.Focus();
                    _ = _listBox.Dispatcher.BeginInvoke((Action)(() => _listBox.ScrollIntoView(_listBox.SelectedItem)), DispatcherPriority.Background);
                    _pendingPageUp = false;
                }
                else
                {
                    // Defer EnsureListBoxSelection to allow the ItemsSource change to settle
                    _ = _listBox.Dispatcher.BeginInvoke((Action)(() => EnsureListBoxSelection(previousId)), DispatcherPriority.Background);
                }
            }
            else
            {
                EnsureListBoxSelection(previousId);
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

                _updatingSelectedItem = true;
                try {
                    SelectedItem = cr.Raw ?? (object)cr;
                }
                finally { _updatingSelectedItem = false; }

                if (_popup != null)
                    IsDropDownOpen = false;
            }
        }

        private void BuildLocalMasterFromItemsSource()
        {
            _localMaster.Clear();
            if (ItemsSource == null) return;

            foreach (var item in ItemsSource)
            {
                var rec = ComboRecord.FromUnknown(item);
                if (rec != null) _localMaster.Add(rec);
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
            if (path.Equals("IdNo", StringComparison.OrdinalIgnoreCase)) return cr.IdNo;
            if (path.Equals("Code", StringComparison.OrdinalIgnoreCase)) return cr.Code;
            if (path.Equals("Name", StringComparison.OrdinalIgnoreCase)) return cr.Name;

            var raw = cr.Raw;
            if (raw is DataRowView drv && drv.Row.Table.Columns.Contains(path)) return drv[path];
            if (raw is DataRow dr && dr.Table.Columns.Contains(path)) return dr[path];

            if (ReflectionCache.TryGetPropValue(raw, path, out var val)) return val;
            if (ReflectionCache.TryGetPropValue(cr, path, out var selfVal)) return selfVal;
            return null;
        }

        private string GetDisplayText(ComboRecord cr) => cr.Display;

        private void TrySelectBySelectedValue()
        {
            if (_listBox == null) return;
            var path = SelectedValuePath;
            var selVal = SelectedValue;
            if (string.IsNullOrWhiteSpace(path) || selVal == null) { EnsureListBoxSelection(); return; }

            var match = _localMaster.FirstOrDefault(r => EqualsSafe(GetValueByPath(r, path), selVal));
            if (match != null)
            {
                _currentItems.Clear();
                _currentItems.Add(match);
                SelectedId = match.IdNo;
                SelectedCode = match.Code;
                SelectedName = match.Name;
                if (_textBox != null)
                {
                    var display = GetDisplayText(match);
                    _textBox.Text = display;
                    Text = display;
                }
                // keep SelectedItem coherent
                _updatingSelectedItem = true;
                try { SelectedItem = match.Raw ?? (object)match; } finally { _updatingSelectedItem = false; }

                HasNextPage = false;
                EnsureListBoxSelection();
            }
        }

        private void TrySelectBySelectedItem(object sel = null)
        {
            if (_listBox == null) return;
            var target = sel ?? SelectedItem;
            if (target == null) { EnsureListBoxSelection(); return; }

            // try find in current items
            var rec = _currentItems.FirstOrDefault(r => ReferenceEquals(r.Raw, target) || EqualsSafe(r.Raw, target) || EqualsSafe(r.IdNo, GetIdFromUnknown(target)));
            if (rec == null)
            {
                // try find in local master
                rec = _localMaster.FirstOrDefault(r => ReferenceEquals(r.Raw, target) || EqualsSafe(r.Raw, target) || EqualsSafe(r.IdNo, GetIdFromUnknown(target)));
            }

            if (rec != null)
            {
                if (!_currentItems.Contains(rec))
                {
                    _currentItems.Clear();
                    _currentItems.Add(rec);
                }

                _listBox.SelectedItem = rec;
                _listBox.ScrollIntoView(rec);

                SelectedId = rec.IdNo;
                SelectedCode = rec.Code;
                SelectedName = rec.Name;
                UpdateSelectedValueFromRecord(rec);

                if (_textBox != null)
                {
                    var display = GetDisplayText(rec);
                    _textBox.Text = display;
                    Text = display;
                }
            }
        }

        private object GetIdFromUnknown(object obj)
        {
            if (obj == null) return null;
            if (obj is ComboRecord cr) return cr.IdNo;
            if (obj is DataRowView drv)
            {
                try { return drv["IdNo"]; } catch { return null; }
            }
            if (obj is DataRow dr)
            {
                try { return dr["IdNo"]; } catch { return null; }
            }
            var map = ReflectionCache.Get(obj.GetType());
            return map.IdNoProp?.GetValue(obj);
        }

        private bool EqualsSafe(object a, object b) => a == null && b == null || a != null && a.Equals(b);

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_textBox == null) return;
            var text = _textBox.Text ?? string.Empty;
            Text = text;

            // Below threshold: ensure dropdown closed and do not search
            if (!ShouldActivateDropDown(text))
            {
                if (IsDropDownOpen) IsDropDownOpen = false;
                _debounce?.Stop();
                return;
            }

            if (!IsDropDownOpen) IsDropDownOpen = true;

            if (_debounce == null)
            {
                _debounce = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(DebounceMilliseconds) };
                _debounce.Tick += async (_, __) =>
                {
                    _debounce.Stop();
                    int caret = _textBox.CaretIndex; // Save caret position
                    await StartSearchAsync(Text);
                    // Restore focus and caret after filtering
                    _textBox.Focus();
                    _textBox.CaretIndex = Math.Min(caret, _textBox.Text.Length);
                };
            }
            else
            {
                _debounce.Interval = TimeSpan.FromMilliseconds(DebounceMilliseconds);
            }
            _debounce.Stop();
            _debounce.Start();
        }

        private void Popup_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_listBox == null) return;
            if (e.Key == Key.Up)
            {
                if (_listBox.SelectedIndex <= 0)
                {
                    // at very top: keep dropdown open and selection fixed
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.Down)
            {
                if ((_listBox.SelectedIndex >= _currentItems.Count - 1) && !HasNextPage)
                {
                    // at very bottom: keep dropdown open and selection fixed
                    e.Handled = true;
                }
            }
        }

        public void SetError(string message)
        {
            HasError = true;
            ErrorMessage = message;
        }

        public void ClearError()
        {
            HasError = false;
            ErrorMessage = string.Empty;
        }

        private int EffectivePageSize => PageSize >0 ? PageSize : RemoteTake;

        public void ClearPageCache()
        {
            _pageCache.Clear();
            HasNextPage = false;
        }

        private void EvictCacheIfNeeded()
        {
            if (CachePageLimit <=0) return;
            // Exclude special key -1 used for total meta page
            var normalKeys = _pageCache.Keys.Where(k => k >=0).OrderBy(k => k).ToList();
            if (normalKeys.Count <= CachePageLimit) return;
            int removeCount = normalKeys.Count - CachePageLimit;
            foreach (var k in normalKeys.Take(removeCount))
            {
                _pageCache.Remove(k);
            }
        }

        private void UpdateLoadMoreVisibility()
        {
            if (_loadMoreButton == null) return;
            // Show the button only if there is a next page and the dropdown is open
            _loadMoreButton.Visibility = HasNextPage && IsDropDownOpen
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        // Add this method to the SmartComboBox class

        /// <summary>
        /// Asynchronously fetches a page of ComboRecord items from SQL using the configured query template.
        /// </summary>
        /// <param name="filter">The filter string to apply.</param>
        /// <param name="token">Cancellation token.</param>
        /// <param name="pageIndex">The page index to fetch.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <returns>A list of ComboRecord objects.</returns>
        // ... inside SmartComboBox class ...

        private async Task<List<ComboRecord>> FetchFromSqlAsync(string filter, CancellationToken token, int pageIndex, int pageSize)
        {
            var results = new List<ComboRecord>();
            if (!IsRemoteConfigured)
                return results;

            // Build parameterized WHERE clause (only when filter supplied)
            string whereClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                // Wrap OR conditions in parentheses for safety if later combined
                whereClause = $"WHERE ([{FilterCodeField}] LIKE '%' + @Filter + '%' OR [{FilterNameField}] LIKE '%' + @Filter + '%')";
            }

            // Start from template
            string query = SqlQueryTemplate ?? string.Empty;

            // Replace {Where} token if present; otherwise attempt smart insertion before ORDER BY (if filter exists and template lacks any WHERE)
            if (query.Contains("{Where}", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Replace("{Where}", whereClause);
            }
            else if (!string.IsNullOrWhiteSpace(whereClause))
            {
                // If template already has a WHERE we do not inject another; otherwise insert before ORDER BY if possible
                if (!query.Contains(" WHERE ", StringComparison.OrdinalIgnoreCase))
                {
                    int orderByIndex = query.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);
                    if (orderByIndex >=0)
                    {
                        // Insert whereClause right before ORDER BY
                        query = query.Substring(0, orderByIndex).TrimEnd() + " " + whereClause + " " + query.Substring(orderByIndex);
                    }
                    else
                    {
                        // Append at end
                        query = query.TrimEnd() + " " + whereClause;
                    }
                }
            }

            // Support paging tokens: replace {Skip}/{Take} with parameter names if present
            if (query.Contains("{Skip}", StringComparison.OrdinalIgnoreCase))
                query = query.Replace("{Skip}", "@Skip");
            if (query.Contains("{Take}", StringComparison.OrdinalIgnoreCase))
                query = query.Replace("{Take}", "@Take");

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand(query, conn)
                {
                    CommandTimeout =30
                };

                // Add paging parameters even if template may not use them (harmless)
                cmd.Parameters.Add("@Skip", System.Data.SqlDbType.Int).Value = pageIndex * pageSize;
                cmd.Parameters.Add("@Take", System.Data.SqlDbType.Int).Value = pageSize;

                if (!string.IsNullOrWhiteSpace(filter) && query.Contains("@Filter", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.Parameters.Add("@Filter", System.Data.SqlDbType.NVarChar, Math.Max(filter.Length,50)).Value = filter;
                }

                await conn.OpenAsync(token).ConfigureAwait(false);
                using var reader = await cmd.ExecuteReaderAsync(token).ConfigureAwait(false);

                while (await reader.ReadAsync(token).ConfigureAwait(false))
                {
                    if (token.IsCancellationRequested) break;

                    var idNo = reader["IdNo"];
                    var code = reader["Code"] as string ?? string.Empty;
                    var name = reader["Name"] as string ?? string.Empty;

                    var rec = new ComboRecord
                    {
                        IdNo = idNo,
                        Code = code,
                        Name = name,
                        Raw = null // avoid holding onto reader; raw could be a lightweight object if needed
                    };
                    // Display is managed by ComboRecord (assumed) else compute here
                    // rec.Display = !string.IsNullOrEmpty(code) ? $"{code} - {name}" : name; (uncomment if not auto-populated)
                    results.Add(rec);
                }
            }
            catch (Exception ex)
            {
                SetError($"Error fetching data: {ex.Message}");
            }

            return results;
        }
    }
}

