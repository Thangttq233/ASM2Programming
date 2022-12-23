using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DraftASM2
{
    class Program
    {
      
        public static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();
            List<Hotel> hotelList = new List<Hotel>();
            List<Book> bookList = new List<Book>();

            int choose;
            do
            {
                ShowMenu();
                choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Input(hotelList);
                        break;
                    case 2:
                        Display(hotelList);
                        break;
                    case 3:
                        InputBook(bookList, customerList, hotelList);
                        break;
                    case 4:
                        SearchAvailableBook(bookList, hotelList);
                        break;
                    case 5:
                        Statistic(bookList, hotelList);
                        break;
                    case 6:
                        Search(bookList, hotelList);
                        break;
                    case 7:
                        Console.WriteLine("Exit program");
                        break;
                    default:
                        Console.WriteLine("Input Failed");
                        break;

                }
            } while (choose != 7);
        }

        static void Search(List<Book> bookList, List<Hotel> hotelList)
        {
            if (hotelList.Count == 0)
            {
                Console.WriteLine("Khong co data!!!");
            }
            else
            {
                Console.WriteLine("Nhap CMTND can tim : ");
                string CMTND = Console.ReadLine();
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].CMTND.Equals(CMTND))
                    {
                        Hotel hotel = GetHotelByNo(hotelList, bookList[i].HotelNo);
                        if (hotel != null)
                        {
                            hotel.DisplayBase();
                        }
                    }
                }
            }
        }

        static Hotel GetHotelByNo(List<Hotel> hotelList, string hotelNo)
        {
            for (int i = 0; i < hotelList.Count; i++)
            {
                if (hotelList[i].No.Equals(hotelNo))
                {
                    return hotelList[i];
                }
            }
            return null;
        }




        static void Statistic(List<Book> bookList, List<Hotel> hotelList)
        {
            if (hotelList.Count == 0)
            {
                Console.WriteLine("Khong co data!!!");
            }
            else
            {
                for (int i = 0; i < hotelList.Count; i++)
                {
                    int total = Calculate(bookList, hotelList[i]);
                    Console.WriteLine("{0}. {1} - Doanh thu : {2}", i + 1, hotelList[i].Name, total);
                }
            }
        }
        

        static int Calculate(List<Book> bookList, Hotel hotel)
        {
            int total = 0;
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].HotelNo.Equals(hotel.No))
                {
                    int price = GetMoney(hotel.roomList, bookList[i].RoomNo);
                    DateTime date1 = Convert.ToDateTime(bookList[i].CheckOut);
                    DateTime date2 = Convert.ToDateTime(bookList[i].CheckIn);
                    TimeSpan Time = date1 - date2;
                    int TongSoNgay = Time.Days;
                    total += price * TongSoNgay;
                }
            }
            return total;
        }

        

        static int GetMoney(List<Room> roomList, string roomNo)
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                if (roomList[i].No.Equals(roomNo))
                {
                    return roomList[i].Price;
                }
            }
            return 0;
        }
        public static void SearchAvailableBook(List<Book> bookList, List<Hotel> hotelList)
        {
            if (hotelList.Count == 0)
            {
                Console.WriteLine("Khong co data!!!");
            }
            else
            {
                Console.WriteLine("Nhap ngay dat phong : ");
                string dateTime = Console.ReadLine();
                DateTime CheckIn = DateTime.ParseExact(dateTime, "dd/MM/yyyy", null);

                Console.WriteLine("Nhap ngay tra phong : ");
                dateTime = Console.ReadLine();
                DateTime CheckOut = DateTime.ParseExact(dateTime, "dd/MM/yyyy", null);
                for (int i = 0; i < hotelList.Count; i++)
                {
                    hotelList[i].DisplayBase();
                    Console.WriteLine("--- Danh sach phong trong ---");
                    List<Room> rooms = hotelList[i].roomList;
                    for (int j = 0; j < rooms.Count; j++)
                    {
                        if (CheckAvailableRoom(bookList, hotelList[i].No, rooms[j].No, CheckIn, CheckOut))
                        {
                            rooms[j].Display();
                        }
                    }
                }
            }
        }

        static bool CheckAvailableRoom(List<Book> bookList, string hotelNo, string roomNo, DateTime CheckIn, DateTime CheckOut)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                Book book = bookList[i];             
                if (book.HotelNo.Equals(hotelNo) && book.RoomNo.Equals(roomNo) && ((DateTime.Compare(book.CheckIn, CheckIn) >= 0 && DateTime.Compare(book.CheckIn, CheckOut) <= 0) || (DateTime.Compare(book.CheckOut, CheckIn) >= 0 && DateTime.Compare(book.CheckOut, CheckOut) <= 0)))
                {
                    return false;
                }
            }
            return true;
        }

       

        static void InputBook(List<Book> bookList, List<Customer> customerList, List<Hotel> hotelList)
        {
            if (hotelList.Count == 0)
            {
                Console.WriteLine("Khong co data!!!");
            }
            else
            {
                Book book = new Book();
                book.Input(customerList, hotelList);

                bookList.Add(book);
            }
        }

        static void Display(List<Hotel> hotelList)
        {
            if (hotelList.Count == 0)
            {
                Console.WriteLine("Khong co data!!!");
                return;
            }
            else
            {

                for (int i = 0; i < hotelList.Count; i++)
                {
                    hotelList[i].Display();
                }
            }
        }

        static void Input(List<Hotel> hotelList)
        {
            Console.WriteLine("Nhap so khach san can them : ");
            int N = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Hotel hotel = new Hotel();
                hotel.Input();
                hotelList.Add(hotel);

            }
            
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Nhap thong tin KS");
            Console.WriteLine("2. Hien thi thong tin KS");
            Console.WriteLine("3. Dat phong nghi");
            Console.WriteLine("4. Tim phong con trong");
            Console.WriteLine("5. Thong ke doanh thu");
            Console.WriteLine("6. Tim kiem thong tin KH");
            Console.WriteLine("7. Thoat");
            Console.WriteLine("Lua chon : ");

        }
    }
}



