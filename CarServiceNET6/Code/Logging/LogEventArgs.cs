using CarService.Code.Enums;

namespace CarService.Code.Logging;
public class LogEventArgs
{
    public OperType OType { get; }
    public string Date { get; }

    public string Name { get; }

    public string SubInfo { get; }

    public LogEventArgs(OperType t, string name = "", string subinfo = "")
    {
        OType = t;
        Date = DateTime.Now.ToString("dd.MM.yy-hh.mm.ss");
        Name = name;
        SubInfo = subinfo;
    }

}
