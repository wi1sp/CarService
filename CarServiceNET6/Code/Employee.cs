using CarServiceNET6.Code.Enums;
using CarServiceNET6.Code.Interfaces;
using System.Xml.Linq;

namespace CarServiceNET6.Code;
public class Employee : Person, IPerson
{
    protected string post;
    protected string workemail;
    protected string specialization;

    delegate void Serialize(string sign, string value);
    delegate string DisSerialize(string sign);

    public Employee(string _name, string _surname, int _age, string _telephone, string _workemail, string _post, string _specialization, string _dateofbirth) :
        base(_name, _surname, _age, _telephone, _dateofbirth)
    {
        post = _post;
        workemail = _workemail;
        specialization = _specialization;
    }

    public Employee() { }

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
        switch (type)
        {
            case InfoType.Short:
                return String.Format("{0} {1} {2}", Name, SurName, Post);

            case InfoType.Full:
                return String.Format("{0} {1} / {2} {3} {4}", Name, SurName, Post, Specialization, Workemail);
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
