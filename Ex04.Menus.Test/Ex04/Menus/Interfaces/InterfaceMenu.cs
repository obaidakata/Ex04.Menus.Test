using System;
using System.Threading;
using Ex04.Menus.Interfaces;
using Microsoft.VisualBasic.CompilerServices;
using Interfaces = Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenu : IClickObserver
    {
        private MainMenu m_Menu;

        private Button m_CountCaptials;
        private Button m_ShowVersion;
        private Button m_ShowTime;
        private Button m_ShowDate;

        public InterfaceMenu(int i_MenuSize)
        {
            m_CountCaptials = new Button("Count Captials", this as IClickObserver);
            m_ShowVersion = new Interfaces.Button("Show Version", this as IClickObserver);

            m_ShowTime = new Button("Show Time", this as IClickObserver);
            m_ShowDate = new Button("Show Date", this as IClickObserver);

            buildMenu();
        }

        private void buildMenu()
        {
            SubMenu versionAndDigits = new SubMenu("Version And Digits");

            versionAndDigits.AddAsSubMenu(m_CountCaptials);
            versionAndDigits.AddAsSubMenu(m_ShowVersion);

            SubMenu showtimeData = new SubMenu("Show Time/Date ");

            showtimeData.AddAsSubMenu(m_ShowTime);
            showtimeData.AddAsSubMenu(m_ShowDate);

            m_Menu = new MainMenu(versionAndDigits, showtimeData);
        }

        public void ShowInterfaceMenu()
        {
            m_Menu.Show();
        }

        public void Update(Button i_Sender)
        {
            if (i_Sender == m_CountCaptials)
            {
                countCapitals();
            }
            else if (i_Sender == m_ShowVersion)
            {
                showVersion();
            }
            else if (i_Sender == m_ShowTime)
            {
                ShowTime();
            }
            else if (i_Sender == m_ShowDate)
            {
                showDate();
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

        private void showDate()
        {
            Console.WriteLine(string.Format("Today's date is : {0}", DateTime.Now.Date.ToString("dd/MM/yyyy")));
        }
    }
}