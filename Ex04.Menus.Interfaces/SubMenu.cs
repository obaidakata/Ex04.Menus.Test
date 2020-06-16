using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MenuItem
    {
        private List<MenuItem> m_InnerMenuItems;
        private Oparetion m_ReturnOperation;

        public SubMenu(string i_HeaderName ): base(i_HeaderName)
        {
            m_InnerMenuItems = new List<MenuItem>(0);
        }

        public MenuItem this[int i]
        {
            get
            {
                return m_InnerMenuItems[i];
            }
        }


        public void AddAsSubMenu(MenuItem i_sun)
        {
            if(m_InnerMenuItems.Count > 0)
            {
                m_InnerMenuItems.Insert(m_InnerMenuItems.Count -1, i_sun);
            }
            else
            {
                m_InnerMenuItems.Add(i_sun);
            }
        }


        public void SetReturnMenu(Oparetion i_ReturnOperation)
        {
            m_ReturnOperation = i_ReturnOperation;
            m_InnerMenuItems.Add(m_ReturnOperation);
        }

        public override void Click()
        {
            Console.Clear();
            Print();
        }

        public void Print()
        {
            foreach (MenuItem innerMenu in m_InnerMenuItems)
            {
                innerMenu.PrintName();
            }
        }

        public bool IsLastIndex(int i_Index)
        {
            bool isLastIndex = false;
            if(m_InnerMenuItems[i_Index] is Oparetion)
            {
                isLastIndex = (m_InnerMenuItems[i_Index] as Oparetion)== m_ReturnOperation;
            }
            return isLastIndex;
        }
    }
}
