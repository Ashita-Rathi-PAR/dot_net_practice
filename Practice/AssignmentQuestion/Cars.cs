using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentQuestion
{
    interface Vehicle
    {
        int numberOfWheels { get; set; }
        string modelName { get; set; }
        string powerSource { get; set; }
        string color { get; set; }
        float cost { get; set; }
        float costWithGSTIncluded { get; set; }
    }
    
    interface Solution
    { 
        string vehicleDescription();
        int addVehicle();
        Tuple<bool, List<string>, string> findVehicle(string vehicle_list, int NumberOfWheels);
        void updateVehicle();
    }

    class Cars : Vehicle, Solution
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
        protected float sizeInMeters { get; set; }
        protected bool isDualAirBags { get; set; }
        protected bool isChildLock { get; set; }
        protected bool isAirConditioning { get; set; }
        protected bool isPowerWindows { get; set; }
        protected bool isMusicSystem { get; set; }
        protected bool isCentralDoorLock { get; set; }
        protected bool isSeatBelts { get; set; }

        public virtual string vehicleDescription()
        {
            float gstPercent;
            if (sizeInMeters <= 4)
            {
                gstPercent = 18;
            }
            else
            {
                gstPercent = 28;
            }
            float gstAmount = (cost + gstPercent) / 100;
            costWithGSTIncluded = cost + gstAmount;

            string writeFile = "numberOfWheels:" + numberOfWheels + "/" + "modelName:" + modelName + "/" +
                "powerSource:" + powerSource + "/" + "color:" + color + "/" + "costWithGSTIncluded:" + costWithGSTIncluded + "/" + 
                "isDualAirBags:" + isDualAirBags + "/" + "isAirConditioning:" + isAirConditioning + "/" + "isPowerWindows:" +
                isPowerWindows + "/" + "isMusicSystem:" + isMusicSystem + "/" + "isCentralDoorLock:" + isCentralDoorLock + "/" +
                "isSeatBelts:" + isSeatBelts + "\n";

            return writeFile;
        }

        public virtual int addVehicle()
        {
            Console.WriteLine("Enter model name of vehicle:");
            modelName = Console.ReadLine();
            Console.WriteLine("Enter power source of vehicle:");
            powerSource = Console.ReadLine();
            Console.WriteLine("Enter color of vehicle:");
            color = Console.ReadLine();
            Console.WriteLine("Enter cost of vehicle:");
            cost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter size of wheels in meters vehicle:");
            sizeInMeters = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Are dual air bags present in vehicle(true/false):");
            isDualAirBags = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is air conditioning present in vehicle(true/false):");
            isAirConditioning = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Are power windows present in vehicle(true/false):");
            isPowerWindows = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is Music System present in vehicle(true/false):");
            isMusicSystem = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is Central Door Lock present in vehicle(true/false):");
            isCentralDoorLock = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Are seat belts present in vehicle(true/false):");
            isSeatBelts = Convert.ToBoolean(Console.ReadLine());
            numberOfWheels = 4;
            File.AppendAllText("cars.txt", vehicleDescription());

            return 1;
        }

        public virtual Tuple<bool, List<string>,string> findVehicle(string vehicle_list_string, int NumberOfWheels)
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
            Console.WriteLine("Are dual air bags present in vehicle(true/false):");
            bool checkIsDualAirBags = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is air conditioning present in vehicle(true/false):");
            bool checkIsAirConditioning = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Are power windows present in vehicle(true/false):");
            bool checkIsPowerWindows = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is Music System present in vehicle(true/false):");
            bool checkIsMusicSystem = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is Central Door Lock present in vehicle(true/false):");
            bool checkIsCentralDoorLock = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Are seat belts present in vehicle(true/false):");
            bool checkIsSeatBelts = Convert.ToBoolean(Console.ReadLine());

            string checkFile = "numberOfWheels:" + checkNumberOfWheels + "/" + "modelName:" + checkModelName + "/" +
                "powerSource:" + checkPowerSource + "/" + "color:" + checkColor + "/" + "costWithGSTIncluded:" + checkCostWithGSTIncluded + "/" +
                "isDualAirBags:" + checkIsDualAirBags + "/" + "isAirConditioning:" + checkIsAirConditioning + "/" + "isPowerWindows:" +
                checkIsPowerWindows + "/" + "isMusicSystem:" + checkIsMusicSystem + "/" + "isCentralDoorLock:" + checkIsCentralDoorLock + "/" +
                "isSeatBelts:" + checkIsSeatBelts;

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

        public void updateVehicle()
        {
            string all_cars = File.ReadAllText("cars.txt");
            Tuple<bool, List<string>, string> tuple1 = findVehicle(all_cars, 4);
            bool result1 = tuple1.Item1;
            List<string> vehicles1 = new List<string>();
            vehicles1 = tuple1.Item2;
            string checkFile = tuple1.Item3;

            if (result1)
            {
                vehicles1.Remove(checkFile);
            }

            numberOfWheels = 4;
            Console.WriteLine("Enter the updated details:");
            addVehicle();
            File.AppendAllText("cars.txt", vehicleDescription());
        }
    }
}
    