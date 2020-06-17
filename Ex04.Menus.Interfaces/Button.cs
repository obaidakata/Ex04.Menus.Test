using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public interface IClickObserver
    {
        void Update(Button i_Sender);
    }

    public interface IClickable
    {
        void Add(IClickObserver i_observer);

        void Notify();
    }

    public class Button : MenuItem, IClickable
    {
        private List<IClickObserver> m_ClickObservers;

        public static bool operator ==(Button i_FirstOparetion, Button i_SecondOparetion)
        {
            return i_FirstOparetion.Name == i_SecondOparetion.Name;
        }

        public static bool operator !=(Button i_FirstOparetion, Button i_SecondOparetion)
        {
            return !(i_FirstOparetion == i_SecondOparetion);
        }

        public Button(string i_HeaderName, IClickObserver i_ClickObserver) : base(i_HeaderName)
        {
            m_ClickObservers = new List<IClickObserver>();
            Add(i_ClickObserver);
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void Add(IClickObserver i_ClickObserver)
        {
            m_ClickObservers.Add(i_ClickObserver);
        }

        public override void Press()
        {
            Console.Clear();
            foreach (IClickObserver observer in m_ClickObservers)
            {
                observer.Update(this);
            }
        }

        public override bool Equals(object i_SecondOparetion)
        {
            return this == (Button)i_SecondOparetion;
        }
    }
}
