using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{
    abstract class Vehicle
    {
        double price;
        int engineSize;
        string make, model, fuelType, regNumber;
        bool manual;
        DateTime availableOn;
        bool available;
        public List<Hired> hiredDates = new List<Hired>();


        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public int EngineSize
        {
            get
            {
                return engineSize;
            }

            set
            {
                engineSize = value;
            }
        }
        public string Make
        {
            get
            {
                return make;
            }

            set
            {
                make = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }
        public string FuelType
        {
            get
            {
                return fuelType;
            }

            set
            {
                fuelType = value;
            }
        }
        public bool Manual
        {
            get
            {
                return manual;
            }

            set
            {
                manual = value;
            }
        }
        public DateTime AvailableOn
        {
            get
            {
                return availableOn;
            }

            set
            {
                availableOn = value;
            }
        }
        public bool Available
        {
            get
            {
                return available;
            }

            set
            {
                available = value;
            }
        }
        public string RegNumber
        {
            get
            {
                return regNumber;
            }

            set
            {
                regNumber = value;
            }
        }
        public string getName()
        {
            return make + " " + model;
        }
        public virtual string getDetails()
        {
            string transmission = manual ? "Manual" : "Automatic";
            return getName()
                + "\nEngine size " + engineSize
                + "cc\nFuel Type " + fuelType
                + "\nTransmission " + transmission;
        }
        public override string ToString()
        {
            return make + " " + model;
        }
        public void rent(int days)
        {
            DateTime now = DateTime.Now;
            AvailableOn = now.AddMinutes(days);
            Available = false;
            CarHireClass.saveChanges(this);
            CarHireClass.updateLists();

        }
        public bool isAvailable(DateTime start, DateTime end)
        {



            if (hiredDates.Count > 1)
            {
                if (end.CompareTo(hiredDates[0].StartDate) == -1)
                {
                    
                    return true;
                }
                else if (start.CompareTo(hiredDates[hiredDates.Count - 1].ReturnDate) == 1)
                {
                    return true;
                }
                else
                {
                    for (int i = 0; i < hiredDates.Count - 1; i++)
                    {
                        if (start.CompareTo(hiredDates[i].ReturnDate) == 1 && start.CompareTo(hiredDates[i + 1].StartDate) == -1)
                        {
                            if (end.CompareTo(hiredDates[i + 1].StartDate) < 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else if (hiredDates.Count == 1)
            {
                if (start.CompareTo(hiredDates[0].StartDate) == -1)
                {
                    if (end.CompareTo(hiredDates[0].StartDate) == -1)
                    {
                        return true;
                    }

                }
                else
                {
                    if (start.CompareTo(hiredDates[0].ReturnDate) == 1)
                    {
                        return true;
                    }
                }

            }
            else
            {
                return true;

            }
            return false;
        }
        public void sortHiredList()
        {
            if (hiredDates.Count > 1)
            {
                for (int i = 0; i < hiredDates.Count; i++)
                {
                    for (int x = 0; x < hiredDates.Count - 1; x++)
                    {
                        if (hiredDates[x].StartDate.CompareTo(hiredDates[x + 1].StartDate) == 1)
                        {
                            Hired temp = hiredDates[x];
                            hiredDates[x] = hiredDates[x + 1];
                            hiredDates[x + 1] = temp;
                        }
                    }
                }
            }
        }
        public void hire(DateTime start, DateTime end)
        {
            hiredDates.Add(new Hired(start, end));
            CarHireClass.saveChanges(this);
            sortHiredList();
            
        }
        public virtual string formatLine()
        {
            string line;
            line = "|" + make + "|" + model + "|" + engineSize + "|" + fuelType + "|" + manual.ToString() + "|" + price + "|";
            return line;
        }
        public string returnDates()
        {
            string test = "";
            for (int i = 0; i < hiredDates.Count; i++)
            {
                test += hiredDates[i].ToString() + "\n";
            }

            return test;
        }
    }
}
