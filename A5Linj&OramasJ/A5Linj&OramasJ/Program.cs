using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace A5Linj_OramasJ
{
    internal class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            int choice;
            do
            {
                //Main menu
                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("Select an options (only 1 to 5)");
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Edit Existing Customer");
                Console.WriteLine("3. Display Customer");
                Console.WriteLine("4. Exit");
                choice = GetInt("");
                if (choice == 1)
                {
                    AddNewCustomer();
                }
                else if (choice == 2)
                {
                    EditExistingCustomer();
                }
                else if (choice == 3)
                {
                    DisplayCustomer();
                }
            } while (choice <= 1 || choice <= 3 || choice > 4);
        }
        static void AddNewCustomer()
        {

        }
        static void EditExistingCustomer()
        {

        }
        static void DisplayCustomer()
        {

        }
        static int GetInt(string userPrompt)
        {
            //For int number only
            int answer = 0;
            bool inputOk = false;
            do
            {
                try
                {
                    Console.Write(userPrompt);
                    answer = Convert.ToInt16(Console.ReadLine());
                    inputOk = true;
                }
                catch
                {
                    Console.WriteLine("Number Only Please");
                }
            } while (inputOk == false);
            return answer;
        }
    }
}
