using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssignment
{
    public static class filePath
    {
        /*
         Compiler embeds const value in each assembly that uses them, giving each assembly a unique value for the 
         constant. Static readonly makes sure that the same reference gets passed across assemblies.
        */
        public static readonly string carFile = "cars.json";
        public static readonly string truckFile = "trucks.json";
    }
}
