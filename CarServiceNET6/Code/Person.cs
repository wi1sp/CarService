namespace CarService.Code;
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
}
