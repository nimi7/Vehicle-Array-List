using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleArrayList
{
    class CompareByCompay : IComparer<Vehacle>
    {

        public int Compare(Vehacle x, Vehacle y)
        {
            if ((x.Company.CompareTo(y.Company) == 0))
                return 0;

            if ((x.Company.CompareTo(y.Company) == 1))
                return 1;
            else
                return -1;


        }


    }
}
