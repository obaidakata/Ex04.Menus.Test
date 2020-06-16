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
    public class MainMenu : IClickObserver
    {
        private SubMenu m_menu;
        private Oparetion m_Exit;
        private Oparetion m_Back;
        private Stack<MenuItem> m_HierarchyStack;
        private MenuItem m_CurentChosenMenuItem;

        public MainMenu(params MenuItem[] subMenues)
        {
            m_HierarchyStack = new Stack<MenuItem>();
            m_Exit = new Oparetion("Exit", this as IClickObserver);
            m_Back = new Oparetion("Back", this as IClickObserver);
            m_Back.Add(this as IClickObserver);

            m_menu = new SubMenu("Menu root");
            m_menu.SetReturnMenu(m_Exit);
            foreach(MenuItem menuItem in subMenues)
            {
                if(menuItem is SubMenu)
                {
                    (menuItem as SubMenu).SetReturnMenu(m_Back);
                }

                m_menu.AddAsSubMenu(menuItem);
            }

            m_CurentChosenMenuItem = m_menu;
        }
        
        public void Show()
        {
            int userInput;
            do
            {
                m_CurentChosenMenuItem.Click();

                if (m_CurentChosenMenuItem is SubMenu)
                {
                    userInput = getUserInput();
                    m_HierarchyStack.Push(m_CurentChosenMenuItem);
                    m_CurentChosenMenuItem = (m_CurentChosenMenuItem as SubMenu)[userInput];
                }
                else
                {
                    if (m_HierarchyStack.Count > 0)
                    {
                        m_CurentChosenMenuItem = m_HierarchyStack.Pop();
                    }
                }
            }
            while (true);
        }

        public void Update(Oparetion i_Sender)
        {
            if(i_Sender == m_Exit)
            {
                Environment.Exit(0);
            }
            else if (i_Sender == m_Back)
            {
                if (m_HierarchyStack.Count > 0)
                {
                    m_CurentChosenMenuItem = m_HierarchyStack.Pop();
                }

                if (m_HierarchyStack.Count > 0)
                {
                    m_CurentChosenMenuItem = m_HierarchyStack.Pop();
                }

                (m_CurentChosenMenuItem as SubMenu).Click();
            }
        }

        private int getUserInput() // Check if userInput valid
        {
            Console.WriteLine("Type");
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }
    }
}
