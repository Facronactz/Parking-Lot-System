using NTT.Constant;

namespace NTT.Entity;

public class ParkingLot
{
    private readonly List<Vehicle> _vehicles;
    private readonly int _capacity;

    public ParkingLot(int capacity)
    {
        _capacity = capacity;
        _vehicles = new List<Vehicle>();
    }

    public void Park(string registrationNumber, VehicleType type, string colour)
    {
        if (_vehicles.Count < _capacity)
        {
            int count = _vehicles.Count + 1;
            for (int i = 0; i < _vehicles.Count; i++)
            {
                if (_vehicles[i].SlotNumber == count)
                {
                    count--;
                    i = -1;
                }
            }
            var vehicle = new Vehicle(registrationNumber, type, colour, count);
            _vehicles.Add(vehicle);
            Console.WriteLine($"Allocated slot number: {count}");
        }
        else
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }

    public void Leave(int slotNumber)
    {
        if (slotNumber > 0 && slotNumber <= _vehicles.Count)
        {
            var vehicle = _vehicles.Find((v => v.SlotNumber == slotNumber));
            // _vehicles.RemoveAt(slotNumber - 1);
            if (vehicle == null)
            {
                Console.WriteLine("Invalid slot number");
                return;
            }

            _vehicles.Remove(vehicle);
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine("Invalid slot number");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot\tNo.\t\tType\tRegistration No Colour");
        foreach (var v in _vehicles)
        {
            Console.WriteLine(
                $"{v.SlotNumber}\t{v.RegistrationNumber}\t{v.Type}\t{v.Colour}");
        }
    }

    public int GetTypeOfVehicles(VehicleType type)
    {
        return _vehicles.Count(v => v.Type == type);
        return 0;
    }

    public List<string> GetRegistrationNumbersForVehiclesWithOddPlate()
    {
        return _vehicles
            .Where(v => int.Parse(v.RegistrationNumber.Split('-', StringSplitOptions.None)[1]) % 2 != 0).Select(v => v.RegistrationNumber).ToList();
    }

    public List<string> GetRegistrationNumbersForVehiclesWithEvenPlate()
    {
        return _vehicles
            .Where(v => int.Parse(v.RegistrationNumber.Split('-', StringSplitOptions.None)[1]) % 2 == 0).Select(v => v.RegistrationNumber).ToList();
    }

    public List<string> GetRegistrationNumbersForVehiclesWithColour(string colour)
    {
        return _vehicles.Where(v => v.Colour == colour).Select(v => v.RegistrationNumber).ToList();
    }

    public List<int> GetSlotNumbersForVehiclesWithColour(string colour)
    {
        return _vehicles.Where(v => v.Colour == colour).Select(v => v.SlotNumber).ToList();
    }

    public int? GetSlotNumberForRegistrationNumber(string registrationNumber)
    {
        return  _vehicles.Find(v => v.RegistrationNumber == registrationNumber)?.SlotNumber;
    }
}
