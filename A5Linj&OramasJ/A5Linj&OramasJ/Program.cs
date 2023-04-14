/*
 * Name of Project (File):A5LinJ&OramasJ
 * Purpose of Program: To create a customer data base.
 * Revision History:
 *      Jiadong Lin, 2023.04.12: Created
 *      Jose Oramas, 2023.04.14: AddCustomer, EditCustomer, CheckEmail implementations
 *      Jiadong Lin, 2023.04.14: DisplayCustomers implementation
 */
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
        // NOTE: Customers database
        static List<Customer> customers = new List<Customer>();
        // NOTE: This is used for customer id generation
        static int idGen = 1000;

        static bool CheckEmail(string email)
        {
            bool result = false;
            int indexAt = -1;
            int indexLastDot = -1;

            for(int i = 0; i < email.Length; ++i)
            {
                char c = email[i];

                if(c == '@')
                {
                    indexAt = i;
                }

                if(c == '.' && indexLastDot < i)
                {
                    indexLastDot = i;
                }
            }

            if(indexAt != -1 && indexLastDot != -1 && (indexAt < indexLastDot))
            {
                // NOTE: Check if the email already exists in the data base
                bool notFound = true;
                for(int i = 0; i < customers.Count && notFound; ++i)
                {
                    Customer c = customers[i];
                    if(c.GetEmail() == email)
                    {
                        notFound = false;
                    }
                }

                if (notFound)
                {
                    result = true;
                }
                else
                {
                    Console.WriteLine("The email already exists!");
                    Console.WriteLine("Customer was not added!");
                    Console.WriteLine("Press any key to continue... ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("email was not in the correct format");
                Console.WriteLine("Customer was not added!");
                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey();
            }
               
            return result;
        }

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
                Console.WriteLine("3. Display Customers");
                Console.WriteLine("4. Exit");
                choice = GetInt("");
                if (choice == 1)
                {
                    AddNewCustomer();
                }
                else if (choice == 2)
                {
                    int id;
                    int index = -1;
                    if (DisplayCustomers() > 0)
                    {
                        id = GetInt("Which customer do you want to edit? id: ");
                        index = EditExistingCustomer(id);
                        if(index != -1)
                        {
                            Console.WriteLine("NEW CUSTOMER DATA:");
                            customers[index].DisplayCustomerInformation();
                            Console.ReadKey();
                        }
                    }
                }
                else if (choice == 3)
                {
                    if(DisplayCustomers() > 0)
                    {
                        // NOTE: This is to avoid clearing the console before watching the customers
                        Console.Write("\nPress any key to continue... ");
                        Console.ReadKey();
                    }
                }
            } while (choice <= 1 || choice <= 3 || choice > 4);
        }

        static void AddNewCustomer()
        {
            string name;
            string email;
            int age;

            bool isEmailOk;

            // NOTE: Get the name
            Console.Write("What's the customer name? ");
            name = Console.ReadLine();

            // NOTE: Get the age (must be in the correct range)
            do
            {
                age = GetInt("What's the customer age? ");
                if(age < 13 || age > 100)
                {
                    Console.WriteLine("Age must be between 13 and 100 years.");
                    Console.WriteLine("Press any key to continue... ");
                    Console.ReadKey();
                }
            } while (age < 13 || age > 100);

            // NOTE: Get the email (email must be in the correct format)
            // NOTE: email must not be present in the customers list
            Console.Write("What's the customer email? ");
            email = Console.ReadLine();

            isEmailOk = CheckEmail(email);
          
            if (isEmailOk)
            {
                Customer newCustomer = new Customer(idGen++, name, age, email);
                customers.Add(newCustomer);
            }
        }

        // NOTE: it returns the index in the database of the edited customer for displaying pursposes
        static int EditExistingCustomer(int id)
        {
            int index = -1; ;
            bool found = false;
            string answer = "";
            string newName = "";
            string newEmail = "";
            int newAge = -1;

            for(int i = 0; i < customers.Count; ++i)
            {
                if(customers[i].GetId() == id)
                {
                    found = true;

                    do
                    {
                        Console.Write("What would you like to change? (email, age, name): ");
                        answer = Console.ReadLine().ToLower();

                        switch(answer)
                        {
                            case "name":
                                {
                                    Console.Write("New name: ");
                                    newName = Console.ReadLine();
                                    customers[i].SetName(newName);
                                    index = i;
                                } break;

                            case "age":
                                {
                                    do
                                    {
                                        newAge = GetInt("New age: ");
                                        customers[i].SetAge(newAge);
                                        index = i;
                                    } while (newAge < 13 || newAge > 100);
                                }
                                break;

                            case "email":
                                {
                                    Console.Write("New email: ");
                                    newEmail = Console.ReadLine();
                                    customers[i].SetEmail(newEmail);
                                    index = i;
                                } break;

                            default:
                                {
                                    Console.WriteLine("Only name, age or email are accepted!");
                                    Console.WriteLine("Press any key to continue... ");
                                    Console.ReadKey();
                                } break;
                        }

                    } while (answer != "name" && answer != "age" && answer != "email");

                }
            }

            if(!found)
            {
                Console.WriteLine("Customer cannot be found!");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();

                index = -1;
            }

            return index;
        }

        static int DisplayCustomers()
        {
            if (customers.Count > 0)
            {
                Console.WriteLine("\nLIST OF CUSTOMERS:");
                for (int i = 0; i < customers.Count; ++i)
                {
                    Customer customer = customers[i];
                    customer.DisplayCustomerInformation();
                }
            }
            else
            {
                Console.WriteLine("There are no customers registered!");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
            }

            return customers.Count;
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
