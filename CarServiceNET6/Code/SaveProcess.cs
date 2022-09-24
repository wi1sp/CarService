using CarServiceNET6.Code.Interfaces;
using System.Xml.Linq;

namespace CarServiceNET6.Code;
public static class SaveProcess
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
