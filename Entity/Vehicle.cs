using NTT.Constant;

namespace NTT.Entity;

public class Vehicle
{
    public string RegistrationNumber { get; set; }
    public VehicleType Type { get; set; }
    public string Colour { get; set; }
    public DateTime EntryTime { get; set; }
    public int SlotNumber { get; set; }

    public Vehicle(string registrationNumber, VehicleType type, string colour, int slotNumber)
    {
        RegistrationNumber = registrationNumber;
        Type = type;
        Colour = colour;
        EntryTime = DateTime.Now;
        SlotNumber = slotNumber;
    }
}