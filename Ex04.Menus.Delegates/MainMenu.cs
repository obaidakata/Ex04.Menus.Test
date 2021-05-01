using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : SubMenu
    {
        public MainMenu(string i_MenuName, int i_Level, List<MenuItem> i_MenuItems) : base(i_MenuName, i_Level, i_MenuItems)
        {
        }
    }
}
