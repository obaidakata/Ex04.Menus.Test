using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private List<MenuItem> m_InnerMenuItems;
        private string m_HeaderName;
        private int m_Level;
        private bool m_IsOpen;
        public bool IsOperation
        {
            get
            {
                return m_InnerMenuItems.Count == 0;
            }
        }

        public bool IsOpen
        {
            get
            {
                return m_IsOpen;
            }

            set
            {
                m_IsOpen = value;
            }
        }

        public int Level
        {
            get
            {
                return m_Level;
            }

        }

        public List<MenuItem> InnerMenu
        {
            get
            {
                return m_InnerMenuItems;
            }
        }

        public string Name
        {
            get
            {
                return m_HeaderName;
            }
        }

        public MenuItem(string i_HeaderName, int i_SubMenuCount)
        {
            m_HeaderName = i_HeaderName;
            m_InnerMenuItems = new List<MenuItem>(i_SubMenuCount);
            m_Level = 1;
            m_IsOpen = false;
        }

        public void setAsRoot()
        {
            m_Level = 0;
        }

        public void AddSubMenu(MenuItem i_sun)
        {
            i_sun.m_Level = m_Level +1;
            foreach(MenuItem menuItem in i_sun.m_InnerMenuItems)
            {
               menuItem.m_Level = i_sun.m_Level + 1;
            }
            m_InnerMenuItems.Add(i_sun);
        }

        public MenuItem this[int i]
        {
            get
            {
                return m_InnerMenuItems[i];
            }
        }
    }


}
