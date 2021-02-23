using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class Core
    {
        private enum Methods
        {
            MainMenu,
            MenuShowCases,
            MenuEditShowCase,
            MenuRemovProductFromShowCase,
            MenuAddProductToShowCase,
            MenuProduct,
            MenuAddProductToBase,
            MenuProductsInWarehouse,
            MenuEditProduct,
            MenuProductsInShowCases,
            Exit
        }
        private static Methods method = Methods.MainMenu;
        private static Methods? returnToMethod = null;
        private static ShowCase tempShowCase;
        private static Product tempProduct;
        private static string tempString = null;
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
                        MenuAddProductToShowCase(tempShowCase, returnToMethod);
                        break;
                    case Methods.MenuProductsInWarehouse:
                        MenuProductsInWarehouse();
                        break;
                    case Methods.MenuProductsInShowCases:
                        MenuProductsInShowCases();
                        break;
                    case Methods.MenuAddProductToBase:
                        MenuAddProductToBase();
                        break;
                    case Methods.MenuEditProduct:
                        MenuEditProduct(tempProduct, tempString);
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
                Console.WriteLine("4. Удалить последнюю витрину");
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
                    tempShowCase = DialogGetShowCase();
                    if (tempShowCase == null)
                    {
                        method = Methods.MenuShowCases;
                        break;
                    }
                    else
                    {
                        method = Methods.MenuEditShowCase;
                        break;
                    }
                case "2":
                    ShowCase showCase = new ShowCase();
                    method = Methods.MenuShowCases;
                    break;
                case "3":
                    Console.Clear();
                    ShowCase.GetInfoAllShowCases();
                    Console.WriteLine();
                    tempShowCase = DialogGetShowCase();
                    if (tempShowCase == null)
                    {
                        Console.WriteLine("Витрина не найдена! Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                    }
                    else if (ShowCase.DeleteShowCaseFromBase(tempShowCase))
                    {                        
                        Console.WriteLine("Витрина удалена! Нажмите Enter для возврата в меню...");
                        tempShowCase = null;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка удаления! Нажмите Enter для возврата в меню...");
                        tempShowCase = null;
                        Console.ReadLine();
                    }
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
                    tempShowCase = null;
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
            if (Product.AllProductInWarehouse > 0)
            {
                Console.WriteLine("1. Товары на складе");
            }
            if (Product.AllProductInShowCases > 0)
            {
                Console.WriteLine("2. Товары на витринах");
            }           
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
        private static void MenuEditProduct(Product product, string whatEdit = null)
        {
            Console.Clear();
            Console.WriteLine();
            Product.GetInfo(product);
            Console.WriteLine();
            try
            {
                if (whatEdit == null)
                {
                    Console.WriteLine("1. Редактировать наименование");
                    Console.WriteLine("2. Редактировать размер");
                    Console.WriteLine("3. Редактировать стоимость");
                    Console.WriteLine("5. Назад");
                    Console.WriteLine("6. Выход");
                    ConsoleKeyInfo consoleKey;
                    consoleKey = Console.ReadKey(true);
                    switch (consoleKey.KeyChar.ToString())
                    {
                        case "1":
                            method = Methods.MenuEditProduct;
                            tempString = "Name";
                            break;
                        case "2":
                            method = Methods.MenuEditProduct;
                            tempString = "Size";
                            break;
                        case "3":
                            method = Methods.MenuEditProduct;
                            tempString = "Cost";
                            break;
                        case "5":
                            method = Methods.MenuProductsInWarehouse;
                            tempProduct = null;
                            break;
                        case "6":
                            method = Methods.Exit;
                            break;
                        default:
                            method = Methods.MenuEditProduct;
                            break;
                    }

                }
                else if (whatEdit == "Name")
                {
                    Console.Write("Введите новое наименование товара(не более 15 символов) и нажмите Enter: ");
                    string nameProduct = Console.ReadLine();
                    product.Name = nameProduct;
                    method = Methods.MenuEditProduct;
                    tempString = null;
                    tempProduct = product;
                    return;
                }
                else if (whatEdit == "Size")
                {
                    Console.Write("Введите размер товара(1-100): ");
                    string sizeString = Console.ReadLine();
                    int size = Convert.ToInt32(sizeString);
                    product.Size = size;
                    method = Methods.MenuEditProduct;
                    tempString = null;
                    tempProduct = product;
                    return;
                }
                else if (whatEdit == "Cost")
                {
                    Console.Write("Текущая стоимость: {0}. Введите новую стомость: ", product.Cost);
                    string costString = Console.ReadLine();
                    double cost = Convert.ToDouble(costString);
                    cost = Math.Round(cost, 2);
                    product.Cost = cost;
                    method = Methods.MenuEditProduct;
                    tempString = null;
                    tempProduct = product;
                    return;
                }
            }
            catch (Exception)
            {
                method = Methods.MenuEditProduct;
                tempString = null;
                tempProduct = product;
                return;
            }
        }
        private static void MenuRemovProductFromShowCase(ShowCase showCase)
        {
            Console.Clear();
            Console.WriteLine();
            showCase.GetInfo();
            Console.WriteLine();
            Product product = DialogGetProduct();
            if (product == null || product.ShowCase != showCase)
            {
                Console.WriteLine("Товар не найден! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase);
                return;
            }
            else if (product != null && product.RemoveProduct(showCase))
            {
                Console.WriteLine("Товар удален! Нажмите Enter для повтора или ESC для возврата в меню...");
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
        private static void MenuAddProductToShowCase(ShowCase showCase, Methods? returnToMethod = null)
        {
            Console.Clear();
            Console.WriteLine();
            showCase.GetInfo();
            Console.WriteLine();
            Product.GetProductsInWarehouse();
            Console.WriteLine();
            Product product = DialogGetProduct();
            if (product == null)
            {
                Console.WriteLine("Товар не найден! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase, returnToMethod);
                return;
            }
            else if (product.ShowCase == showCase)
            {
                Console.WriteLine("Товар уже размещен на этой витрине! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase, returnToMethod);
                return;
            }
            else if (product.ShowCase != null)
            {
                Console.WriteLine("Товар размещен на другой витрине! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase, returnToMethod);
                return;
            }
            else if (product.PlaceProduct(showCase))
            {
                Console.WriteLine("Товар размещен! Нажмите Enter для повтора или ESC для возврата в меню...");
                UserInput(showCase, returnToMethod);
                return;
            }
            return;
            static void UserInput(ShowCase showCase, Methods? returnToMethod = null)
            {
                ConsoleKey consoleKey;
                consoleKey = Console.ReadKey(true).Key;
                while (consoleKey != ConsoleKey.Enter || consoleKey != ConsoleKey.Escape)
                {
                    if (consoleKey == ConsoleKey.Escape)
                    {
                        tempShowCase = showCase;
                        method = Methods.MenuEditShowCase;
                        if (returnToMethod != null)
                        {
                            method = (Methods)returnToMethod;
                            //returnToMethod = null;
                        }
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
        private static Product DialogGetProduct()
        {
            Console.Write("Введите ID товара и нажмите Enter: ");
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
            Console.Write("Введите ID витрины и нажмите Enter: ");
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
        private static void MenuProductsInWarehouse()
        {
            returnToMethod = null;
            Console.Clear();
            Console.WriteLine();
            Product.GetProductsInWarehouse();
            Console.WriteLine();
            if (ShowCase.Quantity > 0)
            {
                Console.WriteLine("1. Разместить товар на витрине");
            }
            Console.WriteLine("2. Добавить товар");
            Console.WriteLine("3. Копировать товар");
            if (Product.AllProductInWarehouse > 0)
            {
                Console.WriteLine("4. Редактировать товар");
                Console.WriteLine("5. Удалить товар");
            }
            Console.WriteLine("6. Назад");
            Console.WriteLine("7. Выход");
            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);
            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    tempShowCase = DialogGetShowCase();
                    if (tempShowCase == null)
                    {
                        method = Methods.MenuProductsInWarehouse;
                        break;
                    }
                    else
                    {
                        method = Methods.MenuAddProductToShowCase;
                        returnToMethod = Methods.MenuProductsInWarehouse;
                        break;
                    }
                case "2":
                    method = Methods.MenuAddProductToBase;                    
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine();
                    Product.GetProductsInWarehouse();
                    Console.WriteLine();
                    tempProduct = DialogGetProduct();
                    if (tempProduct == null)
                    {
                        Console.WriteLine("Товар не найден! Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInWarehouse;
                        break;
                    }
                    else
                    {
                        Product product = new Product(tempProduct.Size, tempProduct.Name, tempProduct.Cost);
                        Console.WriteLine("Товар скопирован и размещен на складе! Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInWarehouse;
                        tempProduct = null;
                        break;
                    }
                case "4":
                    Console.Clear();
                    Console.WriteLine();
                    Product.GetProductsInWarehouse();
                    Console.WriteLine();
                    tempProduct = DialogGetProduct();
                    if (tempProduct == null)
                    {
                        Console.WriteLine("Товар не найден! Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInWarehouse;
                        break;
                    }
                    else if (tempProduct.ShowCase != null)
                    {
                        Console.WriteLine("Нельзя редактировать товар на витрине! Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInWarehouse;
                        tempProduct = null;
                        break;
                    }
                    else
                    {
                        method = Methods.MenuEditProduct;
                        break;
                    }
                case "5":
                    Console.Clear();
                    Console.WriteLine();
                    Product.GetProductsInWarehouse();
                    Console.WriteLine();
                    tempProduct = DialogGetProduct();
                    if (tempProduct == null)
                    {
                        Console.WriteLine("Товар не найден. Нажмите Enter для возврата...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInWarehouse;
                        break;
                    }
                    else if(tempProduct.ShowCase != null)
                    {
                        Console.WriteLine("Нельзя удалить товар размещённый на витрине. Нажмите Enter для возврата...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInWarehouse;
                        tempProduct = null;
                        break;
                    }
                    else if (Product.DelProductFromBase(tempProduct))
                    {
                        Console.WriteLine("Товар успешно удален. Нажмите Enter для возврата...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInWarehouse;
                        tempProduct = null;
                        break;
                    }
                    break;
                case "6":
                    method = Methods.MenuProduct;
                    break;                
                case "7":
                    method = Methods.Exit;
                    break;
                default:
                    break;
            }

        }
        private static void MenuProductsInShowCases()
        {
            returnToMethod = null;
            Console.Clear();
            Console.WriteLine();
            Product.GetProductsInShowCase();
            Console.WriteLine();
            if (Product.AllProductInShowCases > 0)
            {
                Console.WriteLine("1. Удалить товар c витрины");
            }            
            Console.WriteLine("5. Назад");
            Console.WriteLine("6. Выход");
            ConsoleKeyInfo consoleKey;
            consoleKey = Console.ReadKey(true);
            switch (consoleKey.KeyChar.ToString())
            {
                case "1":
                    tempProduct = DialogGetProduct();
                    tempShowCase = tempProduct.ShowCase;
                    if (tempProduct == null || tempProduct.ShowCase == null)
                    {
                        Console.WriteLine("Ошибка поиска! Нажмите Entet для возврата в меню...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInShowCases;
                        break;
                    }
                    else if (tempShowCase.RemoveProductFromShowCase(tempProduct))
                    {
                        Console.WriteLine("Товар удален с витрины! Нажмите Entet для возврата в меню...");
                        Console.ReadLine();
                        method = Methods.MenuProductsInShowCases;
                        break;
                    }
                    break;
                case "5":
                    method = Methods.MenuProduct;
                    break;
                case "6":
                    method = Methods.Exit;
                    break;
                default:
                    break;
            }
        }
        private static void MenuAddProductToBase()
        {
            Console.Clear();
            Console.WriteLine();
            Product.GetProductsInWarehouse();
            Console.WriteLine();
            
            try
            {
                Console.Write("Введите наименование товара(не более 15 символов) и нажмите Enter: ");
                string nameProduct = Console.ReadLine();
                if (nameProduct == "")
                {
                    method = Methods.MenuAddProductToBase;
                    return;
                }
                Console.Write("Введите размер товара(1-100): ");
                string sizeString = Console.ReadLine();
                if (sizeString == "")
                {
                    method = Methods.MenuAddProductToBase;
                    return;
                }
                Console.Write("Введите стомость товара: ");
                string costString = Console.ReadLine();
                if (costString == "")
                {
                    method = Methods.MenuAddProductToBase;
                    return;
                }
                int size = Convert.ToInt32(sizeString);
                double cost = Convert.ToDouble(costString);
                Product product = new Product(size, nameProduct, cost);
                method = Methods.MenuProductsInWarehouse;
                return;
            }
            catch (Exception)
            {
                method = Methods.MenuAddProductToBase;
                return;
            }

        }
    }
}