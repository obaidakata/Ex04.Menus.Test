using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface ISubMenu
    {

    }

    public interface IOperation
    {
        public void doWhenOperation();
    }

    public class MenuItem: ISubMenu, IOperation
    {
        private List<MenuItem> m_InnerMenuItems;
        private string m_HeaderName;

        public bool IsSubMenu
        {
            get
            {
                return m_InnerMenuItems.Count == 0;
            }
        }

        public MenuItem(string i_HeaderName, int i_SubMenuCount)
        {
            m_HeaderName = i_HeaderName;
            m_InnerMenuItems = new List<MenuItem>(i_SubMenuCount);
        }

        public void doWhenOperation()
        {

        }

        public void AddSubMenu(MenuItem i_sun)
        {
            m_InnerMenuItems.Add(i_sun);
        }

    }


}
