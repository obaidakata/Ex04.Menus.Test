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
        private SubMenu m_menu;
        private Oparetion m_Exit;
        private Oparetion m_Back;
        public MainMenu(params MenuItem[] subMenues)
        {
            m_Exit = new Oparetion("Exit");
            m_Back = new Oparetion("Back");
            m_Exit.Add(this as IClickObserver);
            m_menu = new SubMenu("Menu root");
            m_menu.SetReturnMenu(m_Exit);
            foreach(MenuItem menuItem in subMenues)
            {
                if(menuItem is SubMenu)
                {

                }
                m_menu.AddAsSubMenu(menuItem);
            }
        }
        
        public  void Show()
        {
            MenuNavegate();
        }

        public void Update(Oparetion i_Sender)
        {
            if(i_Sender == m_Exit)
            {
                Environment.Exit(0);
            }
        }

        private int getUserInput() // Check if userInput valid
        {
            Console.WriteLine("Type");
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        private void MenuNavegate()
        {
            m_menu.Print();
            Stack<MenuItem> HierarchyStack = new Stack<MenuItem>();
            MenuItem current = m_menu;
            int userInput;
            do
            {
                current.Click();
                if (current is Oparetion)
                {
                    Thread.Sleep(3000);
                    if (HierarchyStack.Count > 0)
                    {
                        current = HierarchyStack.Pop();
                    }
                }
                else if (current is SubMenu)
                {
                    userInput = getUserInput();
                    if ((current as SubMenu).IsLastIndex(userInput))
                    {
                        if (HierarchyStack.Count > 0)
                        {
                            current = HierarchyStack.Pop();
                        }
                    }
                    else
                    {
                        HierarchyStack.Push(current);
                        current = (current as SubMenu)[userInput];
                    }
                }

            } while (true);
        }
    }
}
