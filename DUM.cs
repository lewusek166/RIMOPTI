using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RimOptiList
{
    public partial class DUM : Form
    {
        public DUM()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

             if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
              {
                  MessageBox.Show("Proszę wprowadzać tylko liczby.");
                   textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
              }
        }


        

    }
}
