using CarService.Code;
using CarService.Code.Enums;
using CarService.Code.Logging;

namespace LB4
{
    public partial class f_order : Form
    {
        Order Order;
        List<Employee> employees;
        public delegate void ListLog(object sender, LogEventArgs e);
        public delegate void Refreshing();

        public event ListLog AddLog;
        public event Refreshing Update;

        public f_order(Order order, List<Employee> empl)
        {
            employees = empl;
            Order = order;

            this.Text = String.Format("Заказ №{0} за {1}", order.Id, order.Deal);
            InitializeComponent();

            foreach (var item in employees)
            {
                cb_epls.Items.Add(item.ToStr());
            }
            cb_epls.SelectedIndex = 0;

            tb_price.Text = order.Price.ToString();
            tb_deal.Text = order.Deal;
            rtb_desc.Text = order.Description;

            string status;
            if (order.Begin == "")
            {
                status = "На обработке";
            }
            else if (order.End != "")
            {
                b_status.Enabled = false;
                status = "Выполнен";
            }
            else
            {
                status = "В процессе";
            }

            tb_status.Text = status;

            tb_name.Text = order.Customer.Name;
            tb_surname.Text = order.Customer.SurName;
            tb_age.Text = order.Customer.Age.ToString();
            tb_teleph.Text = order.Customer.Telephone;
            tb_email.Text = order.Customer.Email;

            tb_carname.Text = order.Car.Name;
            tb_carcat.Text = order.Car.Category;
            tb_carnum.Text = order.Car.Number;

            if (order.Responsible != null)
            {
                p_setempl.Visible = false;
                p_empl.Visible = true;
                tb_emplname.Text = order.Responsible.Name;
                tb_emplsur.Text = order.Responsible.SurName;
                tb_post.Text = order.Responsible.Post;
                tb_spec.Text = order.Responsible.Specialization;
            }
            else
            {
                p_setempl.Visible = true;
                p_empl.Visible = false;
            }

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_status_Click(object sender, EventArgs e)
        {
            string message;
            Order.ChangeStatus(out message);

            if (message != "none")
            {
                MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK);
            }
            else
            {
                string status;
                if (Order.Begin == "")
                {
                    status = "На обработке";
                }
                else if (Order.End != "")
                {
                    status = "Выполнен";
                    AddLog?.Invoke(Order, new LogEventArgs(OperType.Changed, subinfo: $"Status: Complete EoW: {Order.End}"));
                    Update?.Invoke();
                }
                else
                {
                    status = "В процессе";
                    AddLog?.Invoke(Order, new LogEventArgs(OperType.Changed, subinfo: $"Status: In progress BoW: {Order.Begin}"));
                    Update?.Invoke();
                }

                tb_status.Text = status;
                b_status.Enabled = false;
            }
        }

        private void b_setempl_Click(object sender, EventArgs e)
        {
            if (cb_epls.SelectedIndex != 0)
            {
                AddLog?.Invoke(Order, new LogEventArgs(OperType.Changed, subinfo: $"Responsible: {employees[cb_epls.SelectedIndex - 1].ToStr(InfoType.Full)}"));
                Update?.Invoke();
                Order.SetEmployee(employees[cb_epls.SelectedIndex - 1]);
                p_setempl.Visible = false;
                p_empl.Visible = true;
                tb_emplname.Text = Order.Responsible.Name;
                tb_emplsur.Text = Order.Responsible.SurName;
                tb_post.Text = Order.Responsible.Post;
                tb_spec.Text = Order.Responsible.Specialization;
            }
        }
    }
}
