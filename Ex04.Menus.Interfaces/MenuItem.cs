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
        private MenuItem[] m_InnerMenuItems;
        private string m_HeaderName;

        public bool IsSubMenu
        {
            get
            {
                return m_InnerMenuItems.Length == 0;
            }
        }

        public MenuItem(string i_HeaderName, params MenuItem[] i_SubMenu)
        {
            m_HeaderName = i_HeaderName;
            m_InnerMenuItems = i_SubMenu;
        }

        public MenuItem()
        {
            //m_HeaderName = i_HeaderName;
            m_InnerMenuItems = new MenuItem[] { };
        }

        public MenuItem(string i_HeaderName)
        {
            m_HeaderName = i_HeaderName;
            m_InnerMenuItems = new MenuItem[] { };
        }

        public void doWhenOperation()
        {

        }

        public void AddSubMenu(MenuItem i_sun)
        {

        }

    }


}
