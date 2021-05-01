using System;

namespace Ex04.Menus.Delegates
{
    public class Operation : MenuItem
    {
        public event Action Chosen;

        public Operation(string i_HeaderName) : base(i_HeaderName)
        { 
        }

        public override void DoWhenChosen()
        {
            Console.Clear();
            OnChosen();
            System.Threading.Thread.Sleep(3000);
            m_PreMenu.DoWhenChosen();
        }

        protected virtual void OnChosen()
        {
            if(Chosen != null)
            {
                Chosen.Invoke();
            }
        }
    }
}
