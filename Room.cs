using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftASM2
{
    public class Room
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Floor { get; set; }
        public int PersonalMax { get; set; }
        public string No { get; set; }

        public Room()
        {
        }

        public void Input()
        {
            Console.WriteLine("Nhap Ten Phong : ");
            Name = Console.ReadLine();

            Console.WriteLine("Nhap Gia : ");
            Price = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Nhap Tang : ");
            Floor = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Nhap so nguoi toi da : ");
            PersonalMax = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Nhap Ma Phong : ");
            No = Console.ReadLine();
        }

        public void Display()
        {
            Console.WriteLine("Room (Ten phong : {0}, Gia : {1}, Tang : {2}, So nguoi toi da : {3}," +
                                " Ma phong : {4})", Name, Price, Floor, PersonalMax, No);
        }
    }
}

