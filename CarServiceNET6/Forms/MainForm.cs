using CarServiceNET6.Code;
using CarServiceNET6.Code.Enums;
using CarServiceNET6.Code.Logging;
using System.Xml.Linq;

namespace LB4
{
    public partial class Form1 : Form
    {
        public delegate void ListLog(object sender, LogEventArgs e);
        public event ListLog AddLog;

        public delegate void Update();
        public Update UpdatingInfo;

        delegate Order AddNewOrd();
        AddNewOrd GetOrder;

        Log log;
        MyList<Client> clients;
        MyList<Employee> employees;
        Dictionary<string, Order> listoforders;
        d_newcl cl_dialog;
        d_newempl em_dialog;
        d_neworder no_dialog;
        //f_order f_openorder;

        Thread dcl;
        Thread dem;
        Thread dno;
        //Thread fod;

        public Form1()
        {
            log = new Log();

            UpdatingInfo += Display;

            AddLog += log.AddLog;

            cl_dialog = new d_newcl(this);
            cl_dialog.AddLog += log.AddLog;

            clients = new MyList<Client>();
            clients.SetDel(cl_dialog.GetClient);

            em_dialog = new d_newempl(this);
            em_dialog.AddLog += log.AddLog;
            employees = new MyList<Employee>();
            employees.SetDel(em_dialog.GetEmployee);
            dem = new Thread(employees.AddNew);

            no_dialog = new d_neworder(clients, employees);
            no_dialog.AddLog += log.AddLog;
            GetOrder = no_dialog.GetOrder;

            clients.Updating += Updating;
            employees.Updating += Updating;

            listoforders = new Dictionary<string, Order>();
            InitializeComponent();
            treeView.Nodes.Clear();
        }

        private void Display()
        {
            if (treeView.InvokeRequired)
            {
                Action safeupdate = delegate { Display(); };
                treeView.Invoke(safeupdate);
            }
            else
            {
                int count = 0;
                foreach (var item in listoforders)
                {
                    treeView.Nodes.Clear();
                    treeView.Nodes.Add(item.Key);
                    treeView.Nodes[count].Nodes.Add("Заказчик: " + item.Value.ShowClientInfo());
                    treeView.Nodes[count].Nodes.Add("Машина: " + item.Value.ShowCarInfo());
                    treeView.Nodes[count].Nodes.Add("Ответсвенный: " + item.Value.ShowRespInfo());
                    count++;
                }
            }
        }

        private void AddOrder()
        {
            Thread current = Thread.CurrentThread;


            no_dialog.UpdateData();
            Order newo = GetOrder?.Invoke();
            if (newo == null)
                return;

            listoforders.Add(newo.ToStr(), newo);
            UpdatingInfo?.Invoke();
        }

        private void Updating()
        {
            no_dialog.UpdateData();
        }

        private void b_addnew_Click(object sender, EventArgs e)
        {
            if (dno == null || !dno.IsAlive)
            {
                dno = new Thread(AddOrder);
                dno.Start();
            }
        }

        private void добавтиьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dcl == null || !dcl.IsAlive)
            {
                dcl = new Thread(clients.AddNew);
                dcl.Start();
            }
        }

        private void добавтиьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dem == null || !dem.IsAlive)
            {
                dem = new Thread(employees.AddNew);
                dem.Start();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dno == null || !dno.IsAlive)
            {
                dno = new Thread(AddOrder);
                dno.Start();

            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void b_openorder_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
                return;

            string chosenitem = treeView.SelectedNode.Text;

            if (treeView.SelectedNode.Parent != null)
            {
                chosenitem = treeView.SelectedNode.Parent.Text;
            }

            f_order window = new f_order(listoforders[chosenitem], employees.List);
            window.AddLog += log.AddLog;
            window.Update += Display;
            window.Show();
        }


        private void обновитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XElement saving = new XElement("datasave");

            SaveProcess.Save(ref saving, clients);

            SaveProcess.Save(ref saving, employees);

            XElement OList = new XElement("orders");

            foreach (var item in listoforders)
            {
                SaveProcess.Save(ref OList, item.Value);
            }
            saving.Add(OList);

            SaveFileDialog savedialog = new SaveFileDialog();

            savedialog.Filter = "Xml-файл(*.xml)|*.xml|Все файлы(*.*)|*.*";
            savedialog.Title = "Сохранить данные";
            savedialog.FileName = $"DataSave-{DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss")}";


            if (savedialog.ShowDialog() == DialogResult.Cancel)
                return;

            saving.Save(savedialog.FileName);

            AddLog?.Invoke(saving, new LogEventArgs(OperType.SaveFile, name: savedialog.FileName));

            MessageBox.Show("Файл сохранен");
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Xml-файл(*.xml)|*.xml|Все файлы(*.*)|*.*";
            open.Title = "Сохранить данные";

            if (open.ShowDialog() == DialogResult.Cancel)
                return;

            MessageBox.Show(open.FileName);

            if (open.ShowDialog() == DialogResult.Cancel)
                return;

            XElement save = XElement.Load(open.FileName);

            AddLog?.Invoke(save, new LogEventArgs(OperType.OpenFile, name: open.FileName));

            if (save.Name != "datasave")
                return;

            listoforders = null;
            clients = null;
            employees = null;


            foreach (var elem in save.Elements())
            {
                switch (elem.Name.ToString())
                {
                    case "orders":
                        listoforders = new Dictionary<string, Order>();

                        foreach (var order in elem.Elements("order"))
                        {
                            Order o = (Order)SaveProcess.Load(order);
                            listoforders[o.ToStr()] = o;
                        }

                        break;
                    case "clients":
                        clients = (MyList<Client>)SaveProcess.Load(elem);
                        clients.SetDel(cl_dialog.GetClient);
                        break;
                    case "employees":
                        employees = (MyList<Employee>)SaveProcess.Load(elem);
                        employees.SetDel(em_dialog.GetEmployee);
                        break;
                }
            }

            no_dialog = new d_neworder(clients, employees);
            no_dialog.AddLog += log.AddLog;
            GetOrder = no_dialog.GetOrder;

            clients.Updating += Updating;
            employees.Updating += Updating;

            this.Display();
        }

        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
