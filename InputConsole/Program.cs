using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using HotelModel;
using HotelRestService.Controllers;

namespace InputConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            FacilitiesController controller = new FacilitiesController();

            string menuString =
                "++++++++++++++++++Hotel Rest Service+++++++++++++++++\n" +
                "1. Create \n" +
                "2. Read \n" +
                "3. Update\n" +
                "4. Delete \n" +
                "0. Exit \n" +
                "Choose a number: ";

            Console.WriteLine(menuString);
            int input = int.Parse(Console.ReadLine());

            while (input != 0)
            {


                switch (input)
                {
                    case 1:
                        Facilities facilities = new Facilities();
                        Console.WriteLine("Please assign a Hotel number");
                        facilities.Hotel_No =
                            Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(
                            "Is there a Swimming Pool? true/false");
                        facilities.SwimmingPool =
                            Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine(
                            "Is there a Table Tennis table? true/false");
                        facilities.TableTennis =
                            Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Is there a Pool Table? true/false");
                        facilities.PoolTable =
                            Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Is there a Bar? true/false");
                        facilities.Bar = Convert.ToBoolean(Console.ReadLine());

                        controller.Post(facilities);

                        controller.Get(facilities.Hotel_No);
                        break;

                    case 2:
                        controller.Get().ForEach(Console.WriteLine);
                        break;

                    case 3:
                        Facilities u = new Facilities();
                        Console.WriteLine("Please assign a Hotel number");
                        u.Hotel_No =
                            Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(
                            "Is there a Swimming Pool? true/false");
                        u.SwimmingPool =
                            Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine(
                            "Is there a Table Tennis table? true/false");
                        u.TableTennis =
                            Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Is there a Pool Table? true/false");
                        u.PoolTable =
                            Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Is there a Bar? true/false");
                        u.Bar = Convert.ToBoolean(Console.ReadLine());

                        controller.Put(u.Hotel_No, u);

                        controller.Get(u.Hotel_No);
                        break;
                    case 4:
                        Console.WriteLine("Please Choose a Hotel number to Delete");
                        int deleteInput = int.Parse(Console.ReadLine());
                        controller.Delete(deleteInput);
                        controller.Get();
                        break;
                    default:
                        Console.WriteLine("Try again!");
                        break;

                }

                Console.WriteLine(menuString);
                input = int.Parse(Console.ReadLine());
                Console.Clear();
            }

        }
    }
}
