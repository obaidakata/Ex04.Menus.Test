using System;
using System.Threading;
using Ex04.Menus.Interfaces;
using Interfaces = Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenu : IClickObserver
    {
        private MainMenu menu;

        private Oparetion m_CountCaptials;
        private Oparetion m_ShowVersion;
        private Oparetion m_TimeShow;
        private Oparetion m_DataShow;

        public InterfaceMenu(int i_MenuSize)
        {
            m_CountCaptials = new Oparetion("Count Captials", this as IClickObserver);
            m_ShowVersion = new Interfaces.Oparetion("Show Version", this as IClickObserver);

            m_TimeShow = new Oparetion("Time Show", this as IClickObserver);
            m_DataShow = new Oparetion("Date Show", this as IClickObserver);

            buildMenu();
        }

        private void buildMenu()
        {
            SubMenu versionAndDigits = new SubMenu("Version And Digits");

            versionAndDigits.AddAsSubMenu(m_CountCaptials);
            versionAndDigits.AddAsSubMenu(m_ShowVersion);

            SubMenu showtimeData = new SubMenu("Show Time/Date ");

            showtimeData.AddAsSubMenu(m_TimeShow);
            showtimeData.AddAsSubMenu(m_DataShow);

            menu = new MainMenu(versionAndDigits, showtimeData);
        }

        public void ShowInterfaceMenu()
        {
            menu.Show();
        }

        public void Update(Oparetion i_Sender)
        {
            if (i_Sender == m_CountCaptials)
            {
                countCapitals();
            }
            else if (i_Sender == m_ShowVersion)
            {
                showVersion();
            }
            else if (i_Sender == m_TimeShow)
            {
                ShowTime();
            }
            else if (i_Sender == m_DataShow)
            {
                ShowDate();
            }
            else
            {
                throw new Exception("sender unrecogizble");
            }

            Thread.Sleep(3000);
        }

        private void countCapitals()
        {
            Console.WriteLine("Please Insert a senctece");
            string input = Console.ReadLine();
            int capitalLettersCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    capitalLettersCounter++;
                }
            }

            if (capitalLettersCounter == 1)
            {
                Console.WriteLine(string.Format("1 capital letters was found"));
            }
            else
            {
                Console.WriteLine(string.Format("{0} capital letters were found", capitalLettersCounter));
            }
        }

        private void showVersion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }

        private void ShowTime()
        {
            Console.WriteLine(string.Format("Current time is : {0}", DateTime.Now.ToString("HH:mm:ss")));
        }

        private void ShowDate()
        {
            Console.WriteLine(string.Format("Today's date is : {0}", DateTime.Now.Date.ToString("dd/MM/yyyy")));
        }
    }
}