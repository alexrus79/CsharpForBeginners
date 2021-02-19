using System;

namespace HomeWork
{
    class Program
    {
        static void Main()
        {            
            ShowCase showCase1 = new ShowCase();
            ShowCase showCase2 = new ShowCase();
            ShowCase showCase3 = new ShowCase();
            ShowCase showCase4 = new ShowCase();
            Product product1 = new Product();
            Product product2 = new Product();
            Product product3 = new Product();
            Product product4 = new Product();
            product1.PlaceProduct(showCase1);
            product2.PlaceProduct(showCase1);
            product3.PlaceProduct(showCase1);
            MainMenu();
        }
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Всего витрин: {0}", ShowCase.Quantity);
            Console.WriteLine("Всего товаров: {0} [Из них на складе: {1}] [На витринах: {2}]", 
                Product.Quantity, Product.AllProductInWarehouse, Product.AllProductInShowCases);
            Console.WriteLine();
            Console.WriteLine("1. Меню: Витрины");
            Console.WriteLine("2. Меню: Товары");
            Console.WriteLine("3. Выход из программы");
            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);

            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    ShowCasesMenu();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
        static void ShowCasesMenu()
        {
            Console.Clear();
            ShowCase.GetInfoAllShowCases();
            Console.WriteLine();
            Console.WriteLine("1. Информация по витрине");
            Console.WriteLine("2. Добавить витрину");
            Console.WriteLine("3. Удалить витрину");
            Console.WriteLine("4. Назад");

            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);

            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    ShowCaseInformationMenu();
                    break;
                case "2":
                    ShowCase showCase = new ShowCase();
                    ShowCasesMenu();
                    break;
                case "3":
                    ShowCaseDeleteMenu();
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    ShowCasesMenu();
                    break;
            }
        }
        static void ShowCaseInformationMenu()
        {
            Console.Clear();
            ShowCase.GetInfoAllShowCases();
            Console.WriteLine();
            Console.Write("Введите ID витрины и нажмите Enter :");
            string idShowCase = Console.ReadLine();
            try
            {
                int id = Convert.ToInt32(idShowCase);
                if (id > ShowCase.Quantity)
                {
                    ShowCaseInformationMenu();
                }
                else
                {
                    ShowCase showCase =  ShowCase.GetShowCaseFromID(id);
                    Console.Clear();
                    showCase.GetInfo();
                    Console.WriteLine();
                    Console.WriteLine("Нажмите Enter для возврата в меню...");
                    Console.ReadLine();
                    ShowCasesMenu();
                }
                    
            }
            catch (Exception)
            {
                ShowCaseInformationMenu();
            }

        }
        static void ShowCaseDeleteMenu()
        {
            Console.Clear();
            ShowCase.GetInfoAllShowCases();
            Console.WriteLine();
            Console.Write("Введите ID витрины и нажмите Enter :");
            string idShowCase = Console.ReadLine();
            try
            {
                int id = Convert.ToInt32(idShowCase);
                ShowCase showCase = ShowCase.GetShowCaseFromID(id);
                if (showCase == null)
                {
                    ShowCasesMenu();
                }
                else
                {
                    if (ShowCase.DeleteShowCaseFromBase(showCase))
                    {
                        Console.WriteLine("Витрина удалена. Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        ShowCasesMenu();
                    } 
                    else
                    {
                        Console.WriteLine("Ошибка удаления! Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        ShowCasesMenu();
                    }

                }

            }
            catch (Exception)
            {
                ShowCaseDeleteMenu();
            }
        }
        static void ShowProductsMenu()
        {
            Console.Clear();
            Console.WriteLine("Всего товаров: {0} [Из них на складе: {1}] [На витринах: {2}]",
                Product.Quantity, Product.AllProductInWarehouse, Product.AllProductInShowCases);
            Console.WriteLine();
            Console.WriteLine("1. Товары на складе");
            Console.WriteLine("2. Товары на витринах");
            Console.WriteLine("3. Добавить товар");
            Console.WriteLine("4. Назад");
            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);

            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    ShowProductsFromWarehouse();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    MainMenu();
                    break;
            }

        }
        static void ShowProductsFromWarehouse()
        {
            Product.
        }
    }

}