using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Cho;

namespace VehicleAssignment
{
    public class Factory<T> where T : Vehicle
    {
        public static List<T> read(string filePath)
        {
            List<T> objectFromFile = new List<T>();
            try
            {
                using (StreamReader Reader = new StreamReader(filePath))
                {
                    foreach (T objectData in new ChoJSONReader<T>(Reader))
                    {

                        objectFromFile.Add(objectData);
                    }
                }
                return objectFromFile;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void write(List<T> entities, string filePath)
        {
            using (var parser = new ChoJSONWriter<T>(filePath))
            {
                parser.Write(entities);
            }
        }
    }
}
