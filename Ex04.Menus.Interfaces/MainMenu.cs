using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
/*public struct Item
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
*/

namespace Ex04.Menus.Interfaces
{
    public class MainMenu: IClickObserver
    {
        private List<SubMenu> m_menu;
        private Oparetion exit;

        public MainMenu(params MenuItem[] subMenues)
        {
            m_menu = new SubMenu();
            foreach(MenuItem menuItem in subMenues)
            {
                m_menu.Add(menuItem);
            }
            exit = new Oparetion("Exit");
            m_menu.Add(exit);
        }
        
        public void Add(MenuItem m_Header)
        {
            m_menu.Add(m_Header);
        }

        public  void Show()
        {
            //PrintPreview();
            MenuNavegate();
        }

        public void Update(Oparetion i_Sender)
        {
            if(i_Sender == exit)
            {
                Environment.Exit(0);
            }
            else if(i_Sender == SubMenu.BackOperation)// check meybe can emplemnt better
            {

            }
        }

        private int getUserInput()
        {
            Console.WriteLine("Type");
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }
        private void MenuNavegate()
        {
            printMenu();
            Stack<MenuItem> HierarchyStack = new Stack<MenuItem>();
            int userInput;
            MenuItem current;
            do
            {
                userInput = getUserInput();
                // Check if userInput valid
                current = m_menu[userInput];
                if (current == SubMenu.BackOperation)
                {
                    if (HierarchyStack.Count > 0)
                    {
                        if (current is SubMenu)
                        {
                            (current as SubMenu).Open = false;
                        }
                        current = HierarchyStack.Pop(); 
                    }
                }
                else
                {
                    HierarchyStack.Push(current);
                    current.Click();
                    current = (current as SubMenu)[userInput];
                }
            } while (true);
        }

        private void printMenu()
        {
            Console.Clear();
            foreach (SubMenu menuItem in m_menu)
            {
                menuItem.Print();
            }
        }
        /*
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
*/
    }
}
