using System;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        protected string m_HeaderName;
        private int m_Level;

        public string Name
        {
            get
            {
                return m_HeaderName;
            }
        }

        public int Level
        {
            get
            {
                return m_Level;
            }

            set
            {
                m_Level = value;
            }
        }

        protected MenuItem(string i_HeaderName)
        {
            m_Level = 0;
            m_HeaderName = i_HeaderName;
        }

        public abstract void Press();
    }
}
