using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace YourNamespace.Controls
{
    [TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_ListBox", Type = typeof(ListBox))]
    [TemplatePart(Name = "PART_Button", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
    [TemplatePart(Name = "PART_Arrow", Type = typeof(System.Windows.Shapes.Path))]
    public class SmartComboBox : Control
    {
        private TextBox _textBox;
        private ListBox _listBox;
        private Button _button;
        private Popup _popup;
        private System.Windows.Shapes.Path _arrow;

        static SmartComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SmartComboBox),
                new FrameworkPropertyMetadata(typeof(SmartComboBox)));
        }

        public SmartComboBox()
        {
            Loaded += SmartComboBox_Loaded;
        }

        private void SmartComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _textBox = GetTemplateChild("PART_TextBox") as TextBox;
            _listBox = GetTemplateChild("PART_ListBox") as ListBox;
            _button = GetTemplateChild("PART_Button") as Button;
            _popup = GetTemplateChild("PART_Popup") as Popup;
            _arrow = GetTemplateChild("PART_Arrow") as System.Windows.Shapes.Path;

            if (_textBox != null)
            {
                _textBox.TextChanged += TextBox_TextChanged;
                _textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
            }

            if (_button != null)
                _button.Click += Button_Click;

            if (_listBox != null)
            {
                _listBox.MouseLeftButtonUp += (s, e) => CommitSelection();
                _listBox.SelectionChanged += (s, e) =>
                {
                    if (_listBox.SelectedIndex >= 0)
                        SelectedItem = _listBox.SelectedItem;
                };
            }

            if (_popup != null)
            {
                _popup.Opened += (s, e) => AnimatePopup(true);
                _popup.Closed += (s, e) => AnimatePopup(false);
            }
        }

        #region Dependency Properties

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable),
                typeof(SmartComboBox), new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object),
                typeof(SmartComboBox), new PropertyMetadata(null));

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string),
                typeof(SmartComboBox), new PropertyMetadata(string.Empty));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(nameof(Placeholder), typeof(string),
                typeof(SmartComboBox), new PropertyMetadata("Type to search..."));

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_popup == null) return;

            if (_popup.IsOpen)
                _popup.IsOpen = false;
            else
            {
                _listBox.ItemsSource = ItemsSource;
                _popup.IsOpen = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = _textBox.Text;
            UpdatePlaceholderVisibility();

            if (ItemsSource == null) return;

            var filtered = ItemsSource.Cast<object>()
                .Where(x => x.ToString().IndexOf(Text, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            _listBox.ItemsSource = filtered;
            _popup.IsOpen = filtered.Any();
        }

        private void UpdatePlaceholderVisibility()
        {
            var placeholder = GetTemplateChild("PART_Placeholder") as TextBlock;
            if (placeholder != null)
                placeholder.Visibility = string.IsNullOrEmpty(Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_listBox == null || !_popup.IsOpen)
                return;

            if (e.Key == Key.Down)
            {
                _listBox.Focus();
                _listBox.SelectedIndex = Math.Min(_listBox.SelectedIndex + 1, _listBox.Items.Count - 1);
                _listBox.ScrollIntoView(_listBox.SelectedItem);
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                _listBox.SelectedIndex = Math.Max(_listBox.SelectedIndex - 1, 0);
                _listBox.ScrollIntoView(_listBox.SelectedItem);
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                CommitSelection();
                e.Handled = true;
            }
        }

        private void CommitSelection()
        {
            if (_listBox?.SelectedItem != null)
            {
                Text = _listBox.SelectedItem.ToString();
                SelectedItem = _listBox.SelectedItem;
                _popup.IsOpen = false;
            }
        }

        private void AnimatePopup(bool opening)
        {
            if (_popup?.Child is not FrameworkElement child) return;

            child.RenderTransform ??= new TranslateTransform();
            var fade = new DoubleAnimation(opening ? 0 : 1, opening ? 1 : 0, TimeSpan.FromMilliseconds(150));
            var slide = new DoubleAnimation(opening ? -5 : 0, opening ? 0 : -5, TimeSpan.FromMilliseconds(150));
            child.BeginAnimation(OpacityProperty, fade);
            (child.RenderTransform as TranslateTransform)?.BeginAnimation(TranslateTransform.YProperty, slide);

            AnimateArrow(opening);
        }

        private void AnimateArrow(bool opening)
        {
            if (_arrow == null) return;

            var transform = _arrow.RenderTransform as RotateTransform ?? new RotateTransform(0);
            if (transform.IsFrozen)
                transform = transform.CloneCurrentValue();

            _arrow.RenderTransform = transform;
            var anim = new DoubleAnimation(opening ? 0 : 180, opening ? 180 : 0, TimeSpan.FromMilliseconds(180))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };
            transform.BeginAnimation(RotateTransform.AngleProperty, anim);
        }
    }
}
