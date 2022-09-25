using CarService.Code.Interfaces;
using System.Xml.Linq;

namespace CarService.Code;
public class Car : ISaveable
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
        return String.Format("{0} {1} {2}", Name, Category, Number);
    }

    public override string ToString()
    {
        return "Car: " + ToStr();
    }

    public XElement Save()
    {
        count++;
        XElement ret = new XElement("car");
        Serialize ser = (s1, s2) => ret.Add(new XAttribute(s1, s2));

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
