using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogClasses
{
    public enum OperType
    {
        New,
        OpenFile,
        SaveFile,
        Changed,
    }
    public class LogEventArgs
    {
        public OperType OType { get; }
        public string Date { get; }

        public string Name { get; }

        public string SubInfo { get; }

        public LogEventArgs(OperType t,string name = "",string subinfo = "")
        {
            OType = t;
            Date = DateTime.Now.ToString("dd.MM.yy-hh.mm.ss");
            Name = name;
            SubInfo = subinfo;
        }

    }
    public class Log
    {
        public Log()
        {
            StreamWriter wstream = new StreamWriter("log.txt", false);
            wstream.Close();
        }

        public void AddLog(object o, LogEventArgs e)
        {
            using (StreamWriter wstream = new StreamWriter("log.txt", true, System.Text.Encoding.Default))
            {
                switch(e.OType)
                {
                    case OperType.New:
                        wstream.Write($"New object - {o.ToString()} - {e.Date}\n");
                        break;
                    case OperType.OpenFile:
                        wstream.Write($"Open file - {((e.Name == "")? o.ToString() : e.Name)} - {e.Date}\n");
                        break;
                    case OperType.SaveFile:
                        wstream.Write($"Save file - {((e.Name == "") ? o.ToString() : e.Name)} - {e.Date}\n");
                        break;
                    case OperType.Changed:
                        wstream.Write($"Changes in - {o.ToString()} - changed: {e.SubInfo} - {e.Date}\n");
                        break;
                }
            }
        }
    }
}
