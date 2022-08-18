using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.Design;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChoETL; //Install-Package ChoETL.JSON -Version 1.2.1.48

namespace VehicleAssignment
{
    

    abstract class VehicleInventory<T> where T : Vehicle
    {
        public List<T> entities = new List<T>();
        public string filePath;

        public VehicleInventory(string filePath)
        {
            this.filePath = filePath;
            this.entities = Factory<T>.read(filePath);
        }

        public int add(T vehicle,string filePath)
        {
            entities.Add(vehicle);
            Factory<T> factory = new Factory<T>();
            factory.write(entities, filePath);
            return 1;
        }
        public T find(int id, string filePath)
        {

            return entities.Find(vehicle => vehicle.id == id);
        }
        public string update(T vehicle_update,T vehicle,string filePath)
        {
            int index = entities.FindIndex(v => v.id == vehicle_update.id);
            Console.WriteLine(index);
            if (index != -1) 
            { 
                entities[index] = vehicle;
                Factory<T> factory = new Factory<T>();
                factory.write(entities, filePath);

                return "Vehicle Details Updated";
            }
            
            return "Vehicle Not Found";
        }
        public string delete(int id,string filePath)
        {
            bool isDeleted = entities.Remove(entities.Find(vehicle => vehicle.id == id));

            if (isDeleted)
            {
                Factory<T> factory = new Factory<T>();
                factory.write(entities, filePath);

                return "Vehicle Deleted";
            }

            return "Vehicle Not Found";
        }

        public T takeInput(T vehicle)
        {
            Console.WriteLine("Enter Id of the vehicle:");
            vehicle.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Model Name of the vehicle");
            vehicle.model = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Company Name of the vehicle");
            vehicle.company = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Color of the vehicle");
            vehicle.color = Convert.ToString(Console.ReadLine());

            return vehicle;
        }

        public virtual void description(T vehicle)
        {
            Console.WriteLine("Id: {0}",vehicle.id);
            Console.WriteLine("Model Name: {0}",vehicle.model);
            Console.WriteLine("Company Name: {0}",vehicle.company);
            Console.WriteLine("Color: {0}", vehicle.color);
        }

        public void operations(int choice, T vehicle, string filePath)
        {
            switch (choice)
            {
                case 1:
                    T add_vehicle = takeInput(vehicle);
                    int obj = add(add_vehicle, filePath);
                    Console.WriteLine(obj + " Vehicle Added");
                    Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Enter the id of the vehicle you want to find:");
                    int find_id = Convert.ToInt32(Console.ReadLine());
                    T find_vehicle = find(find_id, filePath);
                    if (find_vehicle != null)
                    {
                        description(find_vehicle);
                    }
                    else
                    {
                        Console.WriteLine("VEHICLE NOT FOUND");
                    }
                    Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("Enter the id of the vehicle you want to update:");
                    int update_id = Convert.ToInt32(Console.ReadLine());
                    T vehicle_update = find(update_id, filePath);
                    if (vehicle_update != null)
                    {
                        T updated_vehicle = takeInput(vehicle);
                        Console.WriteLine(update(vehicle_update, updated_vehicle, filePath));
                    }
                    else
                    {
                        Console.WriteLine("Vehicle Not Found");
                    }
                    break;

                case 4:
                    Console.WriteLine("Enter the id of the vehicle you want to delete:");
                    int delete_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(delete(delete_id, filePath));
                    break;

                case 5:
                    List<T> vehicle_list = Factory<T>.read(filePath);
                    foreach (T v in vehicle_list)
                    {
                        Console.WriteLine();
                        description(v);
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Enter a valid choice");
                    break;
            }
        }
    }

    class CarInventory : VehicleInventory<Car>
    {
        public CarInventory(string filePath) : base(filePath)
        {
        }
        public override void description(Car vehicle)
        {
            Console.WriteLine("Car-->");
            base.description(vehicle);
        }

    }

    class TruckInventory : VehicleInventory<Truck>
    {
        public TruckInventory(string filePath) : base(filePath)
        {
        }
        public override void description(Truck vehicle)
        {
            Console.WriteLine("Truck-->");
            base.description(vehicle);
        }
    }
}
