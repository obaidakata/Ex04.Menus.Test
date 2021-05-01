using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class SubMenu : MenuItem
    {
        protected const int k_BackOrExitIndex = 0;
        protected List<MenuItem> m_InnerMenuItems;
        protected int m_Level;

        public SubMenu(string i_MenuName, int i_SubMenuLevel, List<MenuItem> i_MenuItems) : base(i_MenuName)
        {
            m_InnerMenuItems = i_MenuItems;
            m_Level = i_SubMenuLevel;
        }
    
        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_InnerMenuItems.Add(i_MenuItem);
            i_MenuItem.PreMenu = this;
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

        public override void DoWhenChosen()
        {
            Show();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(string.Format("Level: {0}, {1}", m_Level, m_HeaderName));
            string backOrExit;
            if (this is MainMenu)
            {
                backOrExit = "Exit";
            }
            else
            {
                backOrExit = "Back";
            }

            int index = 1;
            foreach (MenuItem menuItem in m_InnerMenuItems)
            {
                Console.WriteLine(string.Format("({0}) {1}", index++, menuItem.Name));
            }

            Console.WriteLine(string.Format("({0}) {1}", k_BackOrExitIndex, backOrExit));
            int userInput = getChoiceFromUser();
            if(userInput == k_BackOrExitIndex)
            {
                if(!(this is MainMenu))
                {
                    m_PreMenu.DoWhenChosen();
                }
            }
            else
            {
                m_InnerMenuItems[userInput - 1].DoWhenChosen();
            }
        }

        private int getChoiceFromUser()
        {
            int input = 0;
            Console.Write("Enter your choice: ");
            bool validInput = false;
            bool inputInRange = false;
            while(!validInput || !inputInRange)
            {
                validInput = int.TryParse(Console.ReadLine(), out input);
                if(validInput)
                {
                    inputInRange = input >= 0 && input <= m_InnerMenuItems.Count;
                }
                
                if(!validInput || !inputInRange)
                {
                    Console.Write("Invalid input, please try again: ");
                }
            }

            return input;
        }
    }
}
