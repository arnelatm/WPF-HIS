using System.Net.Security;
using static System.Net.Mime.MediaTypeNames;

namespace Lib2
{
    public partial class TestForm : Form
    {
        // Custom class for managing calls to an external address finder service
        private readonly AddressFinder _addressFinder;

        // Events for handling async calls to address finder service
        private readonly AddressSuggestionsUpdatedEventHandler _addressSuggestionsUpdated;
        private delegate void AddressSuggestionsUpdatedEventHandler(object sender, AddressSuggestionsUpdatedEventArgs e);

        public TestForm()
        {
            InitializeComponent();

            _addressFinder = new AddressFinder(new AddressFinderConfigurationProvider());
            _addressSuggestionsUpdated += AddressSuggestions_Updated;
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                comboBox1_SelectionChangeCommitted(sender, e);
                comboBox1.DroppedDown = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (comboBox1.Items.Count > 0)
                {
                    if (comboBox1.SelectedIndex > 0)
                    {
                        comboBox1.SelectedIndex--;
                    }
                }

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (comboBox1.Items.Count > 0)
                {
                    if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
                    {
                        comboBox1.SelectedIndex++;
                    }
                }

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                comboBox1_SelectionChangeCommitted(sender, e);
                comboBox1.DroppedDown = false;

                textBox1.SelectionStart = textBox1.TextLength;

                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')  // Enter key
            {
                e.Handled = true;
                return;
            }

            if (char.IsControl(e.KeyChar) && e.KeyChar != '\b') // Backspace key
            {
                return;
            }

            if (textBox1.Text.Length > 1)
            {
                Task.Run(() => GetAddressSuggestions(textBox1.Text));
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0 &&
                IsNotNull(comboBox1.SelectedItem) &&
                comboBox1.SelectedItem is KeyValuePair<string, string>)
            {
                var selectedItem = (KeyValuePair<string, string>)comboBox1.SelectedItem;

                textBox1.Text = selectedItem.Value;

                // Do Work with selectedItem
            }
        }

        private async Task GetAddressSuggestions(string searchString)
        {
            var addressSuggestions = await _addressFinder.CompleteAsync(searchString).ConfigureAwait(false);

            if ( IsNotNull(_addressSuggestionsUpdated)) 
            {
                _addressSuggestionsUpdated.Invoke(this, new AddressSuggestionsUpdatedEventArgs(addressSuggestions));
            }
        }

        private void AddressSuggestions_Updated(object sender, AddressSuggestionsUpdatedEventArgs eventArgs)
        {
            try
            {
                ThreadingHelper.BeginUpdate(comboBox1);

                ThreadingHelper.ClearItems(comboBox1);

                if (eventArgs.AddressSuggestions.Count > 0)
                {
                    foreach (var addressSuggestion in eventArgs.AddressSuggestions)
                    {
                        var item = new KeyValuePair<string, string>(addressSuggestion.Key, addressSuggestion.Value.ToUpper());
                        ThreadingHelper.AddItem(comboBox1, item);
                    }

                    ThreadingHelper.SetDroppedDown(comboBox1, true);
                    ThreadingHelper.SetVisible(comboBox1, true);
                }
                else
                {
                    ThreadingHelper.SetDroppedDown(comboBox1, false);
                }
            }
            finally
            {
                ThreadingHelper.EndUpdate(comboBox1);
            }
        }

        private class AddressSuggestionsUpdatedEventArgs : EventArgs
        {
            public IList<KeyValuePair<string, string>> AddressSuggestions { get; }

            public AddressSuggestionsUpdatedEventArgs(IList<KeyValuePair<string, string>> addressSuggestions)
            {
                AddressSuggestions = addressSuggestions;
            }
        }

        public static bool IsNotNull(object obj)
        {
            if (obj == null)
                return true;
            else
                return false;
        }

    }

    internal class ThreadingHelper
    {
        public static string GetText(ComboBox comboBox)
        {
            if (comboBox.InvokeRequired)
            {
                return (string)comboBox.Invoke(new Func<string>(() => GetText(comboBox)));
            }

            lock (comboBox)
            {
                return comboBox.Text;
            }
        }

        public static void SetText(ComboBox comboBox, string text)
        {
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new Action(() => SetText(comboBox, text)));
                return;
            }

            lock (comboBox)
            {
                comboBox.Text = text;
            }
        }

        public static void EndUpdate(ComboBox comboBox)
        {
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new Action(() => EndUpdate(comboBox)));
                return;
            }

            lock (comboBox)
            {
                comboBox.EndUpdate();

            }
        }

        public static void BeginUpdate(ComboBox comboBox)
        {
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new Action(() => BeginUpdate(comboBox)));
                return;
            }

            lock (comboBox)
            {
                comboBox.BeginUpdate();

            }
        }

        public static void ClearItems(ComboBox comboBox)
        {
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new Action(() => ClearItems(comboBox)));
                return;
            }

            lock (comboBox)
            {
                comboBox.Items.Clear();
            }
        }

        public static void AddItem(ComboBox comboBox, object item)
        {
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new Action(() => AddItem(comboBox, item)));
                return;
            }

            lock (comboBox)
            {
                comboBox.Items.Add(item);
            }
        }

        public static void SetVisible(ComboBox comboBox, bool visible)
        {
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new Action(() => SetVisible(comboBox, visible)));
                return;
            }

            lock (comboBox)
            {
                comboBox.Visible = visible;
            }
        }


        public static void SetDroppedDown(ComboBox comboBox, bool dropDown)
        {
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new Action(() => SetDroppedDown(comboBox, dropDown)));
                return;
            }

            lock (comboBox)
            {
                comboBox.DroppedDown = dropDown;
            }
        }



    }






}