using CarServiceNET6.Code.Enums;

namespace CarServiceNET6.Code.Interfaces;
public interface IPerson : ISaveable
{
    int Id { get; }
    string Name { get; }
    string SurName { get; }
    int Age { get; }
    string DateOfBirth { get; }
    string Telephone { get; }

    string ToStr(InfoType type);
}