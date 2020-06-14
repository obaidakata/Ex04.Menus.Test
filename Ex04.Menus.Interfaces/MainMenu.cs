using System;
using System.Collections.Generic;

public struct Item
{
    public List<Item> m_InnerItems;
    public string m_Name;
    public bool m_IsOperation;

    public Item(int i_Size, string i_Name)
    {
        m_InnerItems = new List<Item>(i_Size);
        m_Name = i_Name;
        m_IsOperation = false;
    }

    public Item(string i_Name)
    {
        m_InnerItems = new List<Item>(0);
        m_Name = i_Name;
        m_IsOperation = true;
    }

    public int Length
    {
        get
        {
            return m_InnerItems.Count;
        }
    }

    public void Add(Item i_InnerItem)
    {
        m_InnerItems.Add(i_InnerItem);
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
            MenuItem header = new MenuItem(m_Header.m_Name, m_Header.Length);

            foreach (Item item in m_Header.m_InnerItems)
            {
                MenuItem subMenu = AddHelper(item);
                header.AddSubMenu(subMenu);
            }

            return header;
        }

        public  void Run()
        {
            int userInput;
            for (int i = 0;i<3;i++)//Should be While(1)
            {
                userInput = GetUserInput();
                if(m_menuItems[userInput].IsOperation)
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


        public void MakeTast()
        {
            Item VersionAndDigit = new Item(2, "Digits and Version");
            Item countCaptials = new Item("Count Captials");
            Item showVersion = new Item("Show Version");

            VersionAndDigit.Add(countCaptials);
            VersionAndDigit.Add(showVersion);

            Add(VersionAndDigit);
        }
        
    }
}
