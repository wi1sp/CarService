using CarServiceNET6.Code.Interfaces;
using System.Xml.Linq;

namespace CarServiceNET6.Code;
public class Order : ISaveable
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
        return "Order: " + ToStr();
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

        switch (status)
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