using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class Menu
    {
        private enum Methods
        {
            MainMenu,
            MenuShowCases,
            MenuEditShowCase,
            MenuRemovProductFromShowCase,
            MenuAddProductToShowCase,
            MenuProduct,
            MenuProductsInWarehouse,
            MenuProductsInShowCases,
            Exit
        }
        private static Methods method = Methods.MainMenu;
        private static ShowCase tempShowCase;
        public static void Start()
        {
            do
            {
                switch (method)
                {
                    case Methods.MainMenu:
                        MainMenu();
                        break;
                    case Methods.MenuShowCases:
                        //MenuShowCases();
                        MenuShowCases();
                        break;
                    case Methods.MenuProduct:
                        MenuProduct();
                        break;
                    case Methods.MenuEditShowCase:
                        MenuEditShowCase(tempShowCase);
                        break;
                    case Methods.MenuRemovProductFromShowCase:
                        MenuRemovProductFromShowCase(tempShowCase);
                        break;
                    case Methods.MenuAddProductToShowCase:
                        MenuAddProductToShowCase(tempShowCase);
                        break;
                    case Methods.MenuProductsInWarehouse:
                        MenuProductsInWarehouse();
                        break;
                    case Methods.MenuProductsInShowCases:
                        MenuProductsInShowCases();
                        break;
                    default:
                        break;
                }
            } while (method != Methods.Exit);
        }
        private static void MainMenu()
        {
            Console.Clear();
            ShowCase.GetGlobalInfo();
            Console.WriteLine("1. Меню: Витрины");
            Console.WriteLine("2. Меню: Товары");
            Console.WriteLine("6. Выход");
            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);
            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    method = Methods.MenuShowCases;
                    break;
                case "2":
                    method = Methods.MenuProduct;
                    break;
                case "6":
                    method = Methods.Exit;
                    break;
                default:
                    method = Methods.MainMenu;
                    break;
            }
        }
        private static void MenuShowCases()
        {
            Console.Clear();
            ShowCase.GetInfoAllShowCases();
            Console.WriteLine();
            if (ShowCase.Quantity != 0)
            {
                Console.WriteLine("1. Информация по витрине");
            }
            Console.WriteLine("2. Добавить витрину");
            if (ShowCase.Quantity != 0)
            {
                Console.WriteLine("3. Удалить витрину");
                Console.WriteLine("4. Удалить последню витрину");
            }
            Console.WriteLine("5. Назад");
            Console.WriteLine("6. Выход");

            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);
            if (ShowCase.Quantity == 0 && (consoleKey.KeyChar == 49 || consoleKey.KeyChar == 51 || consoleKey.KeyChar == 52))
            {
                method = Methods.MenuShowCases;
                return;
            }
            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    ShowCase showCases = DialogGetShowCase();
                    if (showCases == null)
                    {
                        method = Methods.MenuShowCases;
                        break;
                    }
                    else
                    {
                        tempShowCase = showCases;
                        method = Methods.MenuEditShowCase;
                        break;
                    }
                case "2":
                    ShowCase showCase = new ShowCase();
                    method = Methods.MenuShowCases;
                    break;
                case "3":
                    DialogShowCaseDeleteFromBase();
                    method = Methods.MenuShowCases;
                    break;
                case "4":
                    ShowCase showCaseLast = ShowCase.GetShowCaseFromID(ShowCase.GetLastId());
                    if (showCaseLast == null)
                    {
                        method = Methods.MenuShowCases;
                        break;
                    }
                    else
                    {
                        ShowCase.DeleteShowCaseFromBase(showCaseLast);
                        method = Methods.MenuShowCases;
                        break;
                    }
                case "5":
                    method = Methods.MainMenu;
                    break;
                case "6":
                    method = Methods.Exit;
                    break;
                default:
                    break;
            }
        }
        private static void MenuEditShowCase(ShowCase showCase)
        {
            Console.Clear();
            Console.WriteLine();
            showCase.GetInfo();
            Console.WriteLine();
            if (showCase.ProductCount > 0)
            {
                Console.WriteLine("1. Удалить товар с витрины");
            }
            if (showCase.Capacity != 0)
            {
                Console.WriteLine("2. Добавить товары со склада");
            }
            Console.WriteLine("5. Назад");
            Console.WriteLine("6. Выход");

            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);

            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    tempShowCase = showCase;
                    method = Methods.MenuRemovProductFromShowCase;
                    break;
                case "2":
                    tempShowCase = showCase;
                    method = Methods.MenuAddProductToShowCase;
                    break;
                case "5":
                    method = Methods.MenuShowCases;
                    break;
                case "6":
                    method = Methods.Exit;
                    break;
                default:
                    tempShowCase = showCase;
                    method = Methods.MenuEditShowCase;
                    break;
            }

        }
        private static void MenuProduct()
        {
            Console.Clear();
            ShowCase.GetGlobalInfo();
            Console.WriteLine();
            Console.WriteLine("1. Товары на складе");
            Console.WriteLine("2. Товары на витринах");
            Console.WriteLine("3. Добавить товар");
            Console.WriteLine("5. Назад");
            Console.WriteLine("6. Выход");
            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);
            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    method = Methods.MenuProductsInWarehouse;
                    break;
                case "2":
                    method = Methods.MenuProductsInShowCases;
                    break;
                case "3":
                    break;
                case "5":
                    method = Methods.MainMenu;
                    break;
                case "6":
                    method = Methods.Exit;
                    break;
                default:
                    method = Methods.MenuProduct;
                    break;
            }
        }
        private static void MenuEditProduct()
        {
            Console.WriteLine("1. Разместить товар на витрине");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("5. Назад");
            Console.WriteLine("6. Выход");
            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);
            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    break;
                case "2":
                    DialogDeleteProductFromBase();
                    break;
                case "5":
                    MenuProduct();
                    break;
                case "6":
                    break;
                default:
                    MenuProductsInWarehouse();
                    break;
            }
        }
        private static void MenuRemovProductFromShowCase(ShowCase showCase)
        {
            Console.Clear();
            Console.WriteLine();
            showCase.GetInfo();
            Console.WriteLine();
            Product product = DialogGetProduct(showCase);
            if (product == null || product.ShowCase != showCase)
            {
                Console.WriteLine("Товар не найден!. Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            else if (product != null && product.RemoveProduct(showCase))
            {
                Console.WriteLine("Товар удален!. Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            else
            {
                Console.WriteLine("Ошибка удаления товара! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            static void UserInput(ShowCase showCase)
            {
                ConsoleKey consoleKey;
                consoleKey = Console.ReadKey(true).Key;
                while (consoleKey != ConsoleKey.Enter || consoleKey != ConsoleKey.Escape)
                {
                    if (consoleKey == ConsoleKey.Escape)
                    {
                        tempShowCase = showCase;
                        method = Methods.MenuEditShowCase;
                        return;
                    }
                    if (consoleKey == ConsoleKey.Enter)
                    {
                        tempShowCase = showCase;
                        method = Methods.MenuRemovProductFromShowCase;
                        return;
                    }
                    consoleKey = Console.ReadKey(true).Key;
                }

            }
        }
        private static void DialogShowCaseDeleteFromBase()
        {
            Console.Clear();
            ShowCase.GetInfoAllShowCases();
            Console.WriteLine();

            ShowCase showCase = DialogGetShowCase();
            if (showCase == null)
            {
                Console.WriteLine("Витрина не найдена!. Нажмите Enter для возврата в меню...");
                Console.ReadLine();
            }
            else if (ShowCase.DeleteShowCaseFromBase(showCase))
            {
                Console.WriteLine("Витрина удалена. Нажмите Enter для возврата в меню...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ошибка удаления! Нажмите Enter для возврата в меню...");
                Console.ReadLine();
            }
        }
        private static void MenuAddProductToShowCase(ShowCase showCase)
        {
            Console.Clear();
            Console.WriteLine();
            showCase.GetInfo();
            Console.WriteLine();
            Product.ShowProductsInWarehouse();
            Console.WriteLine();
            Product product = DialogGetProduct();
            if (product == null)
            {
                Console.WriteLine("Товар не найден! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            else if (product.ShowCase == showCase)
            {
                Console.WriteLine("Товар уже размещен на этой витрине! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            else if (product.ShowCase != null)
            {
                Console.WriteLine("Товар размещен на другой витрине! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            else if (product.PlaceProduct(showCase))
            {
                Console.WriteLine("Товар размещен! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            return;
            static void UserInput(ShowCase showCase)
            {
                ConsoleKey consoleKey;
                consoleKey = Console.ReadKey(true).Key;
                while (consoleKey != ConsoleKey.Enter || consoleKey != ConsoleKey.Escape)
                {
                    if (consoleKey == ConsoleKey.Escape)
                    {
                        tempShowCase = showCase;
                        method = Methods.MenuEditShowCase;
                        return;
                    }
                    if (consoleKey == ConsoleKey.Enter)
                    {
                        tempShowCase = showCase;
                        method = Methods.MenuAddProductToShowCase;
                        return;
                    }
                    consoleKey = Console.ReadKey(true).Key;
                }
            }
        }
        private static Product DialogGetProduct(ShowCase showCase = null)
        {
            Console.Write("Введите ID товара и нажмите Enter :");
            string idProduct = Console.ReadLine();
            try
            {
                int id = Convert.ToInt32(idProduct);
                Product product = Product.GetProductFromID(id);
                if (product == null)
                {
                    return null;
                }
                else
                {
                    return product;
                }
            }
            catch (Exception)
            {
                method = Methods.MenuProduct;
                return null;
            }
        }
        private static ShowCase DialogGetShowCase()
        {
            Console.Write("Введите ID витрины и нажмите Enter :");
            string idShowCase = Console.ReadLine();
            try
            {
                int id = Convert.ToInt32(idShowCase);
                ShowCase showCase = ShowCase.GetShowCaseFromID(id);
                if (showCase == null)
                {
                    Console.WriteLine("Витрина не найдена! Нажмите клавишу Enter для возврата в меню...");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                    return null;
                }
                else
                {
                    return showCase;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static void DialogDeleteProductFromBase()
        {
            Console.Clear();
            Product.ShowProductsInWarehouse();
            Console.WriteLine();
            Product product = DialogGetProduct();
            if (product == null)
            {
                Console.WriteLine("Товар не найден! Нажмите Enter для возврата в меню...");
                Console.ReadLine();
                MenuProductsInWarehouse();
            }
            else
            {
                if (product.ShowCase == null && Product.DelProductFromBase(product))
                {
                    Console.WriteLine("Товар удален! Нажмите Enter для возврата в меню...");
                    Console.ReadLine();
                    MenuProductsInWarehouse();
                }
                else
                {
                    Console.WriteLine("Ошибка удаления! Нажмите Enter для возврата в меню...");
                    Console.ReadLine();
                    MenuProductsInWarehouse();
                }
            }
        }
        private static void MenuProductsInWarehouse()
        {

        }
        private static void MenuProductsInShowCases()
        {

        }
    }
}
