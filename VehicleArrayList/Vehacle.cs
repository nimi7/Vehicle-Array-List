using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Collections;


namespace VehicleArrayList
{
    [Serializable]

    class Vehacle //: IComparable
    {
        string company;
        string model;
        int year;
        string carnumber;

        public string Company
        {
            set { company = value; }
            get { return company; }

        }
        public string Model
        {
            set { model = value; }
            get { return model; }
        }
        public int Year
        {
            set { year = value; }
            get { return year; }
        }
        public string CarNUmber
        {
            set { carnumber = value; }
            get { return carnumber; }
        }



        public Vehacle()
        {


        }

        public Vehacle(string company, string model, int year,string carnumber)
        {
            Company = company;
            this.Year = year;
            this.Model = model;
            this.CarNUmber = carnumber;

        }


        public override string ToString()
        {
            string st = string.Format("Car: {0},\nModel: {1},\nProduction: {2},\nCarNUmber {3},!", this.Company, this.Model, this.Year, this.CarNUmber);

            return st;
        }
        public string ToStringToFIle()
        {
            string st = string.Format("{0},{1},{2},{3},", this.company, this.Model, this.Year, this.CarNUmber);
            return st;
        }

        //public int CompareTo(object obj)
        //{
        //    Vehacle v = null;
        //    if(obj is Vehacle)
        //    {
        //        v = (Vehacle)obj;
        //    }
        //    if(v.Year > this.Year)
        //       return -1;
        //    if( v.Year < this.Year)
        //       return 1;
        //    return 0;
        //}
        
       
    }
}
    

