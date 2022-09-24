using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarService;

namespace LB4
{
    public partial class d_newcar : Form
    {
        Car newcar;
        public d_newcar()
        {
            InitializeComponent();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            newcar = new Car(tb_name.Text, tb_cat.Text, tb_num.Text, numud_weight.Value);
            DialogResult = DialogResult.OK;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Car NewCar
        {
            get { return newcar; }
        }
    }
}
