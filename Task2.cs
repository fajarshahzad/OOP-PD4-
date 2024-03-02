using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDT2
{
    using System;

    class Angle
    {
        public int degrees;
        public float minutes;
        public char direction;

        public Angle(int deg, float min, char dir)
        {
            degrees = deg;
            minutes = min;
            direction = dir;
        }

        public void SetAngle(int deg, float min, char dir)
        {
            degrees = deg;
            minutes = min;
            direction = dir;
        }

        public string ToStringFormat()
        {
            return $"{degrees}\u00b0{minutes}' {direction}";
        }
    }

    class Ship
    {
        public string shipNumber;
        public Angle latitude;
        public Angle longitude;


        public string SerialNumber
        {
            get { return shipNumber; }
            set { shipNumber = value; }
        }

        public Ship(string number, Angle lat, Angle lon)
        {
            shipNumber = number;
            latitude = lat;
            longitude = lon;
        }

        public void PrintPosition()
        {
            Console.WriteLine($"Ship is at{latitude.ToStringFormat()} and {longitude.ToStringFormat()}");
        }

        public void PrintSerialNumber()
        {
            Console.WriteLine($"Ship's Serial Number is : {shipNumber}");
        }

        public void ChangePosition(Angle newLat, Angle newLon)
        {
            latitude = newLat;
            longitude = newLon;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Ship>ships= new List<Ship>();
            int option=0;
            while (option!=5)
            {
                Console.Clear();
                option = DisplayMenu();
                if(option==1)
                {
                    Console.Write("Enter Ship Number: ");
                    string number = (Console.ReadLine());

                    Console.WriteLine("Enter Ship Latitude:");
                    Console.Write("Enter Latitude's Degrees: ");
                    int latDeg = int.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude's Minutes: ");
                    float latMin = float.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude's Direction: ");
                    char latDir = char.ToUpper(Console.ReadLine()[0]);

                    Console.WriteLine("Enter Ship Longitude:");
                    Console.Write("Enter Longitude's Degrees: ");
                    int lonDeg = int.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude's Minutes: ");
                    float lonMin = float.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude's Direction: ");
                    char lonDir = char.ToUpper(Console.ReadLine()[0]);

                    Angle latitude = new Angle(latDeg, latMin, latDir);
                    Angle longitude = new Angle(lonDeg, lonMin, lonDir);
                    Ship ship = new Ship(number, latitude, longitude);
                    ship.SerialNumber = number; // Set the serial number
                    ships.Add(ship);
                }
                if(option==2)
                {
                    Console.Write("Enter Ship Serial Number to find its position: ");
                    string viewShipNumber = Console.ReadLine();

                    var viewShip = ships.Find(ship => ship.SerialNumber == viewShipNumber);
                    if (viewShip != null) 
                        viewShip.PrintPosition();
                    else
                        Console.WriteLine("Ship not found.");
                }
                 if(option==3)
                {
                    Console.Write("Enter ship number: ");
                    string viewSerialNumber = Console.ReadLine();

                    var viewShip = ships.Find(ship => ship.SerialNumber == viewSerialNumber);
                    if (viewShip != null)
                        viewShip.PrintSerialNumber();
                    else
                        Console.WriteLine("Ship not found.");
                }
                 if(option==4)
                {
                    Console.Write("Enter Ship’s serial number whose position you want to change: ");
                    string changeShipNumber = Console.ReadLine();

                    var changeShip = ships.Find(ship => ship.SerialNumber == changeShipNumber);
                    if (changeShip != null)
                    {
                        Console.WriteLine("Enter Ship Latitude:");
                        Console.Write("Enter Latitude's Degrees: ");
                        int newLatDeg = int.Parse(Console.ReadLine());
                        Console.Write("Enter Latitude's Minutes: ");
                        float newLatMin = float.Parse(Console.ReadLine());
                        Console.Write("Enter Latitude's Direction: ");
                        char newLatDir = char.ToUpper(Console.ReadLine()[0]);

                        Console.WriteLine("Enter Ship Longitude:");
                        Console.Write("Enter Longitude's Degrees: ");
                        int newLonDeg = int.Parse(Console.ReadLine());
                        Console.Write("Enter Longitude's Minutes: ");
                        float newLonMin = float.Parse(Console.ReadLine());
                        Console.Write("Enter Ltude's Direction: ");
                        char newLonDir = char.ToUpper(Console.ReadLine()[0]);

                        var newLatitude = new Angle(newLatDeg, newLatMin, newLatDir);
                        var newLongitude = new Angle(newLonDeg, newLonMin, newLonDir);

                        changeShip.ChangePosition(newLatitude, newLongitude);
                        Console.WriteLine("Ship position changed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Ship not found.");
                    }
                }
                 if(option==5)
                {
                    Console.WriteLine("Exiting program.");

                }
                Console.WriteLine("Press any key to Continue");
                Console.ReadKey();
                }
            }
        static int DisplayMenu()
        {
            Console.WriteLine("Shiping Control System");
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
        again:
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice <= 0 || choice > 5)
            {
                Console.WriteLine("Invalid Choice:(..Try Again!");
                goto again;
            }

            return choice;
        }
    }

}
