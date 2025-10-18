using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using AATM.Contracts.Dtos;
using AATM.App.HisWpf.ViewModels;

namespace AATM.App.HisWpf
{
    public partial class UserWindow : Window
    {
        private UserViewModel ViewModel => (UserViewModel)DataContext;

        public UserWindow(UserViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;

            btnFirst.Click += BtnFirst_Click;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnLast.Click += BtnLast_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnFind.Click += BtnFind_Click;
            btnResetFilter.Click += BtnResetFilter_Click;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            UpdateRecordIndicators();
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Users.Count > 0)
                ViewModel.SelectedUser = ViewModel.Users[0];
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser);
            if (idx > 0)
                ViewModel.SelectedUser = ViewModel.Users[idx - 1];
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser);
            if (idx < ViewModel.Users.Count - 1)
                ViewModel.SelectedUser = ViewModel.Users[idx + 1];
        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Users.Count > 0)
                ViewModel.SelectedUser = ViewModel.Users[ViewModel.Users.Count - 1];
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool canExecute = ViewModel.SaveCommand.CanExecute(null);
            if (canExecute)
            {
                ViewModel.SaveCommand.Execute(null);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.DeleteCommand.CanExecute(null))
                ViewModel.DeleteCommand.Execute(null);
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter text to filter:", "Filter Users");
            if (string.IsNullOrWhiteSpace(input))
                return;

            ApplyFilter(input.Trim());
        }

        private void BtnResetFilter_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilter(null);
        }

        private void ApplyFilter(string? term)
        {
            var view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (view == null) return;

            if (string.IsNullOrWhiteSpace(term))
            {
                view.Filter = null;
            }
            else
            {
                var t = term.Trim();
                view.Filter = o =>
                {
                    if (o is null) return false;
                    string GetString(Func<UserDto, object?> sel)
                    {
                        try { var v = sel((UserDto)o); return v?.ToString() ?? string.Empty; }
                        catch { return string.Empty; }
                    }

                    return GetString(x => x.IdNo).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.UserName).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.UserCode).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.FullName).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.FullNameAra).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.EmployeeIdNo).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.SecurityGroupIdNo).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.SecurityLevel).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.Active).IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0;
                };
            }

            view.Refresh();

            if (dataGrid.Items.Count > 0)
            {
                var first = dataGrid.Items[0];
                dataGrid.SelectedItem = first;
                dataGrid.ScrollIntoView(first);
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.SelectedUser))
            {
                if (ViewModel.SelectedUser != null)
                {
                    dataGrid.SelectedItem = ViewModel.SelectedUser;
                    dataGrid.ScrollIntoView(ViewModel.SelectedUser);
                }
                UpdateRecordIndicators();
            }
            if (e.PropertyName == nameof(ViewModel.Users))
            {
                UpdateRecordIndicators();
            }
        }

        private void UpdateRecordIndicators()
        {
            var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser);
            txtCurrentRecord.Text = (idx >= 0 ? (idx + 1).ToString() : "0");
            txtRecordCount.Text = ViewModel.Users.Count.ToString();
        }
    }
}