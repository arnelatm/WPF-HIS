using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComboboxWithSearch
{
	public partial class Form1 : Form
	{
		string[] collections;
		public Form1()
		{
			InitializeComponent();
			collections = new string[] { "William James", "Robin Hood", "David Copperfield", "Albert Einstein",
							 "Me", "You", "Richard D. Feynman", "David Beckham", "Fermi", "Someone somewhere"};
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			comboBox1.Items.AddRange(collections);
			comboBox1.SelectedIndex = 0;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBox1.SelectedItem = listBox1.SelectedItem;
			listBox1.Visible = false;
		}

		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
			// get the keyword to search
			string textToSearch = comboBox1.Text.ToLower();
			listBox1.Visible = false; // hide the listbox, see below for why doing that
			if (String.IsNullOrEmpty(textToSearch))
				return; // return with listbox's Visible set to false if the keyword is empty
			//search
			string[] result = (from i in collections
								   where i.ToLower().Contains(textToSearch)
								   select i).ToArray();
			if (result.Length == 0)
				return; // return with listbox's Visible set to false if nothing found

			listBox1.Items.Clear(); // remember to Clear before Add
			listBox1.Items.AddRange(result);
			listBox1.Visible = true; // show the listbox again
		}
	}
}
