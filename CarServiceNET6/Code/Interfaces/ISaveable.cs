using System.Xml.Linq;

namespace CarService.Code.Interfaces;
public interface ISaveable
{
    XElement Save();

    void Load(XElement save);
}
