using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private List<MenuItem> m_menuItems;

        public MainMenu()
        {
            m_menuItems = new List<MenuItem>();
        }
        
        public IOperation AddOperationToMenu(string i_OperationName)
        {
            MenuItem operation = new MenuItem(i_OperationName);
            m_menuItems.Add(operation);

            return operation;
        }

        public void AddSubMenuToMenu(string i_SubMenuName)
        {
            MenuItem subMenu = new MenuItem(i_SubMenuName);
            m_menuItems.Add(subMenu);

        }

        public  void Run()
        {
            int userInput;
            string[] subMenu;
            for (int i = 0;i<3;i++)//Should be While(1)
            {
                userInput = GetUserInput();
                if(m_menuItems[userInput].HasSubMenu)
                {
                    subMenu = m_menuItems[userInput].SubMenu;
                }
            }
        }

        public int GetUserInput()
        {
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        public void Print()
        {

        }
        
    }
}
