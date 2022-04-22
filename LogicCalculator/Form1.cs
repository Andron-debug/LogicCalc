using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Dictionary<char, bool> values = new Dictionary<char, bool>(); 
        private void Form1_Load(object sender, EventArgs e)
        {
            typeComboBox.SelectedIndex = 0;
            for (int i = 97; i <=104; i++) 
                values.Add((char)i, false);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text.Length != 0)
                input_textBox.Text = input_textBox.Text.Substring(0, input_textBox.Text.Length - 1);
        }

        private void inputClick(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            input_textBox.Text += bt.Text;
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            input_textBox.Text = "";
            resultTextBox.Text = "";
        }

        private void valueChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            values[cb.Text[0]] = cb.Checked;
        }


        private void calc_button_Click(object sender, EventArgs e)
        {
            try
            {
                LogicCalculator lc = new LogicCalculator(input_textBox.Text, typeComboBox.SelectedIndex);
                resultTextBox.Text = lc.Calculate(values).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void true_table_button_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new TrueTable(input_textBox.Text, typeComboBox.SelectedIndex);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void about_button_Click(object sender, EventArgs e)
        {
            Form f = new About();
            f.ShowDialog();
        }
    }
}
