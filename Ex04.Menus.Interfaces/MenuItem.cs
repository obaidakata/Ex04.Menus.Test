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
        private string m_itemName;
        public MenuItem(string i_itemName)
        {
            m_itemName = i_itemName;
        }

        public void doWhenOperation()
        {

        }


    }


}
