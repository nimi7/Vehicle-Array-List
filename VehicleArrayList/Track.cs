using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;

namespace VehicleArrayList
{
    [Serializable]

    class Track : Vehacle
    {
        string cargo; // מטען חורג

        public string Cargo
        {
            set { cargo = value; }
            get { return cargo; }

        }

        public Track()
        {


        }
        public Track(string company, string model, int year, string carnumber, string cargo)
            : base(company, model, year, carnumber)
        {
            this.Cargo = cargo;
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string f = string.Format("----Category:[Track]----\nCompany:{0}\nModel:{1}\nYear:{2}\nTrack Number:{3}\nCarry Wight: {4}", Company,Model,Year,CarNUmber,Cargo);
            return f;

        }
       
    }
}
