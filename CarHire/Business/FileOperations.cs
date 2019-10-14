using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{
    class FileOperations
    {

        static List<Van> vans = new List<Van>();
        static List<Car> cars = new List<Car>();

        static string filepath = "database.txt";
        public static void readFile(out List<Car> cars_, out List<Van> vans_)
        {

            vans.Clear();
            cars.Clear();
            String[] fileContent = System.IO.File.ReadAllLines(filepath);
            for (int i = 0; i < fileContent.Length; i++)
            {
                
                String[] param = fileContent[i].Split('|');
                switch (param[0].ToLower())
                {

                    case "car":
                        Car c = new Car();
                        c.Make = param[1];
                        c.Model = param[2];
                        c.EngineSize = int.Parse(param[3]);
                        c.FuelType = param[4];
                        c.Manual = bool.Parse(param[5]);
                        c.Price = double.Parse(param[6]);
                        c.Doors = int.Parse(param[7]);
                        c.Seats = int.Parse(param[8]);
                        c.Body = param[9];
                        //c.Available = bool.Parse(param[10]);
                        //try
                        //{
                        //    c.AvailableOn = DateTime.Parse(param[11]);
                        //}
                        //catch
                        //{
                        //    c.AvailableOn = new DateTime();
                        //}
                        c.RegNumber = param[12];
                        try
                        {
                            
                            DateTime start = new DateTime(), end;
                            if (param.Length > 13)
                            {
                                for (int index = 13; index < param.Length; index++)
                                {
                                    if (index % 2 == 1)
                                    {
                                        start = DateTime.Parse(param[index]);
                                    }
                                    else
                                    {
                                        end = DateTime.Parse(param[index]);
                                        Hired temp = new Hired(start, end);
                                        c.hiredDates.Add(temp);
                                    }

                                }
                            }

                        }
                        catch
                        {

                        }


                        cars.Add(c);
                        break;
                    case "van":
                        Van v = new Van();
                        v.Make = param[1];
                        v.Model = param[2];
                        v.EngineSize = int.Parse(param[3]);
                        v.FuelType = param[4];
                        v.Manual = bool.Parse(param[5]);
                        v.Price = double.Parse(param[6]);
                        v.CargoSpace = double.Parse(param[7]);
                        v.SideDoor = bool.Parse(param[8]);
                        v.Wheelbase = param[9][0];
                        //v.Available = bool.Parse(param[10]);
                        //try
                        //{
                        //    v.AvailableOn = DateTime.Parse(param[11]);
                        //}
                        //catch
                        //{
                        //    v.AvailableOn = new DateTime();
                        //}
                        v.RegNumber = param[12];
                        try
                        {


                            DateTime start = new DateTime(), end;
                            if (param.Length > 13)
                            {
                                for (int index = 13; index < param.Length; index++)
                                {
                                    if (index % 2 == 1)
                                    {
                                        start = DateTime.Parse(param[index]);
                                    }
                                    else
                                    {
                                        end = DateTime.Parse(param[index]);
                                        Hired temp = new Hired(start, end);
                                        v.hiredDates.Add(temp);
                                    }

                                }
                            }
                        }
                        catch
                        {

                        }
                        vans.Add(v);
                        break;
                }
            }
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine(cars[i].RegNumber);
            }
            //DatabaseOperations.writeDatabase(cars, vans);
            cars_ = cars;
            vans_ = vans;
        }
        public static void writeFile(List<Car> cars, List<Van> vans)
        {
            String[] contents = new String[cars.Count + vans.Count];
            int counter = 0;
            for (int x = 0; x < cars.Count; x++)
            {
                Car c = cars[x];
                contents[counter] = c.formatLine() + c.Available.ToString() + "|" + c.AvailableOn.ToString() + "|" + c.RegNumber;

              
                for (int i = 0; i < cars[x].hiredDates.Count; i++)
                {
                    contents[counter] += "|" + cars[x].hiredDates[i].StartDate.ToString() + "|" + cars[x].hiredDates[i].ReturnDate.ToString();
                }
                counter++;
            }
            for (int y = 0; y < vans.Count; y++)
            {
                Van v = vans[y];
                contents[counter] = v.formatLine() + "|" + v.Available.ToString() + "|" + v.AvailableOn.ToString() + "|" + v.RegNumber;

                for (int i = 0; i < vans[y].hiredDates.Count; i++)
                {
                    contents[counter] += "|" + vans[y].hiredDates[i].StartDate.ToString() + "|" + vans[y].hiredDates[i].ReturnDate.ToString();
                }

                counter++;
            }
            
            System.IO.File.WriteAllLines(filepath, contents);
        }
       

    }
}
