using System;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        protected string m_HeaderName;

        public string Name
        {
            get
            {
                return m_HeaderName;
            }
        }

        protected MenuItem(string i_HeaderName)
        {
            m_HeaderName = i_HeaderName;
        }

        public abstract void Click();

        public void PrintName()
        {
            Console.WriteLine(m_HeaderName);
        }
    }
}
