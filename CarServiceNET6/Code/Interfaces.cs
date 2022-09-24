using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfaces
{
    public enum InfoType
    {
        Full,
        Short
    }
    public interface ISaveable
    { 
        XElement Save();

        void Load(XElement save);
    }
    public interface IPerson : ISaveable
    {
        #region Properties
        int Id { get; }
        string Name { get; }
        string SurName { get; }
        int Age { get; }
        string DateOfBirth { get; }
        string Telephone { get; }
        #endregion

        string ToStr(InfoType type);
    }
}
