using Ex04.Menus.Interfaces;
using System;
using System.Threading;
using Interfaces = Ex04.Menus.Interfaces;



namespace Ex04.Menus.Test
{
    public class InterfaceMenu: IClickObserver
    {
        Interfaces.MainMenu menu;

        Interfaces.SubMenu m_VersionAndDigits;
        Interfaces.Oparetion m_CountCaptials;
        Interfaces.Oparetion m_ShowVersion;

        Interfaces.SubMenu m_ShowtimeData;
        Interfaces.Oparetion m_TimeShow;
        Interfaces.Oparetion m_DataShow;

        public InterfaceMenu(int i_MenuSize)
        {
            m_VersionAndDigits = new SubMenu("Version And Digits");
            m_CountCaptials = new Oparetion("Count Captials");
            m_CountCaptials.Add(this as IClickObserver);
            m_ShowVersion = new Interfaces.Oparetion("Show Version");
            m_ShowVersion.Add(this as IClickObserver);

            m_VersionAndDigits.AddAsSubMenu(m_CountCaptials);
            m_VersionAndDigits.AddAsSubMenu(m_ShowVersion);

            m_ShowtimeData = new SubMenu("Show Time/Date ");
            m_TimeShow = new Oparetion("Time Show");
            m_TimeShow.Add(this as IClickObserver);
            m_DataShow = new Oparetion("Date Show");
            m_DataShow.Add(this as IClickObserver);

            m_ShowtimeData.AddAsSubMenu(m_TimeShow);
            m_ShowtimeData.AddAsSubMenu(m_DataShow);

            menu = new MainMenu(m_VersionAndDigits, m_ShowtimeData);
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
            Console.WriteLine(string.Format("Today's date is : {0}", DateTime.Now.Date.ToString("dd/mm/yyyy")));
        }
    }
}