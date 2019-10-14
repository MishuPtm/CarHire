using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{
    class Car : Vehicle
    {
        int doors, seats;
        string body;

        public int Doors
        {
            get
            {
                return doors;
            }

            set
            {
                doors = value;
            }
        }

        public int Seats
        {
            get
            {
                return seats;
            }

            set
            {
                seats = value;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }

            set
            {
                body = value;
            }
        }

        public override string getDetails()
        {
            return base.getDetails()
                +"\nNb of seats "+seats
                +"\nNb of doors "+doors
                +"\nBody type "+body
                +"\nPrice "+Price;
        }
        public override string formatLine()
        {
            return "car"+base.formatLine()+doors + "|" +seats + "|" +body + "|";
        }
        

    }
}
