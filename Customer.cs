using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftASM2
{
    public class Customer
    {
        public string CMTND { get; set; }
        public string Fullname { get; set; }
        public int Old { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public Customer()
        {
        }

        public void Input()
        {
            Console.WriteLine("Nhap CMTND : ");
            CMTND = Console.ReadLine();

            InputWithoutCMTND();

        }

        public void InputWithoutCMTND()
        {
            Console.WriteLine("Nhap Ho va Ten : ");
            Fullname = Console.ReadLine();

            Console.WriteLine("Nhap Gioi Tinh : ");
            Gender = Console.ReadLine();

            Console.WriteLine("Nhap Dia Chi : ");
            Address = Console.ReadLine();

            Console.WriteLine("Nhap Tuoi : ");
            Old = Int32.Parse(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("Thong tin KH (Ho Ten : {0}, Tuoi : {1}, CMTND : {2}, Gioi Tinh : {3}, " +
                                "Dia Chi : {4})", Fullname, Old, CMTND, Gender, Address);
        }
    }
}

