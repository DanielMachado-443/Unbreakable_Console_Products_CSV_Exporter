using System;
using System.IO;
using Entities;
using System.Collections.Generic;
using MyExceptions;

namespace Section13_FinalExercise_192 {
    class Program {
        static void Main(string[] args) {

            bool bigWhile = true;
            bool again = false;
            int NoP = 0;
            int whileCount = 0;
            string filePath = null;
            string folderPath = null;            

            while (bigWhile) {

                bool flag1 = true;
                bool flag2 = true;
                bool flag3 = true;
                bool flag3_1 = true;
                bool flag4 = true;
                int intChoice1 = 0;
                int intChoice2 = 0;

                if (!again) {
                    Console.WriteLine("\n\n   Welcome to this product register! ");                    
                }

                while (flag1) {
                    try {
                        Console.Write("\n   Do you want to import a file directly via its path (1) or you want to create the data from beginning using only the folder path (2)? ");
                        intChoice1 = int.Parse(Console.ReadLine());

                        while (intChoice1 != 1 && intChoice1 != 2) {
                            Console.WriteLine("   Invalid answer! Try again! ");
                            Console.Write("\n   Do you want to import a file directly via its path (1) or you want to create the data from beginning using only the folder path (2)? ");
                            intChoice1 = int.Parse(Console.ReadLine());
                        }
                        flag1 = false;
                    }
                    catch (Exception e) {
                        Console.WriteLine(e + "\n\n   While(flag1) error! ");
                    }
                }

                if (intChoice1 == 2) {
                    while (flag2) {
                        try {
                            Console.Write("\n   Enter a folder path: ");
                            folderPath = Console.ReadLine();
                            if (Int32.TryParse(folderPath, out int eoq) || Double.TryParse(folderPath, out double Deoq)) { // testing if the imput IS AT LEAST a STRING
                                Console.Write("\n   ");
                                throw new MyPersonalExceptions("\n   You have writen a number instead of a file address");
                            }
                            if (!(Directory.Exists(folderPath))) {
                                throw new MyPersonalExceptions("\n   The folder doesn't exists! ");
                            }

                            Console.Write("\n   How many products do you want to register now? ");
                            NoP = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            List<Product> prodList = new List<Product>(); // outside of the big while

                            for (int i = 1; i <= NoP; i++) {
                                Console.WriteLine();

                                Console.Write($"   Type the product {i} name: ");
                                string prodName = Console.ReadLine();

                                Console.Write($"   Type the product {i} price: ");
                                double prodPrice = double.Parse(Console.ReadLine());

                                Console.Write($"   Type the product {i} quantity: ");
                                int prodQuantity = int.Parse(Console.ReadLine());

                                prodList.Add(new Product(prodName, prodPrice, prodQuantity));
                            }

                            // Exporting to a file
                            List<string> Conv = new List<string>();
                            foreach (Product prd in prodList) {
                                Conv.Add(prodList[prodList.IndexOf(prd)].ToString());
                            }
                            
                            Directory.CreateDirectory(folderPath + "\\FirstOut");
                            folderPath = folderPath + "\\FirstOut";

                            filePath = folderPath + "\\Relatory " + (whileCount + 1) + ".csv";
                            using (StreamWriter File = new StreamWriter(filePath))
                                foreach (string str in Conv) {
                                    File.WriteLine(str.ToString());
                                }

                            flag2 = false;
                        }
                        catch (MyPersonalExceptions e) {
                            Console.WriteLine(e + "\n\n   You'll need to redo this step and enter a valid address rather than a number "); // catching my personal exception
                        }
                        catch (Exception e) {
                            Console.WriteLine(e + "\n\n   if(intChoice1 == 2) error! ");
                        }
                    }
                }
                else {
                    while (flag3) {
                        flag3_1 = true; // AVOIDING AN INFINITE LOOP
                        while (flag3_1) { // while (flag3)
                            try {
                                //string sourceFolder = @"C:\Users\Daniel\source\repos\Section13 Task 2";
                                //string sourceFilePath = @"C:\Users\Daniel\source\repos\Section13 Task\Source.csv";

                                if (!again) {
                                    Console.Write("\n   Type the file's path: ");
                                    filePath = Console.ReadLine();
                                    if (Int32.TryParse(filePath, out int eoq) || Double.TryParse(filePath, out double Deoq)) { // testing if the imput IS AT LEAST a STRING
                                        Console.Write("\n   ");
                                        throw new MyPersonalExceptions("\n   You have writen a number instead of a file address");
                                    }
                                }
                                else {
                                    Console.Write("\n   You want to use the created here file's path (1) or type any other (2)? ");
                                    intChoice2 = int.Parse(Console.ReadLine());

                                    while (intChoice2 != 1 && intChoice2 != 2) {
                                        Console.Write("\n   Try this step again! ");
                                        Console.Write("\n   You want to use the created here file's path (1) or type any other (2)? ");
                                        intChoice2 = int.Parse(Console.ReadLine());
                                    }
                                }
                                if (intChoice2 == 2) {
                                    Console.Write("\n\n   Enter the file path: ");
                                    filePath = Console.ReadLine();
                                    if (Int32.TryParse(filePath, out int eoq) || Double.TryParse(filePath, out double Deoq)) { // testing if the imput IS AT LEAST a STRING
                                        Console.Write("\n   ");
                                        throw new MyPersonalExceptions("\n   You have writen a number instead of a file address");
                                    }
                                }
                                flag3_1 = false;
                            }
                            catch (MyPersonalExceptions e) {
                                Console.WriteLine(e + "\n\n   You'll need to redo this step and enter a valid address rather than a number "); // catching my personal exception
                            }
                            catch (Exception e) {
                                Console.WriteLine(e + "\n\n   while (flag3) section 1 error! ");
                            }
                        }

                        try { // while (flag3_2) section // IT'S the continuation of intChoice2 when the user doesn't want to insert a new file path (1)

                            string[] lines = File.ReadAllLines(filePath);
                            string sourceFolderPath = Path.GetDirectoryName(filePath);
                            string targetFolderPath = sourceFolderPath + @"\SecondOut";
                            string targetFilePath = targetFolderPath + @"\Summary " + (whileCount + 1) +".csv";

                            Directory.CreateDirectory(sourceFolderPath + "\\SecondOut"); // Creating the new folder

                            using (StreamWriter sw = File.AppendText(targetFilePath)) {
                                foreach (string line in lines) {

                                    string[] fields = line.Split(','); // A new array of strings INSIDE of a string item of the BIG array of strings
                                    string name = fields[0];
                                    double price = double.Parse(fields[1]);
                                    int quantity = int.Parse(fields[2]);

                                    Product prod = new Product(name, price, quantity);

                                    sw.WriteLine(prod.name + ",$" + prod.totalValue().ToString("F2"));
                                }
                            }
                            flag3 = false;
                        }
                        catch (Exception e) {
                            Console.WriteLine(e + "\n\n   while (flag3_2) Section 1 error! \n\n   Probably you've writen a INVALID address, you'll have to try again! ");                                                                               
                        }
                    }
                }

                bigWhile = false; // closing the program

                while (flag4) {
                    try {
                        Console.Write("\n   Do you want to keep executing the program? (y/n) ");
                        char answer = char.Parse(Console.ReadLine());

                        while (answer != 'y' & answer != 'Y' & answer != 'n' & answer != 'N') {
                            Console.WriteLine("\n   Try this step again! ");

                            Console.Write("\n   Do you want to keep executing the program? (y/n) ");
                            answer = char.Parse(Console.ReadLine());
                        }

                        if (answer == 'y' || answer == 'Y') {
                            bigWhile = true;
                        }
                        flag4 = false;
                    }
                    catch (Exception e) {
                        Console.WriteLine(e + "\n\n   while (flag4) error! ");
                    }
                }

                again = true;
                whileCount++;
            }
        }
    }
}