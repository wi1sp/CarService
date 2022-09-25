using CarService.Code;
using CarService.Code.Enums;
using CarService.Code.Logging;

namespace LB4
{
    public partial class d_newempl : Form
    {
        public delegate void ListLog(object sender, LogEventArgs e);
        public event ListLog AddLog;



        public d_newempl(IWin32Window own)
        {
            InitializeComponent();
            cb_post.SelectedIndex = 0;
        }
        public Employee GetEmployee()
        {
            tb_name.Text = "";
            tb_surname.Text = "";
            tb_age.Text = "";
            tb_teleph.Text = "";
            tb_we.Text = "";
            cb_post.SelectedIndex = 0;
            tb_spec.Text = "";
            dtp_dob.Value = DateTime.Now;
            if (this.ShowDialog() == DialogResult.Cancel)
                return null;
            string date = dtp_dob.Value.ToString("dd.MM.yyyy");
            Employee ret = new Employee(tb_name.Text, tb_surname.Text, int.Parse(tb_age.Text), tb_teleph.Text, tb_we.Text, cb_post.Text, tb_spec.Text, date);
            AddLog?.Invoke(ret, new LogEventArgs(OperType.New));

            return ret;

        }
        private void b_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
