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
            PrintPreview();

            int userInput;

            
            for (int i = 0;i<3;i++)//Should be While(1)
            {
                foreach (MenuItem menuItem in m_menuItems)
                {
                    print(menuItem, false);
                }

                userInput = GetUserInput();
                
            }
        }

        private void print(MenuItem menuItem, bool i_IsInner)
        {
            if (i_IsInner)
            {
                Console.Write("     ");
            }
            Console.WriteLine(menuItem.Name);
        }

        public int GetUserInput()
        {
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        public void PrintPreview()
        {
            Console.WriteLine(" -------Menu Preview-----------");
            foreach (MenuItem menuItem in m_menuItems)
            {
                PrintHelper(menuItem);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
        }

        public void PrintHelper(MenuItem menuItem)
        {
            Console.WriteLine(menuItem.Name);

            foreach (MenuItem innerMenu in menuItem.InnerMenu)
            {
                for (int i = 0; i < innerMenu.Level; i++)
                {
                    Console.Write("     ");
                }
                PrintHelper(innerMenu);
            }
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
