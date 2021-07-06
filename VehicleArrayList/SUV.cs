using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleArrayList
{
    [Serializable]

    class SUV : Vehacle
    {
        string seats;

        public string Seats { set { this.seats = value; } get { return this.seats; } }

        public SUV()
        {

        }
        public SUV(string company, string model, int year, string carnumber,string seats)
            : base( company,model,year,carnumber)
        {
            this.Seats = seats;
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string st = string.Format("----Category:[SUV]----\nCompany:{0}\nModel:{1}\nYear:{2}\nTrack Number:{3}\nSeats Numbers: {4}", Company,Model,Year,CarNUmber,Seats);
            return st;
        }

    }
}
