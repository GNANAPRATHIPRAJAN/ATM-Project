using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ATMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t \tGPR's Bank Wecomes You Have a Good Day Sir!");
            
            int attempts = 0;
            bool loggedIn = false;
            double balance = 0;
            string correctPin;
            Console.Write("\t Set the Pin: ");
            correctPin = Console.ReadLine(); 
            

            while (attempts < 3 && !loggedIn)
            {
                // Enter PIN
                Console.WriteLine("\tEnter your 4-digit PIN: ");
                string enteredPin = Console.ReadLine();

                // Compare PIN
                if (enteredPin == correctPin)
                {
                    Console.WriteLine("\tPIN verified successfully!");
                    loggedIn = true;

                    // Add Money
                    Console.WriteLine("\tEnter the amount to add to your account: ");
                    double amountToAdd = GetDoubleInput();
                    balance += amountToAdd;

                    Console.WriteLine($"Added {amountToAdd} to your account. Current balance: {balance}");

                    // Withdraw Money
                    Console.Write("\t Enter your PIN to withdraw money: ");
                    string withdrawPin = Console.ReadLine();

                    // Check Withdrawal PIN (Three attempts)
                    for (int i = 0; i < 3; i++)
                    {
                        if (withdrawPin == correctPin)
                        {
                            Console.Write("\t Enter the amount to withdraw: ");
                            double amountToWithdraw = GetDoubleInput();

                            if (amountToWithdraw > balance)
                            {
                                Console.WriteLine("\t Insufficient funds. Exiting the program...");
                            }
                            else
                            {
                                balance -= amountToWithdraw;
                                Console.WriteLine($"Withdrawal of {amountToWithdraw} successful. Remaining balance: {balance}");
                            }

                            // Exit the loop if withdrawal successful
                            break;
                        }
                        else
                        {
                            attempts++;
                            Console.WriteLine($"Incorrect withdrawal PIN. {3 - attempts} attempts remaining.");
                            if (attempts < 3)
                            {
                                Console.Write("\tEnter your PIN again: ");
                                withdrawPin = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("\tExceeded maximum attempts. Exiting the program...");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"Incorrect PIN. {3 - attempts} attempts remaining.");
                }
            }

            if (!loggedIn)
            {
                Console.WriteLine("\tExiting the program...");
            }
        }

        // Method to get a valid double input from the user
        static double GetDoubleInput()
        {
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return result;
        }
    }
}
