using CarService.Code.Interfaces;
using System.Xml.Linq;

namespace CarService.Code;
public class MyList<T> : ISaveable where T : IPerson
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
        foreach (var item in list)
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