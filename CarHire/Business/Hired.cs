using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{
    class Hired
    {
        DateTime startDate;
        DateTime returnDate;

        
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime ReturnDate
        {
            get
            {
                return returnDate;
            }

            set
            {
                returnDate = value;
            }
        }

        public Hired(DateTime start, DateTime end)
        {
            StartDate = start;
            ReturnDate = end;
        }

        public override string ToString()
        {
            return startDate.ToString()+" - "+returnDate.ToString();
        }

    }
}
