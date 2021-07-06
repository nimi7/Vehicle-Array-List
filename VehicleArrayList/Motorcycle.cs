using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;


namespace VehicleArrayList
{
    [Serializable]

    class Motorcycle : Vehacle
    {

        string twowheel; // גלגלים


        public string TwoWhell
        {
            set { twowheel = value; }
            get { return twowheel; }
        }

        public Motorcycle()
        {

        }

        public Motorcycle(string company, string model, int year, string carnumber,string twowheel)
            :base(company,model,year,carnumber)
        {
            this.TwoWhell = twowheel;

        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string st = string.Format("----Category:[Motorcycle]----\nCompany:{0}\nModel:{1}\nYear:{2}\nMotorcycle Number:{3}\n", Company,Model,Year,CarNUmber);
            return st;
        }
        
    }
}
