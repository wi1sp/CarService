using CarServiceNET6.Code.Enums;
using CarServiceNET6.Code.Interfaces;
using System.Xml.Linq;

namespace CarServiceNET6.Code;
public class Client : Person, IPerson
{
    protected string email;
    protected string adress;

    delegate void Serialize(string sign, string value);
    delegate string DisSerialize(string sign);

    public Client(string _name, string _surname, int _age, string _telephone, string _email, string _adress, string _dateofbirth) :
        base(_name, _surname, _age, _telephone, _dateofbirth)
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
