using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem
{
    class Client
    {
        public string name { get; set; }
        public string Email { get; set; }
        public Guid id { get; set; }
        public int phone { get; set; }
        public bool _isCarteAvailible;
        public bool IsCarteAvailible
        {
            set
            {
                if (value == false)
                {
                    Console.WriteLine("Sorry you dont have the identity ");
                    System.Environment.Exit(0);
                }
                else
                {
                    _isCarteAvailible = value;
                }
            }
            get
            {
                return _isCarteAvailible;
            }
        }

        public Client(string name, string email, Guid id, int phone, bool IsCarteAvailible)
        {
            this.IsCarteAvailible = IsCarteAvailible;
            this.name = name;
            Email = email;
            this.id = id;
            this.phone = phone;
        }
    }
    class Room
    {
        public int Number { get; set; }
        public string RoomType { get; set; }
        public double PriceParNight {  get; set; }

        public Room(int number, string roomType, double priceParNight)
        {
            Number = number;
            RoomType = roomType;
            PriceParNight = priceParNight;
        }
    }
    class Reservation
    {
        public Client c;
        public Room r;
        public double TotalPrice { get; set; }
        public DateTime dateTimeIn {  get; set; }

        public DateTime dateTimeOut { get; set; }
        public Guid ResId {  get; set; }

        public Reservation(Client c, Room r, DateTime dateTimeIn, DateTime dateTimeOut, Guid resId)
        {
            this.c = c;
            this.r = r;
            this.dateTimeIn = dateTimeIn;
            this.dateTimeOut = dateTimeOut;
            ResId = resId;

            int days = (dateTimeOut - dateTimeIn).Days;

            TotalPrice = r.PriceParNight * days;


        }
        public void Info()
        {
            Console.WriteLine($"You selected the Room:{r.Number}--{r.RoomType}--{r.PriceParNight} DH--{dateTimeIn}---{dateTimeOut}");
        }
    }
    class Payment : Reservation
    {
        public string typePayment {  get; set; }
        public double ReductionAmount
        {
            get
            {
                if(typePayment== "CarteBancaire")
                {
                   return  TotalPrice * 0.05;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        public double totalPrice { get; set; }

        public Payment(Client c, Room r, double totalPrice, DateTime dateTimeIn, DateTime dateTimeOut, Guid resId,string typePayment) : base(c, r,dateTimeIn, dateTimeOut, resId)
        {
            this.typePayment = typePayment;
            this.totalPrice = totalPrice;
        }
        public double FinalPrice()
        {
            return TotalPrice - ReductionAmount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Room> rooms = new List<Room>()
            {
                new Room(101,"Single",700),
                new Room(102,"Double",1500),
                new Room(103,"Suite",10000)
            };

            // 🎨 Header
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║      🏨 Welcome to the Booking System ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();

            // Affichage des chambres
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAvailable Rooms:");
            Console.ResetColor();

            foreach (var room in rooms)
            {
                Console.WriteLine($"🔹 Room Number: {room.Number} | Type: {room.RoomType} | Price per night: {room.PriceParNight}DH");
            }

            Console.WriteLine("\nPlease enter your details:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Name: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Email: ");
            Console.ResetColor();
            string email = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Phone Number: ");
            Console.ResetColor();
            int phone = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Do you have an identity card? (true/false): ");
            Console.ResetColor();
            bool carte = Convert.ToBoolean(Console.ReadLine());

            Client client = new Client(name, email, Guid.NewGuid(), phone, carte);

            Console.WriteLine("\nPlease enter your reservation details:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Room Type: ");
            Console.ResetColor();
            string type = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Room Number: ");
            Console.ResetColor();
            int number = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Price per night: ");
            Console.ResetColor();
            double price = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Check-in Date (yyyy-MM-dd): ");
            Console.ResetColor();
            DateTime checkIn = DateTime.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Check-out Date (yyyy-MM-dd): ");
            Console.ResetColor();
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            Room r = new Room(number, type, price);
            Reservation reservation = new Reservation(client, r, checkIn, checkOut, Guid.NewGuid());

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n📄 Reservation Summary:");
            Console.ResetColor();
            reservation.Info();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nPayment Type: ");
            Console.ResetColor();
            string pay = Console.ReadLine();

            Payment payment = new Payment(client, r, reservation.TotalPrice, checkIn, checkOut, Guid.NewGuid(), pay);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n💰 Reduction Amount: {payment.ReductionAmount} DH");
            Console.WriteLine($"🧾 Total Amount to Pay: {payment.FinalPrice()} DH");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThank you for booking with us! ✅");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}
