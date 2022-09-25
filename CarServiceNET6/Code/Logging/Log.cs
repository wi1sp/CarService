using CarService.Code.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Code.Logging;
public class Log
{
    public Log()
    {
        StreamWriter wstream = new StreamWriter("log.txt", false);
        wstream.Close();
    }

    public void AddLog(object o, LogEventArgs e)
    {
        using (StreamWriter wstream = new StreamWriter("log.txt", true, Encoding.Default))
        {
            switch (e.OType)
            {
                case OperType.New:
                    wstream.Write($"New object - {o.ToString()} - {e.Date}\n");
                    break;
                case OperType.OpenFile:
                    wstream.Write($"Open file - {(e.Name == "" ? o.ToString() : e.Name)} - {e.Date}\n");
                    break;
                case OperType.SaveFile:
                    wstream.Write($"Save file - {(e.Name == "" ? o.ToString() : e.Name)} - {e.Date}\n");
                    break;
                case OperType.Changed:
                    wstream.Write($"Changes in - {o.ToString()} - changed: {e.SubInfo} - {e.Date}\n");
                    break;
            }
        }
    }
}
