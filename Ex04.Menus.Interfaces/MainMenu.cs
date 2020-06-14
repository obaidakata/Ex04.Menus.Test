using System;
using System.Collections.Generic;

public struct Item
{
    public Item[] m_InnerItems;
    public string m_Name;
    public bool m_IsOperation;

    public int Length
    {
        get
        {
            return m_InnerItems.Length;
        }
    }
}

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private List<MenuItem> m_menuItems;

        public MainMenu(int i_Size)
        {
            m_menuItems = new List<MenuItem>(i_Size);
        }
        
        public void Add(Item m_Header)
        {
            MenuItem header = AddHelper(m_Header);
            m_menuItems.Add(header);
        }

        private MenuItem AddHelper(Item m_Header)
        {
            MenuItem header = new MenuItem(m_Header.m_Name);
            if (m_Header.Length > 0)
            {
                foreach(Item item in m_Header.m_InnerItems)
                {
                    MenuItem subMenu = AddHelper(item);
                    header.AddSubMenu(subMenu);
                }
            }

            return header;
        }

        public  void Run()
        {
            int userInput;
            string[] subMenu;
            for (int i = 0;i<3;i++)//Should be While(1)
            {
                userInput = GetUserInput();
                if(m_menuItems[userInput].IsSubMenu)
                {
                    //subMenu = m_menuItems[userInput].SubMenu;
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
