using NTT.Constant;
using NTT.Entity;

class Program
{
    static void Main(string[] args)
    {
        var parkingLot = new ParkingLot(0);

        while (true)
        {
            Console.Write("$ ");
            var command = Console.ReadLine()?.Split(' ');

            switch (command?[0])
            {
                case "create_parking_lot":
                    parkingLot = new ParkingLot((int.Parse(command[1])));
                    Console.WriteLine($"Created a parking lot with {command[1]} slots");
                    break;
                case "park":
                    parkingLot.Park(command[1], command[3] == "Mobil" ? VehicleType.Mobil : VehicleType.Motor,
                        command[2]);
                    break;
                case "leave":
                    parkingLot.Leave(int.Parse(command[1]));
                    break;
                case "status":
                    parkingLot.Status();
                    break;
                case "type_of_vehicles":
                    Console.WriteLine(
                        parkingLot.GetTypeOfVehicles(command[1] == "Mobil" ? VehicleType.Mobil : VehicleType.Motor));
                    break;
                case "registration_numbers_for_vehicles_with_odd_plate":
                    Console.WriteLine(string.Join(", ", parkingLot.GetRegistrationNumbersForVehiclesWithOddPlate()));
                    break;
                case "registration_numbers_for_vehicles_with_even_plate":
                    Console.WriteLine(string.Join(", ", parkingLot.GetRegistrationNumbersForVehiclesWithEvenPlate()));
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    Console.WriteLine(string.Join(", ",
                        parkingLot.GetRegistrationNumbersForVehiclesWithColour(command[1])));
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    Console.WriteLine(string.Join(", ", parkingLot.GetSlotNumbersForVehiclesWithColour(command[1])));
                    break;
                case "slot_number_for_registration_number":
                    var slotNumber = parkingLot.GetSlotNumberForRegistrationNumber(command[1]);
                    Console.WriteLine(slotNumber.HasValue ? slotNumber.ToString() : "Not found");
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}