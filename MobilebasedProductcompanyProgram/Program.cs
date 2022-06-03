using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilebasedProductcompanyProgram
{
    internal class Program
    {
        public static int productId;
        public static string productName;
        public static string productColor;
        public static double productPrice;  
        public static string WarrantyValidInput;
        public static DateTime productDate;
        public static int productLength;
        public static string userExitorNot;
        public static char inputExit;
        public static bool isExecuted = false;
        static void Main()
        {
            CompanyIntro();
            userInput();
            Exit();
        }

        static void userInput()
        {
            Console.WriteLine("How much Product you want to add: ");
            string userProductInput = Console.ReadLine();
            while (!ProductLengthValid(userProductInput))
            {
                Console.WriteLine("Please Enter Correct No of Products");
                userProductInput = Console.ReadLine();
            }
            string[,] productInfo = new string[productLength,6];


            for (int i = 0; i < productLength; i++)
            {
                Console.WriteLine($"\nProduct-{i + 1}\n");
                Console.WriteLine($"Please Enter {i + 1} Product Id: ");
                string productIdInput = Console.ReadLine();
                while (!ProductIdValid(productIdInput))
                {
                    Console.WriteLine("Please Enter Correct Product Id");
                    productIdInput = Console.ReadLine();
                }

                Console.WriteLine($"Please Enter {i + 1} Product Name: ");
                productName = Console.ReadLine();
                while (!IsValidName(productName))
                {
                    //Console.WriteLine("Please Enter Correct Product Id");
                    productName = Console.ReadLine();
                }

                Console.WriteLine($"Please Enter {i + 1} Product Color: ");
                productColor = Console.ReadLine();
                while (!IsValidName(productColor))
                {
                    //Console.WriteLine("Please Enter Correct Product Id");
                    productColor = Console.ReadLine();
                }

                Console.WriteLine($"Please Enter {i + 1} Product Price: ");
                string productPriceInput = Console.ReadLine();
                while (!AmountValid(productPriceInput))
                {
                    Console.WriteLine("Please Enter Amount In the Correct Format");
                    productPriceInput = Console.ReadLine();
                }


                Console.WriteLine($"Please Enter {i + 1} Product Warranty: ");
                WarrantyValidInput = Console.ReadLine();
                while (!WarrantyValid(WarrantyValidInput))
                {
                    Console.WriteLine("Please Enter Amount In the Correct Format");
                    WarrantyValidInput = Console.ReadLine();
                }



                Console.WriteLine($"Please Enter {i + 1} Product Manufacture Date: ");
                string productDateInput = Console.ReadLine();
                while (!dateValid(productDateInput))
                {
                    Console.WriteLine("Please Enter Date In the Correct Format(dd/MMM/yyyy)");
                    productDateInput = Console.ReadLine();
                }

                productInfo[i, 0] = Convert.ToString(productId);
                productInfo[i, 1] = productName;
                productInfo[i, 2] = productColor;
                productInfo[i, 3] = WarrantyValidInput;
                productInfo[i, 4] = Convert.ToString(productPrice);
                productInfo[i, 5] = Convert.ToString(productDate).Substring(0, 11);
        }
            printArr(productInfo);


        }

        static void CompanyIntro()
        {
            if (!isExecuted) { 
                Console.WriteLine("\nWelcome to MobileX");
                isExecuted = true;
            }
        }

        

        static void printArr(string[,]  arr) {
            for (int i = 0; i< productLength; i++) {
                Console.WriteLine("");
                Console.WriteLine($"Product Id: {arr[i,0]}");
                Console.WriteLine($"Product Name: {arr[i, 1]}");
                Console.WriteLine($"Product Color: {arr[i, 2]}");
                Console.WriteLine($"Product Warranty: {arr[i, 3]}");
                Console.WriteLine($"Product Price:  {arr[i, 4]}");
                Console.WriteLine($"Product manufacture Date: {arr[i, 5]}");
                Console.WriteLine("");
            }
            
        }
        //VALIDATION METHODS
        static bool ProductLengthValid(string length)
        {
            bool isValid = true;

            isValid = int.TryParse(length, out productLength);

            return isValid;
        }
        static bool ProductIdValid(string inputString)
        {
            bool isValid = true;

            isValid = int.TryParse(inputString, out productId);

            return isValid;
        }

        static bool IsValidName(string nameInput)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(nameInput))
            {
                Console.WriteLine("Input Can't Be Empty");
                isValid = false;
            }
            else
            {
                if (nameInput.Length <= 2)
                {
                    Console.WriteLine("Input Should Be More Than 2 Character");
                    isValid = false;
                }
                else if (nameInput.Length >= 15)
                {
                    Console.WriteLine("Input Should Be less Than 15 Character");
                    isValid = false;
                }
                else
                {
                    foreach (char c in nameInput)
                    {
                        if (!Char.IsLetter(c))
                        {
                            Console.WriteLine("Input Should Only Contains Characters No Special Character or Number Allowed");
                            isValid = false;
                            return false;
                        }
                    }
                }
            }
            return isValid;
        }


        public static bool WarrantyValid(string inputAddress)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(inputAddress))
            {
                Console.WriteLine("Product Warranty Input Should Not be Empty");
                isValid = false;
            }
            else
            {

                if (inputAddress.Length < 3)
                {
                    Console.WriteLine("Product Warranty Input Should Be More than 3 Character");
                    isValid = false;
                }
                else if (inputAddress.Length > 20)
                {
                    Console.WriteLine("Product Warranty Input Should Be Less Than 20 Character");
                    isValid = false;
                }
            }
            return isValid;
        }




        static bool AmountValid(string inputString)
        {
            bool isValid = true;
            isValid = double.TryParse(inputString, out productPrice);
            return isValid;
        }
        static bool dateValid(string inputString)
        {
            
            bool isValid = DateTime.TryParseExact(inputString, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out productDate);
            return isValid;
        }

        static void Exit()
        {
            Console.WriteLine($"You want Exit or Enter New entry : Y / N");
            userExitorNot = Console.ReadLine();

            while (!ExitValid(userExitorNot))

            {
                userExitorNot = Console.ReadLine();
            }


            if (inputExit == 'N' || inputExit == 'n')
            {
                Main();
            }

            if (inputExit == 'Y' || inputExit == 'y')
            {
                Environment.Exit(0);
            }

        }



        public static bool ExitValid(string input)
        {
            bool isValid = true;
            if (Char.TryParse(input, out inputExit))
            {
                if (inputExit == 'Y' || inputExit == 'N' || inputExit == 'y' || inputExit == 'n')
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please Provide Correct Info Y or N");
                    isValid = false;
                }
            }
            else
            {
                Console.WriteLine("Please Provide Correct Info Y or N");
                isValid = false;


            }
            return isValid;
        }

    }
}
