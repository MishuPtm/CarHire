using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{
    class CarHireClass
    {
        static List<Car> cars;
        static List<Van> vans;
        public static List<Van> availableVans = new List<Van>();
        public static List<Car> availableCars = new List<Car>();
        static bool validConnection = DatabaseOperations.testConnection();
        static string transmissionType = "Any", doorsType = "Any", fuelType = "Any", wheelbase = "Any";
        public static DateTime start, end;

        public static string TransmissionType
        {
            get
            {
                return transmissionType;
            }

            set
            {
                transmissionType = value;
                updateLists();
            }
        }
        public static string DoorsType
        {
            get
            {
                return doorsType;
            }

            set
            {
                doorsType = value;
                updateLists();
            }
        }
        public static string FuelType
        {
            get
            {
                return fuelType;
            }

            set
            {
                fuelType = value;
                updateLists();
            }
        }
        public static string Wheelbase
        {
            get
            {
                return wheelbase;
            }

            set
            {
                wheelbase = value;
                updateLists();
            }
        }

        public CarHireClass()
        {
            if (validConnection)
            {
                DatabaseOperations.readDatabase(out cars, out vans);
            }
            else
            {
                FileOperations.readFile(out cars, out vans);
            }
            updateLists();

        }

        public static void readFile()
        {
            FileOperations.readFile(out cars, out vans);
        }
        public static void writeFile()
        {
            FileOperations.writeFile(cars, vans);
        }
        public static void updateLists()
        {
            availableCars.Clear();
            availableVans.Clear();

            for (int i = 0; i < vans.Count; i++)
            {
                if (vans[i].isAvailable(start, end) && notInList(vans[i]))
                    applyFilters(vans[i]);

            }

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].isAvailable(start, end) && notInList(cars[i]))
                    applyFilters(cars[i]);
            }

            sortByPrice(true);

        }
        private static void sortByPrice(bool lowToHigh)
        {
            for (int x = 0; x < cars.Count; x++)
            {
                for (int i = 0; i < cars.Count - 1; i++)
                {
                    if (lowToHigh)
                    {
                        if (cars[i].Price > cars[i + 1].Price)
                        {
                            Car temp = cars[i];
                            cars[i] = cars[i + 1];
                            cars[i + 1] = temp;
                        }
                    }else
                    {
                        if (cars[i].Price < cars[i + 1].Price)
                        {
                            Car temp = cars[i];
                            cars[i] = cars[i + 1];
                            cars[i + 1] = temp;
                        }

                    }
                }
            }

            for (int x = 0; x < vans.Count; x++)
            {
                for (int i = 0; i < vans.Count - 1; i++)
                {
                    if (lowToHigh)
                    {
                        if (vans[i].Price > vans[i + 1].Price)
                        {
                            Van temp = vans[i];
                            vans[i] = vans[i + 1];
                            vans[i + 1] = temp;
                        }
                    }
                    else
                    {
                        if (vans[i].Price < vans[i + 1].Price)
                        {
                            Van temp = vans[i];
                            vans[i] = vans[i + 1];
                            vans[i + 1] = temp;
                        }

                    }
                }
            }

        }
        static void applyFilters(Car inputVehicle)
        {

            bool pass = true;

            switch (transmissionType.ToLower())
            {
                case "any":
                    
                    break;
                case "manual":
                    if (!inputVehicle.Manual)
                    {
                        pass = false;
                    }
                    break;

                case "automatic":
                    if (inputVehicle.Manual)
                    {
                        pass = false;
                    }
                    break;

            }
            

            switch (fuelType.ToLower())
            {
                case "any":

                    break;
                case "petrol":
                    if (inputVehicle.FuelType.ToLower() != "petrol")
                    {
                        pass = false;
                    }
                    break;

                case "diesel":
                    if (inputVehicle.FuelType.ToLower() != "diesel")
                    {
                        pass = false;
                    }
                    break;
            }

            switch (doorsType.ToLower())
            {
                case "any":

                    break;
                case "2 doors":
                    if (inputVehicle.Doors !=2)
                    {
                        pass = false;
                    }
                    break;

                case "4+ doors":
                    if (inputVehicle.Doors < 4)
                    {
                        pass = false;
                    }
                    break;
            }
            
            if (pass)
            {
                availableCars.Add(inputVehicle);
            }
        }
        static void applyFilters(Van inputVehicle)
        {

            bool pass = true;

            switch (transmissionType.ToLower())
            {
                case "any":

                    break;
                case "manual":
                    if (!inputVehicle.Manual)
                    {
                        pass = false;
                    }
                    break;

                case "automatic":
                    if (inputVehicle.Manual)
                    {
                        pass = false;
                    }
                    break;

            }


            switch (fuelType.ToLower())
            {
                case "any":

                    break;
                case "petrol":
                    if (inputVehicle.FuelType.ToLower() != "petrol")
                    {
                        pass = false;
                    }
                    break;

                case "diesel":
                    if (inputVehicle.FuelType.ToLower() != "diesel")
                    {
                        pass = false;
                    }
                    break;
            }

            switch (wheelbase.ToLower())
            {
                case "any":

                    break;
                case "long":
                    if (inputVehicle.Wheelbase != 'l')
                    {
                        pass = false;
                    }
                    break;

                case "short":
                    if (inputVehicle.Wheelbase != 's')
                    {
                        pass = false;
                    }
                    break;
            }

            if (pass)
            {
                availableVans.Add(inputVehicle);
            }
        }
        static bool available(Vehicle inputVehicle)
        {
            if (inputVehicle.Available)
            {
                return true;
            }
            else
            {
                if (inputVehicle.AvailableOn.CompareTo(DateTime.Now) < 0)
                {
                    inputVehicle.Available = true;
                    saveChanges(inputVehicle);
                    return true;
                }

                return false;
            }
        }
        static bool notInList(Vehicle inputVehicle)
        {
            Car c = new Car();


            if (inputVehicle.GetType() == c.GetType())
            {
                for (int i = 0; i < availableCars.Count; i++)
                {
                    if (availableCars[i].getName() == inputVehicle.getName())
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < availableVans.Count; i++)
                {
                    if (availableVans[i].getName() == inputVehicle.getName())
                        return false;
                }
            }
            return true;
        }
        public static void saveChanges(Vehicle inputVehicle)
        {
            if (validConnection)
            {
                // DatabaseOperations.updateVehicle(test);
                DatabaseOperations.writeHire(inputVehicle);
                FileOperations.writeFile(cars, vans);
            }
            else
            {
                writeFile();
            }


        }
    }
}
