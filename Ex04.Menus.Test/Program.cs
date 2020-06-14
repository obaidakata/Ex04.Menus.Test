using System;
using Interfaces = Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Interfaces.MainMenu menu1 = new Interfaces.MainMenu(2);
            Item VersionAndDigit = new Item(2, "Digits and Version");
            Item countCaptials = new Item("Count Captials");
            Item showVersion = new Item("Show Version");

            VersionAndDigit.Add(countCaptials);
            VersionAndDigit.Add(showVersion);

            menu1.Add(VersionAndDigit);

            Item timeDataShow = new Item(2, "Time/Date Show");
            Item timeShow = new Item("Time Show");
            Item dataShow = new Item("Date Show");

            VersionAndDigit.Add(timeShow);
            VersionAndDigit.Add(dataShow);

            menu1.Add(timeDataShow);
        }

    }
}
