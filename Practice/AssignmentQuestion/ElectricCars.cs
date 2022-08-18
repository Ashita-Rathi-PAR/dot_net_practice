using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentQuestion
{
    
    class ElectricCars : Cars
    {
        public int inverterWatts { get; set; }
        public int inductionMotorPhase { get; set; }
        public string chargePortType { get; set; }

        public override string vehicleDescription()
        {
            float gstPercent = 12;
            float gstAmount = (cost + gstPercent) / 100;
            costWithGSTIncluded = costWithGSTIncluded + gstAmount;

            string writeFile = "numberOfWheels:" + numberOfWheels + "/" + "modelName:" + modelName + "/" +
                "powerSource:" + powerSource + "/" + "color:" + color + "/" + "costWithGSTIncluded:" + costWithGSTIncluded + "/" +
                "isDualAirBags:" + isDualAirBags + "/" + "isAirConditioning:" + isAirConditioning + "/" + "isPowerWindows:" +
                isPowerWindows + "/" + "isMusicSystem:" + isMusicSystem + "/" + "isCentralDoorLock:" + isCentralDoorLock + "/" +
                "isSeatBelts:" + isSeatBelts + "/" + "inverterWatts:" + inverterWatts + "/" + "inductionMotorPhase:" + 
                inductionMotorPhase + "/" + "chargePortType:" + chargePortType + "\n";
            return writeFile;
        }

        public override void addVehicle()
        {
            base.addVehicle();
            Console.WriteLine("Enter Inverter Watts:");
            inverterWatts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Induction Motor Phase:");
            inductionMotorPhase = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Charge Port Type:");
            chargePortType = Convert.ToString(Console.ReadLine());
        }

        public override Tuple<bool, List<string>, string> findVehicle(string vehicle_list_string, int NumberOfWheels)
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
            Console.WriteLine("Enter Inverter Watts:");
            int checkInverterWatts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Induction Motor Phase:");
            int checkInductionMotorPhase = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Charge Port Type:");
            string checkChargePortType = Convert.ToString(Console.ReadLine());

            string checkFile = "numberOfWheels:" + checkNumberOfWheels + "/" + "modelName:" + checkModelName + "/" +
                "powerSource:" + checkPowerSource + "/" + "color:" + checkColor + "/" + "costWithGSTIncluded:" + checkCostWithGSTIncluded + "/" +
                "isDualAirBags:" + checkIsDualAirBags + "/" + "isAirConditioning:" + checkIsAirConditioning + "/" + "isPowerWindows:" +
                checkIsPowerWindows + "/" + "isMusicSystem:" + checkIsMusicSystem + "/" + "isCentralDoorLock:" + checkIsCentralDoorLock + "/" +
                "isSeatBelts:" + checkIsSeatBelts + "/inverterWatts:" + checkInverterWatts + "/" + "inductionMotorPhase:" + checkInductionMotorPhase + "/" +
                "chargePortType:" + checkChargePortType;

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
