using Ex04.Menus.Interfaces;
using System;
using Interfaces = Ex04.Menus.Interfaces;



namespace Ex04.Menus.Test
{
    public class InterfaceMenu: IClickObserver
    {
        Interfaces.MainMenu menu = new Interfaces.MainMenu(2);
        Interfaces.MenuItem versionAndDigit;
        Interfaces.MenuItem countCaptials;
        Interfaces.MenuItem showVersion;

        Interfaces.MenuItem timeDataShow;
        Interfaces.MenuItem timeShow;
        Interfaces.MenuItem dataShow;

        public InterfaceMenu(int i_MenuSize)
        {
            menu = new Interfaces.MainMenu(i_MenuSize);
            versionAndDigit = new Interfaces.MenuItem("Digits and Version", 2);
            countCaptials = new Interfaces.MenuItem("Count Captials");
            countCaptials.Add(this as IClickObserver);
            showVersion = new Interfaces.MenuItem("Show Version");
            countCaptials.Add(this as IClickObserver);

            versionAndDigit.AddSubMenu(countCaptials);
            versionAndDigit.AddSubMenu(showVersion);

            menu.Add(versionAndDigit);

            timeDataShow = new Interfaces.MenuItem("Time/Date Show", 2);
            timeShow = new Interfaces.MenuItem("Time Show");
            timeShow.Add(this as IClickObserver);
            dataShow = new Interfaces.MenuItem("Date Show");
            dataShow.Add(this as IClickObserver);

            timeDataShow.AddSubMenu(timeShow);
            timeDataShow.AddSubMenu(dataShow);

            menu.Add(timeDataShow);
        }

        public void ShowInterfaceMenu()
        {
            menu.Show();
        }

        public void Update(MenuItem i_Sender)
        {
            if(i_Sender == countCaptials)
            {

            }
            else if (i_Sender == showVersion)
            {

            }
            else if (i_Sender == timeShow)
            {

            }
            else if (i_Sender == dataShow)
            {

            }
            else
            {
                throw new Exception("sender unrecogizble");
            }
        }

        

        public void CountCapitals()
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

        public void ShowVersion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }

        public void ShowTime()
        {
            Console.WriteLine(string.Format("Current time is : {0}", DateTime.Now.ToString("HH:mm:ss")));
        }

        public void ShowDate()
        {
            Console.WriteLine(string.Format("Today's date is : {0}", DateTime.Now.Date.ToString("dd/mm/yyyy")));
        }
    }
}