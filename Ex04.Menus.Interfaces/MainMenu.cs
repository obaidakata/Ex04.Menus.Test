using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IClickObserver
    {
        private SubMenu m_Menu;
        private Button m_Exit;
        private Button m_Back;
        private Stack<MenuItem> m_HierarchyStack;
        private MenuItem m_CurentChosenMenuItem;
        private bool m_MenuExit;

        public MainMenu(params MenuItem[] subMenues)
        {
            m_MenuExit = false;
            m_HierarchyStack = new Stack<MenuItem>();
            m_Exit = new Button("Exit", this as IClickObserver);
            m_Back = new Button("Back", this as IClickObserver);

            m_Menu = new SubMenu("Menu Menu");
            
            foreach(MenuItem menuItem in subMenues)
            {
                if(menuItem is SubMenu)
                {
                    (menuItem as SubMenu).SetReturnMenu(m_Back);
                }

                m_Menu.AddAsSubMenu(menuItem);
            }

            m_Menu.SetReturnMenu(m_Exit);
            m_CurentChosenMenuItem = m_Menu;
        }
        
        public void Show()
        {
            int userInput;
            do
            {
                m_CurentChosenMenuItem.Press();

                if (m_CurentChosenMenuItem is SubMenu)
                {
                    userInput = getUserInput();
                    m_HierarchyStack.Push(m_CurentChosenMenuItem);
                    m_CurentChosenMenuItem = (m_CurentChosenMenuItem as SubMenu)[userInput];
                }
                else
                {
                    if (m_HierarchyStack.Count > 0)
                    {
                        m_CurentChosenMenuItem = m_HierarchyStack.Pop();
                    }
                }
            }
            while (!m_MenuExit);
            Console.Clear();
        }

        public void Update(Button i_Sender)
        {
            if(i_Sender == m_Exit)
            {
                m_MenuExit = true;
            }
            else if (i_Sender == m_Back)
            {
                if (m_HierarchyStack.Count > 1)
                {
                    m_CurentChosenMenuItem = m_HierarchyStack.Pop();
                    m_CurentChosenMenuItem = m_HierarchyStack.Pop();
                }

                (m_CurentChosenMenuItem as SubMenu).Press();
            }
        }

        private int getUserInput()
        {
            int input = 0;
            Console.Write("Enter your choice: ");
            bool validInput = false;
            bool inputInRange = false;
            while (!validInput || !inputInRange)
            {
                validInput = int.TryParse(Console.ReadLine(), out input);
                if (validInput)
                {
                    inputInRange = input >= 0 && input < (m_CurentChosenMenuItem as SubMenu).Count;
                }

                if (!validInput || !inputInRange)
                {
                    Console.Write("Invalid input, please try again: ");
                }
            }

            return input;
        }
    }
}
