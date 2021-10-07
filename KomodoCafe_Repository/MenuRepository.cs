using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuRepository
    {
        public List<Menu> _menuItems = new List<Menu>();

        // C
        public void AddContentToMenu(Menu content)
        {
            _menuItems.Add(content);

        }

        // R
        public List<Menu> GetMenu()
        {
            return _menuItems;
        }

        // U
        public bool UpdateExistingContentToMenu(string originalMenuItem, Menu newMenuItem)
        {
            Menu oldMenuItem = GetContentByMealName(originalMenuItem);

            if (oldMenuItem != null)
            {
                oldMenuItem.MealName = newMenuItem.MealName;
                oldMenuItem.ComboNumber = newMenuItem.ComboNumber;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.Ingredients = newMenuItem.Ingredients;
                oldMenuItem.Price = newMenuItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        // D

        public bool RemoveMealFromMenu(string mealName)
        {
            Menu content = GetContentByMealName(mealName);

            if (content == null)
            {
                return false;
            }

            int initialCount = _menuItems.Count;
            _menuItems.Remove(content);

            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        // Helper
        public Menu GetContentByMealName(string mealName)
        {
            foreach (Menu content in _menuItems)
            {
                if (content.MealName.ToLower() == mealName.ToLower())
                {
                    return content;
                }
            }

            return null;
        }
    }
}
