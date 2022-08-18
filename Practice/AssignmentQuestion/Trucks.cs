using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentQuestion
{
    class Trucks : Vehicle, Solution
    {
        private int _numberOfWheels;
        public int numberOfWheels
        {
            get => _numberOfWheels;
            set => _numberOfWheels = value;
        }

        private string _modelName;
        public string modelName
        {
            get => _modelName;
            set => _modelName = value;
        }

        private string _powerSource;
        public string powerSource
        {
            get => _powerSource;
            set => _powerSource = value;
        }

        private string _color;
        public string color
        {
            get => _color;
            set => _color = value;
        }

        private float _cost;
        public float cost
        {
            get => _cost;
            set => _cost = value;
        }

        private float _costWithGSTIncluded;
        public float costWithGSTIncluded
        {
            get => _costWithGSTIncluded;
            set => _costWithGSTIncluded = value;
        }

        protected string typeOfTruck { get; set; }

        public virtual string vehicleDescription()
        {
            float gstPercent = 28;
            float gstAmount = (cost + gstPercent) / 100;
            costWithGSTIncluded = cost + gstAmount;

            string writeFile = "numberOfWheels:" + numberOfWheels + "/" + "modelName:" + modelName + "/" +
                "powerSource:" + powerSource + "/" + "color:" + color + "/" + "costWithGSTIncluded:" + costWithGSTIncluded + "/" +
                "typeOfTruck:" + typeOfTruck + "\n";

            return writeFile;
        }
        public void addVehicle()
        {
            Console.WriteLine("Enter model name of vehicle:");
            modelName = Console.ReadLine();
            Console.WriteLine("Enter power source of vehicle:");
            powerSource = Console.ReadLine();
            Console.WriteLine("Enter color of vehicle:");
            color = Console.ReadLine();
            Console.WriteLine("Enter cost of vehicle:");
            cost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter type of truck:");
            typeOfTruck = Console.ReadLine();
        }

        public virtual Tuple<bool, List<string>, string> findVehicle(string vehicle_list_string, int NumberOfWheels)
        {
            string checkNumberOfWheels = Convert.ToString(NumberOfWheels);
            Console.WriteLine("Enter model name of vehicle:");
            string checkModelName = Console.ReadLine();
            Console.WriteLine("Enter power source of vehicle:");
            string checkPowerSource = Console.ReadLine();
            Console.WriteLine("Enter color of vehicle:");
            string checkColor = Console.ReadLine();
            Console.WriteLine("Enter the cost with gst inculded:");
            float checkCostWithGSTIncluded = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the type of truck:");
            string checkTypeOfTruck = Console.ReadLine();

            string checkFile = "numberOfWheels:" + checkNumberOfWheels + "/" + "modelName:" + checkModelName + "/" +
                "powerSource:" + checkPowerSource + "/" + "color:" + checkColor + "/" + "costWithGSTIncluded:" + checkCostWithGSTIncluded + "/" +
                "typeOfTruck:" + checkTypeOfTruck;

            List<string> vehicles = new List<string>();
            vehicles = vehicle_list_string.Split('\n').ToList();
            if (vehicles.Contains(checkFile))
            {
                Console.WriteLine(true);
                return Tuple.Create(true, vehicles, checkFile);
            }
            else
            {
                return Tuple.Create(false, vehicles, checkFile);
            }
        }
    }
}
