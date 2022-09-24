using System.Xml.Linq;

namespace CarServiceNET6.Code.Interfaces;
public interface ISaveable
{
    XElement Save();

    void Load(XElement save);
}
