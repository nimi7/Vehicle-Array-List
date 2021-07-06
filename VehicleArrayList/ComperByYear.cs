using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleArrayList
{
    class ComperByYear : IComparer<Vehacle>
    {

        public int Compare(Vehacle x, Vehacle y)
        {
            if ((x.Year.CompareTo(y.Year) == 0))
                return 0;

            if ((x.Year.CompareTo(y.Year) == 1))
                return 1;
            else
                return -1;


        }
    }
}
