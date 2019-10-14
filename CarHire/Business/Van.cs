using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{
    class Van : Vehicle
    {
        double cargoSpace;
        bool sideDoor;
        char wheelbase;//short or long

        public double CargoSpace
        {
            get
            {
                return cargoSpace;
            }

            set
            {
                cargoSpace = value;
            }
        }

        public bool SideDoor
        {
            get
            {
                return sideDoor;
            }

            set
            {
                sideDoor = value;
            }
        }

        public char Wheelbase
        {
            get
            {
                return wheelbase;
            }

            set
            {
                wheelbase = value;
            }
        }

        public override string getDetails()
        {
            string side = sideDoor ? "Yes" : "No";
            string wheelB = (wheelbase == 's') ? "Short" : "Long";
            return base.getDetails()
                +"\nCargo space "+cargoSpace+"cc"
                +"\nSide door- "+side
                +"\nWheelbase- "+wheelB;
        }

        public override string formatLine()
        {
            return "van" +base.formatLine()+cargoSpace + "|" +sideDoor.ToString() + "|" +wheelbase;
        }
       
    }
}
