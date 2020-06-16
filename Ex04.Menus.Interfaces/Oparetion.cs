using System;
using System.Collections.Generic;
using System.Threading;

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
    public class Oparetion : MenuItem, IClickable
    {
        private List<IClickObserver> m_ClickObservers;

        public Oparetion(string i_HeaderName) : base(i_HeaderName)
        {
            m_ClickObservers = new List<IClickObserver>();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void Add(IClickObserver i_ClickObserver)
        {
            m_ClickObservers.Add(i_ClickObserver);
        }

        public override void Click()
        {
            Console.Clear();
            foreach (IClickObserver observer in m_ClickObservers)
            {
                observer.Update(this);
            }
        }


        public static bool operator ==(Oparetion i_FirstOparetion, Oparetion i_secondOparetion)
        {
            return i_FirstOparetion.Name == i_secondOparetion.Name;
        }

        public static bool operator !=(Oparetion i_FirstOparetion, Oparetion i_secondOparetion)
        {
            return !(i_FirstOparetion == i_secondOparetion);
        }
    }

}
