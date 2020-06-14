using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

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
        private MenuItem m_menuRoot;

        public MainMenu(int i_Size)
        {
            m_menuRoot = new MenuItem("Header", i_Size);
            m_menuRoot.setAsRoot();
        }
        
        public void Add(Item m_Header)
        {
            MenuItem header = AddHelper(m_Header);
            m_menuRoot.AddSubMenu(header);
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
            MenuNavegate();
        }

        private int getUserInput()
        {
            Console.WriteLine("Type");
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        public void PrintPreview()
        {
            Console.WriteLine(" -------Menu Preview-----------");
            foreach (MenuItem menuItem in m_menuRoot.InnerMenu)
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

        private void MenuNavegate()
        {
            print();
            Stack<MenuItem> HierarchyStack = new Stack<MenuItem>();
            MenuItem current = m_menuRoot;
            print();
            int userInput;
            do
            {
                userInput = getUserInput();
                if(userInput == -5)
                {
                    if (HierarchyStack.Count > 0)
                    {
                        current.IsOpen = false;
                        current = HierarchyStack.Pop(); 
                    }
                }
                else if(!current[userInput].IsOperation)
                {
                    HierarchyStack.Push(current);
                    current = current[userInput];
                    current.IsOpen = true;
                   
                }
                else
                {
                    Console.WriteLine("error, Type Agin");
                    Thread.Sleep(3000);
                }

                print();
            } while (true);
        }

        private void print()
        {
            Console.Clear();
            foreach (MenuItem menuItem in m_menuRoot.InnerMenu)
            {
                PrintH(menuItem);
            }
        }

        public void PrintH(MenuItem menuItem)
        {
            
            Console.WriteLine(menuItem.Name);
            foreach (MenuItem innerMenu in menuItem.InnerMenu)
            {
                if (menuItem.IsOpen)
                {
                    for (int i = 0; i < innerMenu.Level - 1; i++)
                    {
                        Console.Write("     ");
                    }
                    PrintH(innerMenu);
                }
            }
        }
    }
}
