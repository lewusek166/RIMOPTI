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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Excel ex = new Excel();
            ex.CreateNewFileWithTemplate("@C:/Users/Przemysław/source/repos/RimOptiList/RIMOPTI/Data")
        }
    }
}
