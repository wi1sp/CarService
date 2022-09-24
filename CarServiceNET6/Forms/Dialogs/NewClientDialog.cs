using CarServiceNET6.Code;
using CarServiceNET6.Code.Enums;
using CarServiceNET6.Code.Logging;

namespace LB4
{
    public partial class d_newcl : Form
    {
        IWin32Window owner;
        public delegate void ListLog(object sender, LogEventArgs e);
        public event ListLog AddLog;

        public d_newcl(IWin32Window own)
        {
            InitializeComponent();
            owner = own;
        }

        public Client GetClient()
        {
            tb_name.Text = "";
            tb_surname.Text = "";
            tb_age.Text = "";
            tb_teleph.Text = "";
            tb_email.Text = "";
            tb_adress.Text = "";
            dtp_dob.Value = DateTime.Now;
            if (this.ShowDialog() == DialogResult.Cancel)
                return null;
            string date = dtp_dob.Value.ToString("dd.MM.yyyy");

            Client ret = new Client(tb_name.Text, tb_surname.Text, int.Parse(tb_age.Text), tb_teleph.Text, tb_email.Text, tb_adress.Text, date);
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
