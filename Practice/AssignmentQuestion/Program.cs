using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentQuestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose type of vehicle:\n1. Car\n2. Electric Car\n3. Truck\n4. Exit");
                int typeOfVehicleChoice = Convert.ToInt32(Console.ReadLine());

                switch(typeOfVehicleChoice)
                {
                    case 1:
                        Console.WriteLine("Your Choices \n1. Add a vehicle\n2. Find a vehicle\n3. Update a vehicle\n4. Delete a vehicle\n");
                        int choiceCar = Convert.ToInt32(Console.ReadLine());

                        switch (choiceCar)
                        {
                            case 1:
                                Cars cars = new Cars();
                                Console.WriteLine("Number of cars added: {0}",cars.addVehicle());
                                break;
                            case 2:
                                Cars cars1 = new Cars();
                                string all_cars = File.ReadAllText("cars.txt");
                                Tuple<bool, List<string>,string> tuple = cars1.findVehicle(all_cars,4);
                                bool result = tuple.Item1;
                                List<string> vehicles = new List<string>();
                                vehicles = tuple.Item2;

                                if (result)
                                {
                                    Console.WriteLine("\n\nCar Found\n\n");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nCar Not Found\n\n");
                                }
                                break;
                            case 3:
                                Cars cars2 = new Cars();
                                string all_cars1 = File.ReadAllText("cars.txt");
                                Tuple<bool, List<string>,string> tuple1 = cars2.findVehicle(all_cars1, 4);
                                bool result1 = tuple1.Item1;
                                List<string> vehicles1 = new List<string>();
                                vehicles1 = tuple1.Item2;
                                string checkFile = tuple1.Item3;
                                
                                if (result1)
                                {
                                    vehicles1.Remove(checkFile);
                                }

                                cars2.numberOfWheels = 4;
                                Console.WriteLine("Enter the updated details:");
                                cars2.addVehicle();
                                File.AppendAllText("cars.txt", cars2.vehicleDescription());

                                break;
                            case 4:
                                Cars cars3 = new Cars();
                                string all_cars2 = File.ReadAllText("cars.txt");
                                Tuple<bool, List<string>, string> tuple2 = cars3.findVehicle(all_cars2, 4);
                                bool result2 = tuple2.Item1;
                                List<string> vehicles2 = new List<string>();
                                vehicles2 = tuple2.Item2;
                                string checkFile1 = tuple2.Item3;

                                if (result2)
                                {
                                    vehicles2.Remove(checkFile1);
                                }

                                File.Delete("cars.txt");
                                foreach (string vehicle in vehicles2)
                                {
                                    File.AppendAllText("cars.txt",vehicle+"\n");
                                }

                                break;
                            default:
                                Console.WriteLine("Enter a valid choice");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Your Choices \n1. Add a vehicle\n2. Find a vehicle\n3. Update a vehicle\n4. Delete a vehicle");
                        int choiceElectricCar = Convert.ToInt32(Console.ReadLine());

                        switch (choiceElectricCar)
                        {
                            case 1:
                                ElectricCars electric_cars = new ElectricCars();
                                electric_cars.numberOfWheels = 4;
                                electric_cars.addVehicle();
                                File.AppendAllText("electric_cars.txt", electric_cars.vehicleDescription());
                                break;
                            case 2:
                                ElectricCars electric_cars1 = new ElectricCars();
                                string all_electric_cars = File.ReadAllText("electric_cars.txt");
                                Tuple<bool, List<string>, string> tuple = electric_cars1.findVehicle(all_electric_cars, 4);
                                bool result = tuple.Item1;
                                List<string> vehicles = new List<string>();
                                vehicles = tuple.Item2;

                                if (result)
                                {
                                    Console.WriteLine("Electric Car Found");
                                }
                                else
                                {
                                    Console.WriteLine("Electric Car Not Found");
                                }
                                break;
                            case 3:
                                ElectricCars cars2 = new ElectricCars();
                                string all_electric_cars1 = File.ReadAllText("electric_cars.txt");
                                Tuple<bool, List<string>, string> tuple1 = cars2.findVehicle(all_electric_cars1, 4);
                                bool result1 = tuple1.Item1;
                                List<string> vehicles1 = new List<string>();
                                vehicles1 = tuple1.Item2;
                                string checkFile = tuple1.Item3;
                                //int index = vehicles1.IndexOf(checkFile);

                                if (result1)
                                {
                                    vehicles1.Remove(checkFile);
                                }

                                cars2.numberOfWheels = 4;
                                Console.WriteLine("Enter the updated details:");
                                cars2.addVehicle();
                                //vehicles1.Insert(index, cars2.vehicleDescription());
                                File.AppendAllText("electric_cars.txt", cars2.vehicleDescription());

                                break;
                            case 4:
                                ElectricCars cars3 = new ElectricCars();
                                string all_electric_cars2 = File.ReadAllText("electric_cars.txt");
                                Tuple<bool, List<string>, string> tuple2 = cars3.findVehicle(all_electric_cars2, 4);
                                bool result2 = tuple2.Item1;
                                List<string> vehicles2 = new List<string>();
                                vehicles2 = tuple2.Item2;
                                string checkFile1 = tuple2.Item3;

                                if (result2)
                                {
                                    vehicles2.Remove(checkFile1);
                                }

                                File.Delete("electric_cars.txt");
                                foreach (string vehicle in vehicles2)
                                {
                                    File.AppendAllText("electric_cars.txt", vehicle + "\n");
                                }
                                break;
                            default:
                                Console.WriteLine("Enter a valid choice");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Your Choices \n1. Add a vehicle\n2. Find a vehicle\n3. Update a vehicle\n4. Delete a vehicle");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Trucks trucks = new Trucks();
                                trucks.numberOfWheels = 6;
                                trucks.addVehicle();
                                File.AppendAllText("trucks.txt", trucks.vehicleDescription());
                                break;
                            case 2:
                                Trucks trucks1 = new Trucks();
                                string all_trucks = File.ReadAllText("trucks.txt");
                                Tuple<bool, List<string>, string> tuple = trucks1.findVehicle(all_trucks, 6);
                                bool result = tuple.Item1;
                                List<string> vehicles = new List<string>();
                                vehicles = tuple.Item2;

                                if (result)
                                {
                                    Console.WriteLine("Truck Found");
                                }
                                else
                                {
                                    Console.WriteLine("Truck Not Found");
                                }
                                break;
                            case 3:
                                Trucks trucks2 = new Trucks();
                                string all_trucks1 = File.ReadAllText("trucks.txt");
                                Tuple<bool, List<string>, string> tuple1 = trucks2.findVehicle(all_trucks1, 6);
                                bool result1 = tuple1.Item1;
                                List<string> vehicles1 = new List<string>();
                                vehicles1 = tuple1.Item2;
                                string checkFile = tuple1.Item3;
                                //int index = vehicles1.IndexOf(checkFile);

                                if (result1)
                                {
                                    vehicles1.Remove(checkFile);
                                }

                                trucks2.numberOfWheels = 6;
                                Console.WriteLine("Enter the updated details:");
                                trucks2.addVehicle();
                                //vehicles1.Insert(index, cars2.vehicleDescription());
                                File.AppendAllText("trucks.txt", trucks2.vehicleDescription());
                                break;
                            case 4:
                                Trucks trucks3 = new Trucks();
                                string all_trucks2 = File.ReadAllText("trucks.txt");
                                Tuple<bool, List<string>, string> tuple2 = trucks3.findVehicle(all_trucks2, 6);
                                bool result2 = tuple2.Item1;
                                List<string> vehicles2 = new List<string>();
                                vehicles2 = tuple2.Item2;
                                string checkFile1 = tuple2.Item3;

                                if (result2)
                                {
                                    vehicles2.Remove(checkFile1);
                                }

                                File.Delete("trucks.txt");
                                foreach (string vehicle in vehicles2)
                                {
                                    File.AppendAllText("trucks.txt", vehicle + "\n");
                                }
                                break;
                            default:
                                Console.WriteLine("Enter a valid choice");
                                break;
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Enter a valid choice");
                        break;
                }

                
            }
        }
    }

}
