using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ChoETL;

namespace VehicleAssignment
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose type of vehicle:\n1. Car\n2. Truck\n3. Exit\n");
                int typeOfVehicleChoice = Convert.ToInt32(Console.ReadLine());

                switch (typeOfVehicleChoice)
                {
                    case 1:
                        Console.WriteLine("\nYour Choices \n1. Add a car\n2. Find a car\n3. Update a car\n4. Delete a car\n5. List all cars\n");
                        int choiceCar = Convert.ToInt32(Console.ReadLine());
                        CarInventory carInventory = new CarInventory(filePath.carFile);
                        Car car = new Car();    
                        carInventory.operations(choiceCar,car,filePath.carFile);
                        break;

                    case 2:
                        Console.WriteLine("\nYour Choices \n1. Add a truck\n2. Find a truck\n3. Update a truck\n4. Delete a truck\n5. List all the trucks\n");
                        int choiceTruck = Convert.ToInt32(Console.ReadLine());
                        TruckInventory truckInventory = new TruckInventory(filePath.truckFile);
                        Truck truck = new Truck();
                        truckInventory.operations(choiceTruck, truck, filePath.truckFile);
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }
            }
        }
    }
}