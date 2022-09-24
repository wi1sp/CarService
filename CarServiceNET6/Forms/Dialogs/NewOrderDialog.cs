using CarServiceNET6.Code;
using CarServiceNET6.Code.Enums;
using CarServiceNET6.Code.Logging;

namespace LB4
{
    public partial class d_neworder : Form
    {
        public delegate void ListLog(object sender, LogEventArgs e);
        public event ListLog AddLog;

        Car inordercar;
        MyList<Client> _clients;
        MyList<Employee> _employees;
        public d_neworder(MyList<Client> clients, MyList<Employee> employees)
        {
            InitializeComponent();
            _clients = clients;
            _employees = employees;

            cb_clients.Items.Add("Не выбран");
            foreach (var item in clients.List)
            {
                cb_clients.Items.Add(item.ToStr());
            }
            cb_clients.SelectedIndex = 0;

            cb_empl.Items.Add("Не назначен");
            foreach (var item in employees.List)
            {
                cb_empl.Items.Add(item.ToStr());
            }
            cb_empl.SelectedIndex = 0;
        }

        public void UpdateData()
        {
            if (this.Visible == false)
                return;

            if (cb_clients.InvokeRequired)
            {
                Action safeupdate = delegate { UpdateData(); };
                cb_clients.Invoke(safeupdate);
            }
            else
            {
                cb_clients.Items.Clear();
                cb_clients.Items.Add("Не выбран");
                foreach (var item in _clients.List)
                {
                    cb_clients.Items.Add(item.ToStr());
                }
                cb_clients.SelectedIndex = 0;
            }

            if (cb_clients.InvokeRequired)
            {
                Action safeupdate = delegate { UpdateData(); };
                cb_clients.Invoke(safeupdate);
            }
            else
            {
                cb_empl.Items.Clear();
                cb_empl.Items.Add("Не назначен");
                foreach (var item in _employees.List)
                {
                    cb_empl.Items.Add(item.ToStr());
                }

                cb_empl.SelectedIndex = 0;
            }
        }

        public Order GetOrder()
        {
            UpdateData();
            tb_carname.Text = "";
            rtb_desc.Text = "";
            numud_price.Value = 0;

            if (this.ShowDialog() == DialogResult.Cancel)
                return null;

            Order neworder = new Order(inordercar, _clients.List[cb_clients.SelectedIndex - 1], (int)numud_price.Value, rtb_desc.Text);

            if (cb_empl.SelectedIndex != 0)
            {
                neworder.SetEmployee(_employees.List[cb_empl.SelectedIndex - 1]);
            }

            AddLog?.Invoke(neworder, new LogEventArgs(OperType.New));

            return neworder;
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            if (cb_clients.SelectedIndex == 0)
            {
                MessageBox.Show("Не указан заказчик", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb_carname.Text == "Не выбрана")
            {
                MessageBox.Show("Не указана машина", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void b_setcar_Click(object sender, EventArgs e)
        {
            d_newcar dialog = new d_newcar();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                inordercar = dialog.NewCar;
                tb_carname.Text = inordercar.ToStr();
                AddLog?.Invoke(inordercar, new LogEventArgs(OperType.New));
            }
        }
    }
}
