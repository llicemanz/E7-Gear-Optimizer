using System;
using System.Windows.Forms;

namespace E7_Gear_Optimizer
{
    public partial class MultiSelectForm : Form
    {
        public MultiSelectForm(string[] items)
        {
            InitializeComponent();

            listBox1.Items.Clear();
            listBox1.Items.AddRange(items);
            listBox1.Height = listBox1.PreferredHeight;

            Height = listBox1.ItemHeight * items.Length + b_OK.Height + 4;
        }

        public ListBox.SelectedObjectCollection SelectedItems => listBox1.SelectedItems;

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItems.Clear();
            Close();
        }

        private void MultiSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
