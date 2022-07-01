using System;
using System.Xml.Linq;
using Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarService
{
    static class SaveProcess
    {
        public static void Save(ref XElement save, ISaveable elem)
        {
            save.Add(elem.Save());
        }

        public static ISaveable Load(XElement save)
        {
            string name = save.Name.ToString();

            ISaveable item = null;

            switch (name)
            {
                case "car":
                    item = new Car();
                    item.Load(save);
                    break;
                case "empl":
                    item = new Employee();
                    item.Load(save);
                    break;
                case "client":
                    item = new Client();
                    item.Load(save);
                    break;
                case "order":
                    item = new Order();
                    item.Load(save);
                    break;
                case "clients":
                    item = new MyList<Client>();
                    item.Load(save);
                    break;
                case "employees":
                    item = new MyList<Employee>();
                    item.Load(save);
                    break;
            }
            
            return item;
        }
    }
    public class Car: ISaveable
    {
        static int count = 0;

        protected int id;
        protected string name;
        protected string category;
        protected string number;
        protected decimal weight;

        delegate void Serialize(string sign, string value);
        delegate string DisSerialize(string sign);

        public Car(string _name, string _categ, string _num, decimal _weight)
        {
            id = ++count;
            Name = _name;
            Category = _categ;
            Number = _num;
            Weight = _weight;
        }

        public Car()
        {
            id = -1;
            Weight = -1;
            Name = Category = Number = "###";
        }

        #region Properties
        public int Id
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public string Category
        {
            get { return category; }
            private set { category = value; }
        }
        public string Number
        {
            get { return number; }
            private set { number = value; }
        }
        public decimal Weight
        {
            get { return weight; }
            private set { weight = value; }
        }
        #endregion

        public virtual string ToStr()
        {
            return String.Format("{0} {1} {2}",Name,Category,Number);
        }

        public override string ToString()
        {
            return "Car: " + ToStr();
        }

        public XElement Save()
        {
            count++;
            XElement ret = new XElement("car");
            Serialize ser = (s1,s2) => ret.Add(new XAttribute(s1, s2));

            ser("id", Id.ToString());
            ser("name", Name);
            ser("category", Category);
            ser("number", Number);
            ser("weight", Weight.ToString());

            return ret;
        }

        public void Load(XElement save)
        {
            DisSerialize dis = (s1) => save.Attribute(s1).Value;
            id = int.Parse(dis("id"));
            Name = dis("name");
            Category = dis("category");
            Number = dis("number");
            Weight = int.Parse(dis("weight"));
        }
    }

    public class Person
    {
        static int count = 0;

        protected int id;
        protected string name;
        protected string surname;
        protected int age;
        protected string dateofbirth;
        protected string telephone;

        public Person(string _name, string _surname, int _age, string _telephone, string _dateofbirth)
        {
            id = ++count;
            name = _name;
            surname = _surname;
            age = _age;
            telephone = _telephone;
            dateofbirth = _dateofbirth;
        }
        public Person()
        {
            count++;
            id = age = -1;
            name = surname = telephone = "###";
        }

        #region Properties
        public int Id
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
        }
        public string SurName
        {
            get { return surname; }
        }
        public int Age
        {
            get { return age; }
        }
        public string DateOfBirth
        {
            get { return dateofbirth; }
        }
        public string Telephone
        {
            get { return telephone; }
        }
        #endregion
    }

    public class Client: Person, IPerson
    {
        protected string email;
        protected string adress;

        delegate void Serialize(string sign, string value);
        delegate string DisSerialize(string sign);

        public Client(string _name, string _surname, int _age,string _telephone, string _email, string _adress, string _dateofbirth) :
            base(_name,_surname,_age,_telephone,_dateofbirth)
        {
            email = _email;
            adress = _adress;
        }

        public Client()
        {

        }

        #region Properties
        public string Adress
        {
            get { return adress; }
        }
        public string Email
        {
            get { return email; }
        }
        #endregion

        public string ToStr(InfoType type = InfoType.Short)
        {
            switch (type)
            {
                case InfoType.Short:
                    return String.Format("{0} {1} {2}", Name, SurName, Email);

                case InfoType.Full:
                    return String.Format("{0} {1} / {2} {3}", Name, SurName, Email, Adress);
            }
            return String.Format("{0} {1} {2}", Name, SurName, Email);
        }

        public override string ToString()
        {
            return "Client: " + ToStr();
        }

        public XElement Save()
        {
            XElement ret = new XElement("client");

            Serialize ser = (s1, s2) => ret.Add(new XAttribute(s1, s2));

            ser("id", Id.ToString());
            ser("name", Name);
            ser("surname", SurName);
            ser("age", Age.ToString());
            ser("telephone", Telephone);
            ser("email", Email);
            ser("adress", Adress);
            ser("dob", DateOfBirth);

            return ret;
        }

        public void Load(XElement save)
        {
            DisSerialize dis = (s1) => save.Attribute(s1).Value;

            id = int.Parse(dis("id"));
            name = dis("name");
            surname = dis("surname");
            age = int.Parse(dis("age"));
            telephone = dis("telephone");
            email = dis("email");
            adress = dis("adress");
            dateofbirth = dis("dob");
        }
    }

    public class Employee: Person, IPerson
    {
        protected string post;
        protected string workemail;
        protected string specialization;

        delegate void Serialize(string sign, string value);
        delegate string DisSerialize(string sign);

        public Employee(string _name, string _surname, int _age, string _telephone, string _workemail, string _post, string _specialization, string _dateofbirth) :
            base(_name,_surname,_age,_telephone,_dateofbirth)
        {
            post = _post;
            workemail = _workemail;
            specialization = _specialization;
        }

        public Employee()
        {

        }

        #region Properties
        public string Post
        {
            get { return post; }
        }
        public string Workemail
        {
            get { return workemail; }
        }
        public string Specialization
        {
            get { return specialization; }
        }
        #endregion

        public string ToStr(InfoType type = InfoType.Short)
        {
            switch(type)
            {
                case InfoType.Short:
                    return String.Format("{0} {1} {2}", Name, SurName, Post);
                    
                case InfoType.Full:
                    return String.Format("{0} {1} / {2} {3} {4}", Name, SurName, Post, Specialization,Workemail);
            }
            return String.Format("{0} {1} {2}", Name, SurName, Post);
        }

        public override string ToString()
        {
            return "Employee: " + ToStr();
        }

        public XElement Save()
        {
            XElement ret = new XElement("empl");

            Serialize ser = (s1, s2) => ret.Add(new XAttribute(s1, s2));

            ser("id", Id.ToString());
            ser("name", Name);
            ser("surname", SurName);
            ser("age", Age.ToString());
            ser("telephone", Telephone);
            ser("post", Post);
            ser("workemail", Workemail);
            ser("specialization", Specialization);
            ser("dob", DateOfBirth);

            return ret;
        }
        public void Load(XElement save)
        {
            DisSerialize dis = (s1) => save.Attribute(s1).Value;

            id = int.Parse(dis("id"));
            name = dis("name");
            surname = dis("surname");
            age = int.Parse(dis("age"));
            telephone = dis("telephone");
            post = dis("post");
            workemail = dis("workemail");
            specialization = dis("specialization");
            dateofbirth = dis("dob");
        }
    }

    public class Order:ISaveable
    {
        static int count = 0;
        private enum OrderStatus
        {
            NotStarted,
            InProgress,
            Complete
        }

        private int id;
        private Car car;
        private Client customer;
        private int price;
        private string dateofdeal;
        private string beginofworks;
        private string endofworks;
        private OrderStatus status;
        private string orderdesc;
        private Employee responsible;

        delegate void Serialize(string sign, string value);
        delegate string DisSerialize(string sign);

        public Order(Car _car, Client _client, int _price, string _desc)
        {
            id = ++count;
            car = _car;
            customer = _client;
            Price = _price;
            Description = _desc;
            status = OrderStatus.NotStarted;
            dateofdeal = DateTime.Now.ToString("dd.MM.yyyy");
            beginofworks = endofworks = "";
            responsible = null;
        }

        public Order()
        {

        }

        #region Properties
        public int Id
        {
            get { return id; }
        }
        public string Description
        {
            get { return orderdesc; }
            private set { orderdesc = value; }
        }
        public int Price
        {
            get { return price; }
            private set { price = value; }
        }
        public string Deal
        {
            get { return dateofdeal; }
        }
        public string Begin
        {
            get { return beginofworks; }
        }
        public string End
        {
            get { return endofworks; }
        }
        public Car Car
        {
            get { return car; }
        }
        public Client Customer
        {
            get { return customer; }
        }
        public Employee Responsible
        {
            get { return responsible; }
        }
        #endregion

        public void ChangeStatus(out string errormessage)
        {
            errormessage = "none";
            switch (status)
            {
                case OrderStatus.NotStarted:
                    if (responsible == null)
                    {
                        errormessage = "No employee";
                    }
                    else
                    {
                        status = OrderStatus.InProgress;
                        beginofworks = DateTime.Now.ToString("dd.MM.yyyy");
                    }
                    break;

                case OrderStatus.InProgress:
                    status = OrderStatus.Complete;
                    endofworks = DateTime.Now.ToString("dd.MM.yyyy");
                    break;

                default:
                    break;
            }
        }
        public void SetEmployee(Employee e)
        {
            responsible = e;
        }

        public string ToStr()
        {
            return String.Format("Заказ №{0} за {1}", Id, dateofdeal);
        }

        public override string ToString()
        {
            return "Order: "+ ToStr();
        }

        public string ShowClientInfo()
        {
            return customer.ToStr();
        }
        public string ShowCarInfo()
        {
            return car.ToStr();
        }
        public string ShowRespInfo()
        {
            if (responsible == null)
                return "###";
            return responsible.ToStr();
        }
        public XElement Save()
        {
            XElement ret = new XElement("order");

            Serialize ser = (s1, s2) => ret.Add(new XAttribute(s1, s2));

            SaveProcess.Save(ref ret, car);
            ser("id", id.ToString());
            SaveProcess.Save(ref ret, customer);
            if (responsible != null)
                SaveProcess.Save(ref ret, responsible);
            ser("price", Price.ToString());
            ret.Add(new XElement("desc", Description));
            ser("status", ((int)status).ToString());
            ser("dod", dateofdeal);

            switch(status)
            {
                case OrderStatus.NotStarted:
                    break;
                case OrderStatus.InProgress:
                    ser("bow", beginofworks);
                    break;
                case OrderStatus.Complete:
                    ser("bow", beginofworks);
                    ser("eow", endofworks);
                    break;
            }

            return ret;
        }
        public void Load(XElement save)
        {
            count++;

            DisSerialize dis = (s1) => save.Attribute(s1).Value;

            id = int.Parse(dis("id"));
            Price = int.Parse(dis("price"));
            status = (OrderStatus)int.Parse(dis("status"));
            dateofdeal = dis("dod");
            orderdesc = save.Element("desc").Value;

            switch (status)
            {
                case OrderStatus.NotStarted:
                    beginofworks = endofworks = "";
                    break;
                case OrderStatus.InProgress:
                    beginofworks = dis("bow");
                    endofworks = "";
                    break;
                case OrderStatus.Complete:
                    beginofworks = dis("bow");
                    endofworks = dis("eow");
                    break;
            }

            car = (Car)SaveProcess.Load(save.Element("car"));
            customer = (Client)SaveProcess.Load(save.Element("client"));
            if (save.Element("empl") != null)
                responsible = (Employee)SaveProcess.Load(save.Element("empl"));
        }
    }

    public class MyList<T>:ISaveable where T:IPerson
    {
        public delegate T NewT();

        public NewT getelem;

        public delegate void Warn();
        public event Warn Updating;
        
        public void SetDel(NewT del)
        {
            getelem = del;
        }

        List<T> list;
        public MyList()
        {
            list = new List<T>();
        }

        public List<T> List
        {
            get { return list; }
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void AddNew()
        {
            if (getelem == null)
                return;
            T t = getelem();
            if (t == null)
                return;

            list.Add(t);
            Updating?.Invoke();
        }

        public void Clear()
        {
            list.Clear();
        }

        public XElement Save()
        {
            string name;

            if (typeof(T) == typeof(Client))
                name = "clients";
            else
                name = "employees";

            XElement ret = new XElement(name);
            foreach(var item in list)
                SaveProcess.Save(ref ret, item);
            return ret;
        }

        public void Load(XElement save)
        {
            string name;
            if (typeof(T) == typeof(Client))
                name = "client";
            else
                name = "empl";

            foreach (var elem in save.Elements(name))
            {
                list.Add((T)SaveProcess.Load(elem));
            }
        }
    }
}