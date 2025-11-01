using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace YourNamespace
{
    public partial class FilteredComboBox : UserControl
    {
        private List<string> _items = new();
        private int _currentIndex = -1;

        public IEnumerable<string> ItemsSource
        {
            get => _items;
            set
            {
                _items = value?.ToList() ?? new List<string>();
                listBoxSuggestions.ItemsSource = _items;
            }
        }

        public string Text
        {
            get => txtFilter.Text;
            set => txtFilter.Text = value;
        }

        public FilteredComboBox()
        {
            InitializeComponent();
            txtPlaceholder.Visibility = Visibility.Visible;
        }

        // --- Text Changed Filtering ---
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPlaceholder.Visibility = string.IsNullOrEmpty(txtFilter.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;

            var filtered = _items
                .Where(i => i.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            listBoxSuggestions.ItemsSource = filtered;
            popupSuggestions.IsOpen = filtered.Any();
            if (popupSuggestions.IsOpen)
                _currentIndex = -1;
        }

        // --- Keyboard Control ---
        private void txtFilter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!popupSuggestions.IsOpen && e.Key == Key.Down)
            {
                if (_items.Count > 0)
                {
                    listBoxSuggestions.ItemsSource = _items;
                    popupSuggestions.IsOpen = true;
                }
                e.Handled = true;
                return;
            }

            if (popupSuggestions.IsOpen)
            {
                if (e.Key == Key.Down)
                {
                    if (_currentIndex < listBoxSuggestions.Items.Count - 1)
                        _currentIndex++;
                    UpdateSelection();
                    e.Handled = true;
                }
                else if (e.Key == Key.Up)
                {
                    if (_currentIndex > 0)
                        _currentIndex--;
                    UpdateSelection();
                    e.Handled = true;
                }
                else if (e.Key == Key.Enter)
                {
                    CommitSelection();
                    e.Handled = true;
                }
                else if (e.Key == Key.Escape)
                {
                    popupSuggestions.IsOpen = false;
                    e.Handled = true;
                }
            }
        }

        private void UpdateSelection()
        {
            if (_currentIndex >= 0 && _currentIndex < listBoxSuggestions.Items.Count)
            {
                listBoxSuggestions.SelectedIndex = _currentIndex;
                listBoxSuggestions.ScrollIntoView(listBoxSuggestions.SelectedItem);
            }
        }

        private void CommitSelection()
        {
            if (listBoxSuggestions.SelectedItem is string selected)
            {
                txtFilter.Text = selected;
                popupSuggestions.IsOpen = false;
                txtFilter.CaretIndex = txtFilter.Text.Length;
                txtFilter.Focus();
            }
        }

        private void listBoxSuggestions_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CommitSelection();
        }

        private void listBoxSuggestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentIndex = listBoxSuggestions.SelectedIndex;
        }

        private void txtFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholder.Visibility = string.IsNullOrEmpty(txtFilter.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void txtFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!popupSuggestions.IsOpen && string.IsNullOrEmpty(txtFilter.Text))
                txtPlaceholder.Visibility = Visibility.Visible;
        }

        private void btnDropdown_Click(object sender, RoutedEventArgs e)
        {
            if (popupSuggestions.IsOpen)
                popupSuggestions.IsOpen = false;
            else
            {
                listBoxSuggestions.ItemsSource = _items;
                popupSuggestions.IsOpen = _items.Any();
            }
        }

        // --- Popup Animations ---
        private void PopupSuggestions_Opened(object sender, EventArgs e)
        {
            popupBorder.RenderTransform ??= new TranslateTransform();

            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(160))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            var slideDown = new DoubleAnimation(-5, 0, TimeSpan.FromMilliseconds(160))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            popupBorder.BeginAnimation(OpacityProperty, fadeIn);
            (popupBorder.RenderTransform as TranslateTransform)?.BeginAnimation(TranslateTransform.YProperty, slideDown);
            AnimateArrowRotation(0, 180);
        }

        private void PopupSuggestions_Closed(object sender, EventArgs e)
        {
            popupBorder.RenderTransform ??= new TranslateTransform();

            var fadeOut = new DoubleAnimation(popupBorder.Opacity, 0, TimeSpan.FromMilliseconds(130))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };
            var slideUp = new DoubleAnimation(0, -5, TimeSpan.FromMilliseconds(130))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };

            popupBorder.BeginAnimation(OpacityProperty, fadeOut);
            (popupBorder.RenderTransform as TranslateTransform)?.BeginAnimation(TranslateTransform.YProperty, slideUp);
            AnimateArrowRotation(180, 0);
        }

        // --- Arrow rotation fix ---
        private Path? GetArrowPath()
        {
            return btnDropdown.Template.FindName("arrowPath", btnDropdown) as Path;
        }

        private void AnimateArrowRotation(double fromAngle, double toAngle)
        {
            var arrow = GetArrowPath();
            if (arrow == null) return;

            var originalTransform = arrow.RenderTransform as RotateTransform;
            if (originalTransform == null) return;

            if (originalTransform.IsFrozen)
            {
                var clone = originalTransform.CloneCurrentValue();
                arrow.RenderTransform = clone;
                originalTransform = clone;
            }

            var anim = new DoubleAnimation
            {
                From = fromAngle,
                To = toAngle,
                Duration = TimeSpan.FromMilliseconds(180),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            originalTransform.BeginAnimation(RotateTransform.AngleProperty, anim);
        }
    }
}
