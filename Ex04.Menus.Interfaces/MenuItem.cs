using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IClickObserver
    {
        void Update(Oparetion i_Sender);
    }

    public interface IClickable
    {
        void Add(IClickObserver i_observer);
        void Notify();
    }

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

    public class SubMenu : MenuItem
    {
        private List<MenuItem> m_InnerMenuItems;
        private static Oparetion m_Back;
        private bool m_Open;

        public static Oparetion BackOperation
        {
            get
            {
                return m_Back;
            }
        }

        public bool Open
        {
            get
            {
                return m_Open;
            }

            set
            {
                m_Open = value;
            }
        }

        public SubMenu(string i_HeaderName) : base(i_HeaderName)
        {
            m_Back = new Oparetion("Exit");
        }

        public MenuItem this[int i]
        {
            get
            {
                return m_InnerMenuItems[i];
            }
        }

        public List<MenuItem> InnerMenu
        {
            get
            {
                return m_InnerMenuItems;
            }
        }

        public void AddAsSubMenu(MenuItem i_sun)
        {
            m_InnerMenuItems.Add(i_sun);
        }

        public void setAsRoot()
        {
            //m_Level = 0;
        }

        public override void Click()
        {
            Console.Clear();
            Print();
        }

        public void Print()
        {
            foreach(MenuItem innerMenu in m_InnerMenuItems)
            {
                innerMenu.PrintName();
            }
        }

    }

    public class Oparetion : MenuItem, IClickable
    {
        private List<IClickObserver> m_ClickObserver;

        public Oparetion(string i_HeaderName) : base(i_HeaderName)
        {

        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void Add(IClickObserver i_ClickObserver)
        {
            m_ClickObserver.Add(i_ClickObserver);
        }

        public override void Click()
        {
            // do requaerd operation
        }

    }

}
