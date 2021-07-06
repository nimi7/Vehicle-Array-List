using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;


namespace VehicleArrayList
{
    [Serializable]

    class Cars : Vehacle 
    {
        string fourdoors;// ארבע דלתות

        public string FourDoors
        {
            set { this.fourdoors = value; }
            get { return fourdoors; }
        }

        public Cars()
        {

        }

        public Cars(string company, string model, int year, string carnumber,string fourdoors)
            :base(company,model,year,carnumber)
        {
            this.FourDoors = fourdoors;

        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string ft = string.Format("----Category:[Car]----\ncompany:{0}\nModel:{1}\nYear:{2}\nCar Number:{3}\n", Company,Model,Year,CarNUmber);
            return ft;
        }
    }
}
