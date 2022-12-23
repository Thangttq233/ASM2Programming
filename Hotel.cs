using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftASM2
{
    public class Hotel
    {
        public string No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public List<Room> roomList = new List<Room>();

        public Hotel()
        {
        }

        public void Input()
        {
            Console.WriteLine("Nhap ma khach san ");
            No = Console.ReadLine();

            Console.WriteLine("Nhap ten khach san : ");
            Name = Console.ReadLine();

            Console.WriteLine("Nhap dia chi : ");
            Address = Console.ReadLine();

            Console.WriteLine("Loai phong khach san (VIP/NORMAL) : ");
            Type = Console.ReadLine();

            Console.WriteLine("Nhap so phong can them : ");
            int N = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Room room = new Room();
                room.Input();

                roomList.Add(room);

                Console.WriteLine("Co tiep tuc nhap hay khong ? Y/N :");
                string option = Console.ReadLine();
                if (option.ToUpper().Equals("N"))
                {
                    break;
                }

            }
        }

        public void Display()
        {
            Console.WriteLine("Hotel (Ten KS : {0}, Dia Chi : {1}, Loai phong : {2})", Name, Address, Type);
            for (int i = 0; i < roomList.Count; i++)
            {
                roomList[i].Display();
            }
        }

        public void DisplayBase()
        {
            Console.WriteLine("Hotel (Ten KS : {0}, Dia Chi : {1}, Loai phong : {2}", Name, Address, Type);
        }

    }
}
