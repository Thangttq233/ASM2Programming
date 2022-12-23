using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DraftASM2;

namespace  DraftASM2
{
    public class Book
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string CMTND { get; set; }
        public string HotelNo { get; set; }
        public string RoomNo { get; set; }

        public Book()
        {
        }

        public void Input(List<Customer> customerList, List<Hotel> hotelList)
        {
            Console.WriteLine("Nhap CMTND khach hang :");
            CMTND = Console.ReadLine();

            //kiem tra thong tin khach hang
            bool isFind = false;
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].CMTND.Equals(CMTND))
                {
                    isFind = true;
                    break;
                }
            }
            //them moi khach hang
            if (!isFind)
            {
                Console.WriteLine("Khach hang chua ton tai >> nhap moi");
                Customer customer = new Customer();
                customer.CMTND = CMTND;
                customer.InputWithoutCMTND();

                customerList.Add(customer);

            }
            //nhap ma khach san.
            DisplayHotelMenu(hotelList);
            Hotel hotel = null;
            while (true)
            {
                HotelNo = Console.ReadLine();
                isFind = false;
                for (int i = 0; i < hotelList.Count; i++)
                {
                    if (hotelList[i].No.Equals(HotelNo))
                    {
                        isFind = true;
                        hotel = hotelList[i];
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nhap lai ma KS : ");
                }
            }
            //nhap ma phong.
            DisplayRoomMenu(hotel);
            while (true)
            {
                RoomNo = Console.ReadLine();
                isFind = false;

                for (int i = 0; i < hotel.roomList.Count; i++)
                {
                    if (hotel.roomList[i].No.Equals(RoomNo))
                    {
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nhap lai ma phong : ");
                }
            }
            //nhap thong tin ngay book va ngay tra
            // ends nhap thong tin khach hang
            Console.WriteLine("Ngay CheckIn (dd/mm/YYYY) : ");
            string dateTime = Console.ReadLine();
            CheckIn = ConvertStringToDatetime(dateTime);

            Console.WriteLine("Ngay CheckOut (dd/mm/YYYY) : ");
            dateTime = Console.ReadLine();
            CheckOut = ConvertStringToDatetime(dateTime);
        }

        public DateTime ConvertStringToDatetime(string value)
        {
            DateTime oDate = DateTime.ParseExact(value, "dd/MM/yyyy", null);
            return oDate;
        }

        public void DisplayHotelMenu(List<Hotel> hotelList)
        {
            for (int i = 0; i < hotelList.Count; i++)
            {
                Console.WriteLine("{0}. {1} - {2}", i + 1, hotelList[i].Name, hotelList[i].No);
            }
            Console.WriteLine("Nhap ma khach san can chon : ");

        }

        public void DisplayRoomMenu(Hotel hotel)
        {
            for (int i = 0; i < hotel.roomList.Count; i++)
            {
                Console.WriteLine("{0}. {1} - {2}", i + 1, hotel.roomList[i].Name, hotel.roomList[i].No);
            }
            Console.WriteLine("Nhap ma phong can chon : ");
        }
    }
}


