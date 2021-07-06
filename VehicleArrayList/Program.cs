using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;




namespace VehicleArrayList
{
    class Program // פרויקט של רכבים עם מערך של ליסט //
    {

        static List<Vehacle> array = new List<Vehacle>(); //Cars , Tracks , Bysecels

        static string BinaryFilePath = "BinaryFileVehicles.txt";

        static string StreamWritherPath = @"C:\Users\NewMyVehicle.txt";


        static void Main(string[] args)
        {

            VehicleMenu();

        }



        //============================================================================--------------------===============
        //=========================================================================  ||  Sort Functions + enum  || =================
        //                                                                             --------------------------

        static void SortListByYear() // מסדר לפי שנה
        {
            ComperByYear a = new ComperByYear();
            array.Sort(a);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|Sorting LIst By Year -SecssesFull|");
            Console.WriteLine("-----------------------------------");
        }

        static void SortListByCompeny() // מסדר לפי חברה
        {
            CompareByCompay a = new CompareByCompay();

            array.Sort(a);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("________________________________________");
            Console.WriteLine("Sorting LIst By Company -SecssesFull-^_^");
            Console.WriteLine("````````````````````````````````````````");

        }

        static void SortLIstByCompanyAndYear()
        {
           SortListByYear(); // מסדר לפי שנים
            SortListByCompeny();//  מסדר לפי חברה
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Sorting LIst By Year And Company -SecssesFull-^_^");
            Console.WriteLine("`````````````````````````````````````````````````");
        } // מסדר רשימה לפי שנה + חברה

        enum SortOptionEnum
        {
            SortBy_Year = 1,
            SortBy_Company = 2,
            SortBy_Company_And_Year = 3,

        }

        static SortOptionEnum SortMenuEnum()
        {
            SortOptionEnum cases;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                       ==============================");
            Console.WriteLine("                      ||>>>>>>Sorting Menu ^_^<<<<<<||");
            Console.WriteLine("                       ==============================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==========================================================");
            Console.WriteLine("Press -1- To Sort Vehicle Data By >>>Year<<<");
            Console.WriteLine("==========================================================");
            Console.WriteLine("Press -2- To Sort Vehicle Data By >>>Company<<<");
            Console.WriteLine("==========================================================");
            Console.WriteLine("Press -3- To Sort Vehicle Data By >>>Year -And- Company<<<");
            Console.WriteLine("==========================================================");

            Enum.TryParse(Console.ReadLine(), out cases);
            return cases;

        }

        static void SortMenu()
        {
            SortOptionEnum h = SortMenuEnum();
            switch (h)
            {
                case SortOptionEnum.SortBy_Year:
                    SortListByYear();
                    break;
                case SortOptionEnum.SortBy_Company:
                    SortListByCompeny();
                    break;
                case SortOptionEnum.SortBy_Company_And_Year:
                    SortLIstByCompanyAndYear();
                    break;
                default:
                    break;
            }


        }

        //============================================================================--------------------===============
        //=========================================================================  ||  Search Functions + enum  || =================
        //                                                                             -------------------------

        static void SearchByYearAndCompany() // חיפוש לפי שנה וחברה
        {

            Console.WriteLine("=================================================");
            Console.WriteLine("Enter The --Company-- Of Vehicle You want To Find");
            string company = Console.ReadLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Enter The --Year-- Of Vehicle You Want TO Find");
            int year = RightInt();

            for (int i = 0; i < array.Count; i++)
            {
                Vehacle car = (Vehacle)array[i];
                if ((car.Company == company) && (car.Year == year))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("===============================");
                    Console.WriteLine("All The Vehicles Of {0} in {1}:", car.Company, car.Year);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("==============================");
                    Console.WriteLine(car.ToString());
                    Console.WriteLine("==============================");

                }


            }

        }

