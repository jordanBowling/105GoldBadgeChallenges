using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Options
                Console.WriteLine("Komodo Cafe Digital Manager\n" +
                    "\n" +
                    "Please select an option below:\n" +
                    "\n" +
                    "1. View All Combo Meals\n" +
                    "\n" +
                    "2. View Specific Combo Meal\n" +
                    "\n" +
                    "3. Create Combo Meal\n" +
                    "\n" +
                    "4. Update Combo Meal\n" +
                    "\n" +
                    "5. Delete Combo Meal\n" +
                    "\n" +
                    "6. Exit\n");

                // Input
                string input = Console.ReadLine();

                // Evaluate and proceed
                switch (input)
                {
                    case "1":
                        // View
                        DisplayExistingMenuItems();
                        break;
                    case "2":
                        DisplayItemByMealName();
                        break;
                    case "3":
                        // Create
                        CreateNewMenuItem();
                        break;
                    case "4":
                        // Update
                        UpdateExistingMenuItems();
                        break;
                    case "5":
                        // Delete
                        DeleteExistingMenuItems();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("See you later!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid Number:");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private void DisplayExistingMenuItems()
        {
            Console.Clear();

            List<Menu> menuItems = _menuRepo.GetMenu();
            foreach (Menu item in menuItems)
            {
                Console.WriteLine($"Combo #: {item.ComboNumber} \n" +
                    $"Meal Name: {item.MealName} \n" +
                    $"\n" +
                    $"Description: {item.Description} \n" +
                    $"\n" +
                    $"Ingredients: {item.Ingredients} \n" +
                    $"\n" +
                    $"Price: ${item.Price}" +
                    $"\n" +
                    $"\n");
            }
        }

        private void DisplayItemByMealName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the meal item you would like to see:");

            string menuItem = Console.ReadLine();

            Menu item = _menuRepo.GetContentByMealName(menuItem);
            if (item != null)
            {
                Console.WriteLine($"Combo #: {item.ComboNumber} \n" +
                    $"Meal Name: {item.MealName} \n" +
                    $"\n" +
                    $"Description: {item.Description} \n" +
                    $"\n" +
                    $"Ingredients: {item.Ingredients} \n" +
                    $"\n" +
                    $"Price: ${item.Price}" +
                    $"\n");
            }
            else
            {
                Console.WriteLine("Could not find a meal item by that name.");
            }
        }

        private void CreateNewMenuItem()
        {
            Console.Clear();
            Menu newMenuItem = new Menu();

            // Name
            Console.WriteLine("Enter the NAME of the new menu item:");
            newMenuItem.MealName = Console.ReadLine();
            // Description
            Console.WriteLine("Enter a DESCRIPTION for the new menu item:");
            newMenuItem.Description = Console.ReadLine();
            // Ingredients
            Console.WriteLine("Enter the INGREDIENTS for the new menu item:");
            newMenuItem.Ingredients = Console.ReadLine();
            // Price
            Console.WriteLine("Enter the PRICE for the new menu item:");
            string priceAsString = Console.ReadLine();
            newMenuItem.Price = double.Parse(priceAsString);
            // Combo Number
            Console.WriteLine("Enter the COMBO NUMBER you would like associated with the new menu item:");
            string comboNumberAsAString = Console.ReadLine();
            newMenuItem.ComboNumber = int.Parse(comboNumberAsAString);

            _menuRepo.AddContentToMenu(newMenuItem);
        }

        private void UpdateExistingMenuItems()
        {
            DisplayExistingMenuItems();

            Console.WriteLine("\nEnter the name of the meal item you would like to update.");

            string oldMenuItem = Console.ReadLine();

            Menu newMenuItem = new Menu();

            // Name
            Console.WriteLine("Enter the NAME of the new menu item:");
            newMenuItem.MealName = Console.ReadLine();
            // Description
            Console.WriteLine("Enter a DESCRIPTION for the new menu item:");
            newMenuItem.Description = Console.ReadLine();
            // Ingredients
            Console.WriteLine("Enter the INGREDIENTS for the new menu item:");
            newMenuItem.Ingredients = Console.ReadLine();
            // Price
            Console.WriteLine("Enter the PRICE for the new menu item:");
            string priceAsString = Console.ReadLine();
            newMenuItem.Price = double.Parse(priceAsString);
            // Combo Number
            Console.WriteLine("Enter the COMBO NUMBER you would like associated with the new menu item:");
            string comboNumberAsAString = Console.ReadLine();
            newMenuItem.ComboNumber = int.Parse(comboNumberAsAString);

            bool wasUpdated = _menuRepo.UpdateExistingContentToMenu(oldMenuItem, newMenuItem);

            if (wasUpdated)
            {
                Console.WriteLine("Menu WAS successfully updated.");
            }
            else
            {
                Console.WriteLine("Menu WAS NOT sucessfully updated.");
            }


        }

        private void DeleteExistingMenuItems()
        {

            DisplayExistingMenuItems();

            Console.WriteLine("\nEnter the title of the menu item you would like to remove");

            string input = Console.ReadLine();
            bool wasDeleted = _menuRepo.RemoveMealFromMenu(input);
            if (wasDeleted)
            {
                Console.WriteLine("The menu item WAS sucessfully removed");
            }
            else
            {
                Console.WriteLine("The menu item was NOT deleted");
            }


        }

        private void SeedData()
        {
            Menu shrimpScampi = new Menu(1, "Shrimp Scampi", "Delicious shrimp and pasta, with a wine sauce", "shrimp, angel hair pasta, wine, garlic", 7.99);

            Menu cheeseBurger = new Menu(2, "Cheese Burger", "A cheese burger on a sourdough bun with chedder cheese and grilled onions.", "sourdough bun, ground beef patty, provolone cheese, grilled onions, butter, salt, pepper", 9.99);

            Menu steakAndEggs = new Menu(3, "Steak & Eggs", "Steak and eggs cooked to the customers liking.", "steak, eggs, butter, salt, pepper, garlic salt, milk", 12.99);

            _menuRepo.AddContentToMenu(shrimpScampi);
            _menuRepo.AddContentToMenu(cheeseBurger);
            _menuRepo.AddContentToMenu(steakAndEggs);

        }
    }
}
