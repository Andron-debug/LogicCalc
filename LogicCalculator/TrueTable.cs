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
    public partial class TrueTable : Form
    {
        LogicCalculator lc;
        List<char> vars;
        public TrueTable(string input, int type)
        {
            InitializeComponent();
            vars = new List<char>();
            lc = new LogicCalculator(input, type);
            for(int i = 97; i <= 104; i++)
            {
                if (input.Contains((char)i)) vars.Add((Char)i);
            }
        }

        private void TrueTable_Load(object sender, EventArgs e)
        {
            foreach (char c in vars)
                result_textBox.Text += c + " ";
            result_textBox.Text += Environment.NewLine;
            int end;
            if (vars.Count == 1) end = 1;
            else end = vars.Count * vars.Count - 2;
            for (int i = 0; i <= end; i++)
            {
                Dictionary<char, bool> row = LogicCalculator.Row(vars, i);
                foreach(char c in vars)
                    if(row[c])
                        result_textBox.Text += 1 + " ";
                    else
                        result_textBox.Text += 0 + " ";
                bool result = lc.Calculate(row);
                if(result)
                    result_textBox.Text += 1;
                else
                    result_textBox.Text += 0;
                result_textBox.Text += Environment.NewLine;
            }
        }
    }
}
