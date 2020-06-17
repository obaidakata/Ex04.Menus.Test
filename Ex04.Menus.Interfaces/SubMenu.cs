using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MenuItem
    {
        private List<MenuItem> m_InnerMenuItems;
        private Button m_ReturnOperation;
        
        public int Count
        {
            get
            {
                return m_InnerMenuItems.Count;
            }
        }

        public SubMenu(string i_HeaderName) : base(i_HeaderName)
        {
            m_InnerMenuItems = new List<MenuItem>(0);
        }

        public MenuItem this[int i]
        {
            get
            {
                i += m_InnerMenuItems.Count - 1;
                i %= m_InnerMenuItems.Count;
                return m_InnerMenuItems[i];
            }
        }

        public void AddAsSubMenu(MenuItem i_sun)
        {
            i_sun.Level = Level + 1;
            m_InnerMenuItems.Add(i_sun);
        }

        public void SetReturnMenu(Button i_ReturnOperation)
        {
            m_ReturnOperation = i_ReturnOperation;
            m_InnerMenuItems.Add(i_ReturnOperation);
        }

        public override void Press()
        {
            Console.Clear();
            Print();
        }

        public void Print()
        {
            Console.WriteLine("Level {0}, {1}", Level, Name);
            int i = 1;
            foreach (MenuItem innerMenu in m_InnerMenuItems)
            {
                Console.WriteLine("({0}) {1}", i, innerMenu.Name);
                i++;
                i %= m_InnerMenuItems.Count;
            }
        }

        public bool IsLastIndex(int i_Index)
        {
            bool isLastIndex = false;
            if(m_InnerMenuItems[i_Index] is Button)
            {
                isLastIndex = (m_InnerMenuItems[i_Index] as Button) == m_ReturnOperation;
            }

            return isLastIndex;
        }
    }
}
