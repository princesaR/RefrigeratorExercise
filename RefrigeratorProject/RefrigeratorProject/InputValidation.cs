using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class InputValidation
    {
        public static Item InputItem()
        {
            var name = EnterName();
            var kind = EnterKind();
            var cosher = EnterCosher();
            var date = EnterDate();
            var place = EnterPlace();

            var Item = new Item(name, kind, cosher, date, place);

            return Item;

        }
        public static string EnterName()
        {
            Console.Write("enetr the name of the item\n enter your choice: ");
            var name = Console.ReadLine();
            return name;
        }
        public static Kind EnterKind()
        {
            var input = 0;
            do
            {
                Console.WriteLine("enter the kind of the item. 1 for food 2 for drink");
                Console.Write("enter your choice: ");
                input = IsInputNum();
            } while (input != 1 && input != 2);

            var kind = (Kind)input;
            return kind;
        }
        public static Cosher EnterCosher()
        {
            var input = 0;
            do
            {
                Console.WriteLine("enter the Cosher of the Item 1 for milky 2 for meaty 3 for pareve");
                Console.Write("enter your choice: ");
                input = IsInputNum();

            } while (input != 1 && input != 2 && input != 3);

            var cosher = (Cosher)input;
            return cosher;
        }
        public static DateTime EnterDate()
        {
            Console.WriteLine("enter the Expiry Date of the item in format [mm/dd/yy] ");
            Console.Write("enter your choice: ");
            var date = IsInputDate();

            return date;

        }
        public static double EnterPlace()
        {
            Console.WriteLine("enter the place taken by the item");
            Console.Write("enter your choice: ");
            var place = IsInputDouble();
            return place;
        }
        public static string EnterItemId()
        {
            Console.WriteLine("enter ID of the Item");
            Console.Write("enter your choice: ");
            var itemId = IsInputNum().ToString();
            return itemId;
        }
        public static int IsInputNum()
        {
            var valid = false;
            var input = "";
            int number = 0; ;
            while (!valid)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out number) && number > 0)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Initial value must be of the type int");
                    Console.WriteLine("\nPlease enter the number again: ");
                }

            }
            return number;
        }
        public static double IsInputDouble()
        {
            var valid = false;
            var input = "";
            var doubleNum = 0.0;

            while (!valid)
            {
                input = Console.ReadLine();
                if (double.TryParse(input, out doubleNum) && doubleNum > 0)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Initial value must be of the type double");
                    Console.WriteLine("\nPlease enter the number again: ");
                }
            }
            return doubleNum;

        }
        public static DateTime IsInputDate()
        {
            var valid = false;
            var input = "";
            var date = new DateTime();
            while (!valid)
            {
                input = Console.ReadLine();
                if (DateTime.TryParse(input, out date) && date > DateTime.Now.AddDays(-1))

                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("the input is not a vaild date.");
                    Console.WriteLine("\nPlease enter the date again: ");
                }
            }
            return date;
        }
    }
}