        static void SearchByYear()
        {

            Console.WriteLine("Enter The Year of The Vehicle You Want To Find");
            int name = RightInt();

            for (int i = 0; i < array.Count; i++)
            {
                Vehacle car = (Vehacle)array[i];
                if (car.Year == name)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("===============================");
                    Console.WriteLine("All The Vehicles Of {0} ^_^", name);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("==============================");
                    Console.WriteLine(car.ToString());
                    Console.WriteLine("==============================");

                }


            }
        } // חיפוש רכב לפי שנה

        static void SearchByCompany()
        {

            Console.WriteLine("Enter The Name Of Company You Want To Find");
            string name = Console.ReadLine();

            for (int i = 0; i < array.Count; i++)
            {
                Vehacle car = (Vehacle)array[i];
                if (car.Company == name)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("===============================");
                    Console.WriteLine("All The Vehicles Of {0} ^_^", name);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("==============================");
                    Console.WriteLine(car.ToString());
                    Console.WriteLine("==============================");


                }


            }
        } // חיפוש רכב לפי חברה

        static EnumChooseSearchMenu EnumAllSearchMenu() // תפריט חיפוש
        {
            EnumChooseSearchMenu cases;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                    ------------------------------");
            Console.WriteLine("                   ||       SearchingMenu ^_^   ||");
            Console.WriteLine("                    ------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press -1- To Seach Vehcle By >>Company<<:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Press -2- To Search Vehcle By >>Year<<:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Press -3- To Search Vehcle By >>Company And Year<<");
            Console.WriteLine("--------------------------------------------------");
            Enum.TryParse(Console.ReadLine(), out cases);
            return cases;

        }

        enum EnumChooseSearchMenu // אופציות תפריט חיפוש
        {
            SearchByCompany = 1,
            SearchByYear = 2,
            SearchByYearAndCompany = 3,
        }

        static void SearchMenu() // סוויצ תפריט חיפוש
        {
            EnumChooseSearchMenu ch = EnumAllSearchMenu();
            switch (ch)
            {
                case EnumChooseSearchMenu.SearchByCompany:
                    SearchByCompany();
                    break;
                case EnumChooseSearchMenu.SearchByYear:
                    SearchByYear();
                    break;
                case EnumChooseSearchMenu.SearchByYearAndCompany:
                    SearchByYearAndCompany();
                    break;
                default:
                    break;
            }
        }

        //============================================================================--------------------===============
        //=========================================================================  ||  Main_Menu Functions  || =================
        //                                                                             --------------------


        enum EnumOptionsMenu // אופציות תפריט ראשי
        {
            GetVehicleData = 1, // GetCar...GetTrack...GetMotorCycle//
            PrintData_ToConsole = 2,

            SaveData_ToBinaryFile = 3,

            GetData_FromBinaryFile = 4,


            UpDate_Vehicle = 5,// UpDate By CarNumber//

            Add_Vehicle = 6,

            Remove_Vehicle = 7,// Remove By CarNumber//

            SortVehicle = 8, // ByCompany...ByYear...ByYearAndCompany//

            SearchVehicle = 9,// Search By Company...Search By Year...Search By YearAndCompany



            Report_Data = 10,

            Exit = 11,



        }

        static void VehicleMenu()
        {
            do
            {


                EnumOptionsMenu Options = OptionsMenu();
                Console.Clear();
                switch (Options)
                {
                    case EnumOptionsMenu.GetVehicleData: //1
                        VehicleSetData();
                        break;
                    case EnumOptionsMenu.PrintData_ToConsole://2
                        PrintVehicleToConsol();
                        break;
                    case EnumOptionsMenu.SaveData_ToBinaryFile://3
                        WriteFileToBinary();
                        break;
                    case EnumOptionsMenu.GetData_FromBinaryFile://4
                        ReadFileBinary();
                        break;
                    case EnumOptionsMenu.UpDate_Vehicle://5
                        UpDateMyVehicle();
                        break;
                    case EnumOptionsMenu.Add_Vehicle://6
                        AddingMenuVehicleOptions();
                        break;
                    case EnumOptionsMenu.Remove_Vehicle://7
                        DeleteCar();
                        break;
                    case EnumOptionsMenu.SortVehicle://8
                        SortMenu();
                        break;
                    case EnumOptionsMenu.SearchVehicle://9
                        SearchMenu();
                        break;
                    case EnumOptionsMenu.Report_Data://10
                        Doh();
                        break;
                    case EnumOptionsMenu.Exit://11
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Your Choose Is not avalible choose 1-11");
                        Console.WriteLine("=======================================");
                        Console.ReadLine();
                        break;
                }
                Console.ReadLine();

                // Console.Clear();
            } while (true);
        } // פונקציות בתפריט

        static EnumOptionsMenu OptionsMenu()
        {

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("                                 ============================");
            Console.WriteLine("                                ||>>Welcome To The Project<<||");
            Console.WriteLine("                                 ============================");



            EnumOptionsMenu cases;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===================================================================");
            Console.WriteLine("Get your Vehicles To Seystem : Click number 1\n================================================================");
            Console.WriteLine("Print All Vehicle Data To The Screen : Click number 2\n================================================================");

            Console.WriteLine("Save Vehicles Into a File >>>>(BinaryFile)<<<< : Click number 3\n================================================================");
            Console.WriteLine("Get Data From a File >>>>(BinaryFile)<<<: Click number 4\n================================================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Update Your Car Informasion : Click number 5\n================================================================");
            Console.WriteLine("To Add a Vehacle to your Seystem : Click number 6\n================================================================");
            Console.WriteLine("To Remove A Car from Your Seystem : Click number 7\n================================================================");

            Console.WriteLine("To Go To the >>>> Sort Menu <<<< : Click Number 8\n================================================================");

            Console.WriteLine("Search Vehicle : Click number 9\n================================================================");
            
            Console.WriteLine("Report Data : Click number 10 -\n================================================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Exit The program : Click Number 11\n================================================================");

            Console.WriteLine("==================================================================");
            Console.WriteLine("Choose One Of The Options");
            Enum.TryParse(Console.ReadLine(), out cases);
            return cases;



        } // תפריט ראשי של הקונסול

        //============================================================================--------------------===============
        //====================================================================||  Absorption Functions + enum  || =================
        //                                                                       -----------------------------

        static Cars GetNewCar()
        {
           
            Cars car = new Cars();
            Console.WriteLine("enter A company");
            car.Company = Console.ReadLine();
            Console.WriteLine("-------------------------");

            Console.WriteLine("enter A Model");
            car.Model = Console.ReadLine();
            Console.WriteLine("-------------------------");

            Console.WriteLine("enter A Year");
            car.Year = RightInt();
            Console.WriteLine("-------------------------");

            Console.WriteLine("enter the number of car");
            car.CarNUmber = Console.ReadLine();
            Console.WriteLine("-------------------------");

            Console.WriteLine("Enter Number of Doors");
            car.FourDoors = Console.ReadLine();
            Console.WriteLine("-------------------------");

            return car;
        }
        static void GetCarToList()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     =============================");
            Console.WriteLine("                    ||       Car information    ||");
            Console.WriteLine("                     =============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
  
            Console.WriteLine("How much Cars U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter Car information Please ^_^");
            Console.WriteLine("````````````````````````````````");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("==========");
                array.Add(GetNewCar());
                Console.WriteLine("==========");
            }

        }

        static Track GetNewTrack()
        {
            Track tk = new Track();

            Console.WriteLine("enter A company");
            tk.Company = Console.ReadLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("enter A Model");
            tk.Model = Console.ReadLine();
            Console.WriteLine("---------------------------");

            Console.WriteLine("enter A Year");
            tk.Year = RightInt();
            Console.WriteLine("---------------------------");

            Console.WriteLine("enter the number of car");
            tk.CarNUmber = Console.ReadLine();
            Console.WriteLine("---------------------------");

            Console.WriteLine("How Much The Vehicle Can carry?");
            tk.Cargo = Console.ReadLine();
            Console.WriteLine("---------------------------");

            return tk;

        }
        static void GetTrackToLIst()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     =============================");
            Console.WriteLine("                    ||       Track information    ||");
            Console.WriteLine("                     =============================");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How much Tracks Do U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter Track information Please ^_^");
            Console.WriteLine("````````````````````````````````");

            for (int i = 0; i < size; i++)
            {
                array.Add(GetNewTrack());
            }
        }

        static Motorcycle GetNewMotorcycle()
        {
            Motorcycle mc = new Motorcycle();

            Console.WriteLine("Enter Name Of Motorcycle company:");
            mc.Company = Console.ReadLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Enter Model of Motorcycle:");
            mc.Model = Console.ReadLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Enter year OF Motoracycle:");
            mc.Year = RightInt();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter The number of The Motorcycle:");
            mc.CarNUmber = Console.ReadLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter Number OF Whell:");
            mc.TwoWhell = Console.ReadLine();
            Console.WriteLine("----------------------------------");

            return mc;

        }
        static void GetMotorcycleToList()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     =============================");
            Console.WriteLine("                    ||       MotorCycle information    ||");
            Console.WriteLine("                     =============================");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How much MotorCycle U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter MotorCycle information Please ^_^");
            Console.WriteLine("````````````````````````````````");
            for (int i = 0; i < size; i++)
            {
                array.Add(GetNewMotorcycle());

            }
        }

        static SUV GetNewSuv()
        {
            SUV s = new SUV();
            Console.WriteLine("enter A company");
            s.Company = Console.ReadLine();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("enter A Model");
            s.Model = Console.ReadLine();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("enter A Year");
            s.Year = RightInt();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("enter the number of car");
            s.CarNUmber = Console.ReadLine();
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Enter Number of Seats");
            s.Seats = Console.ReadLine();
            Console.WriteLine("----------------------------------");

            return s;
        }
        static void GetSuvToList()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     =============================");
            Console.WriteLine("                    ||       SUV information    ||");
            Console.WriteLine("                     =============================");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How much Suvs U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter Suvs information Please ^_^");
            Console.WriteLine("````````````````````````````````");
            for (int i = 0; i < size; i++)
            {
                array.Add(GetNewSuv());

            }

        }
        
        static void VehicleSetData()
        {
            if (array.Count == 0)
            {

                VehicleSetDataOptions d = VehicleChooseMenuSetData();
                switch (d)
                {
                    case VehicleSetDataOptions.SetDataCar:
                        GetCarToList();
                        break;
                    case VehicleSetDataOptions.SetTrack:
                        GetTrackToLIst();
                        break;
                    case VehicleSetDataOptions.SetMotoCycle:
                        GetMotorcycleToList();
                        break;
                    case VehicleSetDataOptions.SetSuv:
                        GetSuvToList();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=============================================================");
                Console.WriteLine("||         You Allready Have Data On your Program           ||");
                Console.WriteLine("=============================================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                ");
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Return To Main Menu And Choose -6- to Add a Vehicle To Program");
                Console.WriteLine("Thank You ^_^");
                Console.WriteLine("-----------------------------------------------------------------");

            }

        }

        static VehicleSetDataOptions VehicleChooseMenuSetData()
        {
            VehicleSetDataOptions cs;
            Console.WriteLine("                   ---------------------------");
            Console.WriteLine("                   ||   Absorption Menu  ^_^ ||");
            Console.WriteLine("                   ---------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|Which Vehicle Do you want To Get To data |");
            Console.WriteLine("`-----------------------------------------`");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press -1- If you Want Enter A Car...");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press -2- If You want Enter A Track...");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press -3- If You want Enter A MotoCycle...");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press -4- If You want Enter A SUV...");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enter Your Choose Here:");
            Enum.TryParse(Console.ReadLine(), out cs);
            return cs;


        }

        enum VehicleSetDataOptions
        {
            SetDataCar = 1,
            SetTrack = 2,
            SetMotoCycle = 3,
            SetSuv = 4,

        }

        //============================================================================--------------------===============
        //=========================================================================  ||  Adding Functions + enum  || =================
        //                                                                             --------------------------

        static void AddCar()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     ===================================");
            Console.WriteLine("                    ||      Adding Car information    ||");
            Console.WriteLine("                     ===================================");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How much Cars U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter Car information Please ^_^");
            Console.WriteLine("````````````````````````````````");

            for (int i = 0; i < size; i++)
            {
                array.Add(GetNewCar());

            }

        }

        static void AddTrack()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     ===================================");
            Console.WriteLine("                    ||      Adding Track information    ||");
            Console.WriteLine("                     ===================================");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How much Track U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter Track information Please ^_^");
            Console.WriteLine("````````````````````````````````");

            for (int i = 0; i < size; i++)
            {
                array.Add(GetNewTrack());
            }
        }

        static void AddMotoracycle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     ===================================");
            Console.WriteLine("                    ||      Adding MotorCycle information    ||");
            Console.WriteLine("                     ===================================");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How much MotorCycle U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter MotoCycle information Please ^_^");
            Console.WriteLine("````````````````````````````````");

            for (int i = 0; i < size; i++)
            {
                array.Add(GetNewMotorcycle());
            }
        }

        static void AddSuv()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     ===================================");
            Console.WriteLine("                    ||      Adding SUV information    ||");
            Console.WriteLine("                     ===================================");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How much SUV U want to get to your program");
            int size = RightInt();
            Console.WriteLine("Enter SUV information Please ^_^");
            Console.WriteLine("````````````````````````````````");

            for (int i = 0; i < size; i++)
            {
                array.Add(GetNewSuv());
            }

        }

        static void AddingMenuVehicleOptions()
        {
            VehicleAddChoose c = VehicleChooseMenu();
            switch (c)
            {
                case VehicleAddChoose.AddCar:
                    AddCar();
                    break;
                case VehicleAddChoose.AddTrack:
                    AddTrack();
                    break;
                case VehicleAddChoose.AddMotorcycle:
                    AddMotoracycle();
                    break;
                case VehicleAddChoose.AddSuv:
                    AddSuv();
                    break;
                default:
                    break;
            }
        }

        static VehicleAddChoose VehicleChooseMenu()
        {
            VehicleAddChoose cs;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                      -----------------------");
            Console.WriteLine("                      ||   Adding Menu ^_^   ");
            Console.WriteLine("                      -----------------------");


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|Which Vehacle Do U Want To Add?|");
            Console.WriteLine("`--------------------------------`");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press -1- To Add A Car:");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Press -2- To Add A Track:");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Press -3- To Add A MotorCycle:");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Press -4- To Add A Suv:");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Your Choose Here:");
            Enum.TryParse(Console.ReadLine(), out cs);
            return cs;


        }

        enum VehicleAddChoose
        {
            AddCar = 1,
            AddTrack = 2,
            AddMotorcycle = 3,
            AddSuv = 4,
        }

        //============================================================================--------------------===============
        //===========================================================||   Binary Writher + Reader Function  || =================
        //                                                             --------------------------------------

        static void WriteFileToBinary()
        {
            if (array.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------");
                Console.WriteLine("You Have Nothing on Your List");
                Console.WriteLine("------------------------------");
            }
            else
            {
                FileStream fs = new FileStream(BinaryFilePath, FileMode.Create, FileAccess.Write);
                BinaryFormatter bw = new BinaryFormatter();

                bw.Serialize(fs, array);

                fs.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------");
                Console.WriteLine("|| Data Save Seccses ^_^ ||");
                Console.WriteLine("---------------------------");
            }

        }

        static void ReadFileBinary()
        {
            if (File.Exists(BinaryFilePath))
            {
                FileStream fs = new FileStream(BinaryFilePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                array = (List<Vehacle>)bf.Deserialize(fs);

                fs.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------");
                Console.WriteLine("||Reading Secsuss!^_^|| ");
                Console.WriteLine("----------------------");


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------------");
                Console.WriteLine("||Reading Feiled!!! ||");
                Console.WriteLine("---------------------");
            }


        }

        //============================================================================--------------------===============
        //===========================================================||   Stream Writher + Reader Function  || =================
        //                                                             --------------------------------------

        static void SaveToNotepad()
        {
            if (File.Exists(StreamWritherPath))
            {


                StreamWriter writer = new StreamWriter(StreamWritherPath);
                for (int i = 0; i < array.Count; i++)
                {
                    Vehacle car = (Vehacle)array[i];
                    writer.WriteLine(car.ToString());

                }

                writer.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Data Save Secssesful > Stream-Writher < ^_^");
                Console.WriteLine("-------------------------------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Saving Data Failed >Stream-Writher< ;( ");
                Console.WriteLine("---------------------------------------");

            }
        }

        static void ReadFromNotped()
        {

            if (File.Exists(StreamWritherPath))
            {


                FileStream fs = new FileStream(StreamWritherPath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string result;



                while ((result = reader.ReadLine()) != null)
                {


                    string[] text = result.Split(',');

                    Vehacle s = new Vehacle();

                    s.Company = text[0];

                    s.Model = text[1];

                    s.Year = int.Parse(text[2]);

                    s.CarNUmber = text[3];


                    array.Add(s);



                }

                fs.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Reading Seccess >StreamReadeR<");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Reading >StreamReader< Failed");
            }
        }

        //============================================================================--------------------===============
        //=========================================================================  ||   Update - Function || =================
        //                                                                             --------------------------

        static void UpDateMyVehicle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                      ----------------------------");
            Console.WriteLine("                      ||    Vehicle Update ^_^  ||");
            Console.WriteLine("                      ----------------------------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter your Car Number you want to Update?");
            Console.WriteLine("========================================");
            string num = Console.ReadLine();
            Track t = new Track();
            SUV s = new SUV();
            Motorcycle M = new Motorcycle();
            Cars c = new Cars();

            

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < array.Count; i++)
            {
                Vehacle car = (Vehacle)array[i];

                if (car.CarNUmber == num)
                {
                    Console.WriteLine("Do you want to UpDate the company? prees Y/N");
                    Console.WriteLine("--------------------------------------------");
                    bool choose = Answer();
                    if (choose == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("The Old Company of the Vehicle Was:>>>{0}<<<", car.Company);
                        Console.WriteLine("-------------------------------------------");
                        car.Company = Console.ReadLine();
                    }
                    Console.WriteLine("Do you want to UpDate the Model? prees Y/N");
                    choose = Answer();
                    if (choose == true)
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("The Old Model of the Vehicle Was:>>>{0}<<<", car.Model);
                        Console.WriteLine("--------------------------------------------");
                        car.Model = Console.ReadLine();
                       
                    }
                    Console.WriteLine("Do you want to UpDate the year? prees Y/N");
                    choose = Answer();
                    if (choose == true)
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("The Old Year of the Vehicle Was:>>>{0}<<<", car.Year);
                        Console.WriteLine("--------------------------------------------");
                        car.Year = int.Parse(Console.ReadLine());
                    }                   
                }           
            }
        }

        static bool Answer()
        {
            if (Console.ReadLine() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //============================================================================--------------------===============
        //=========================================================================  ||   Delete - Function || =================
        //                                                                             --------------------------

        static void DeleteCar()
        {
            Console.WriteLine("What is the number of the Car you want to Delete?");
            string num = Console.ReadLine();

            for (int i = 0; i < array.Count; i++)
            {
                Vehacle car = (Vehacle)array[i];
                if (car.CarNUmber == num)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("---------------------");
                    Console.WriteLine("The Vehicle Has Been Remover:\n {0},\n {1},\n {2},\n {3},", car.Company, car.Model, car.Year, car.CarNUmber);
                    Console.WriteLine("---------------------");
                    array.Remove(car);

                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------");
            Console.WriteLine("Deleted Vehicle Secces^_^");
            Console.WriteLine("----------------------");


        }

        //=========================================================--------------------------------------------===============
        //========================================================||   Print All Vehicles To Console - Function || =================
        //                                                         ------------------------------------------------

        static void PrintVehicleToConsol()
        {

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("-----Car Number: {0} ------", (i + 1));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(array[i].ToString());
                }

            }

        }


        static int RightInt()
        {
            int n = 0, r;
            bool answer;
            do
            {
                answer = int.TryParse(Console.ReadLine(), out r);
                if (answer)
                {
                    n = r;
                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Please Enter Number Between 0-9 !");
                    Console.WriteLine("---------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
            }
            while (answer == false);
            Console.ForegroundColor = ConsoleColor.Blue;

            return n;
        }

        static void Doh()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                          =============================");
            Console.WriteLine("                         ||  Vehicle Report ^_^     || ");
            Console.WriteLine("                          =============================");
            for (int i = 0; i < array.Count; i++)
            {
                int f = 0;


                for (int j = 0; j < array.Count; j++)
                {
                    if ((array[i].Company == array[j].Company) && (array[i].CarNUmber != array[j].CarNUmber))
                    {
                        f++;
                       

                    }

                    

                }

                Console.WriteLine("You Have {0} Vehicles Of {1} ",f + 1, array[i].Company);
                Console.WriteLine("----------------------------------------------------");

            }
            



        }












    } 


}

