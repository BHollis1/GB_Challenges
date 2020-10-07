using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _menuList = new List<Menu>();

        public bool AddNewMenuItems(Menu newMenuItem)
        {
            int startingCount = _menuList.Count;
            _menuList.Add(newMenuItem);
            bool wasAdded = (_menuList.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> GetMenuItems()
        {
            return _menuList;
        }


        public bool DeleteMenuItemFromList(string mealName)
        {
            Menu content = GetMenuItemsByName(mealName);

            if (content == null)
            {
                return false;
            }
            int initialCount = _menuList.Count();
            _menuList.Remove(content);

            if (initialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
            
          
        }
        public Menu GetMenuItemsByName(string mealName)
        {
            foreach (Menu singleItem in _menuList)
            {
                if (singleItem.MealName.ToLower() == mealName.ToLower())
                {
                    return singleItem;
                }
            }
            return null;
        }




    }
}

