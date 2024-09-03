using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2(Personalinfocs p)
        {
            InitializeComponent();
            label6.Text = p.getName();
            label7.Text = Convert.ToString(p.getAge());
            label8.Text = Convert.ToString(p.getContact());
            label9.Text = p.getAddress();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
