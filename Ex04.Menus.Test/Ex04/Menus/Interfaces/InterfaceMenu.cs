using Ex04.Menus.Interfaces;
using System;
using Interfaces = Ex04.Menus.Interfaces;



namespace Ex04.Menus.Test
{
    public class InterfaceMenu: IClickObserver
    {
        Interfaces.MainMenu menu = new Interfaces.MainMenu(2);

        Interfaces.SubMenu versionAndDigit;
        Interfaces.Oparetion countCaptials;
        Interfaces.Oparetion showVersion;

        Interfaces.SubMenu timeDataShow;
        Interfaces.Oparetion timeShow;
        Interfaces.Oparetion dataShow;

        public InterfaceMenu(int i_MenuSize)
        {
            versionAndDigit = new SubMenu("Digits and Version");
            countCaptials = new Oparetion("Count Captials");
            countCaptials.Add(this as IClickObserver);
            showVersion = new Interfaces.Oparetion("Show Version");
            countCaptials.Add(this as IClickObserver);

            versionAndDigit.AddAsSubMenu(countCaptials);
            versionAndDigit.AddAsSubMenu(showVersion);

            //menu.Add(versionAndDigit);

            timeDataShow = new SubMenu("Time/Date Show");
            timeShow = new Oparetion("Time Show");
            timeShow.Add(this as IClickObserver);
            dataShow = new Oparetion("Date Show");
            dataShow.Add(this as IClickObserver);

            timeDataShow.AddAsSubMenu(timeShow);
            timeDataShow.AddAsSubMenu(dataShow);

            menu = new MainMenu(versionAndDigit, timeDataShow);
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