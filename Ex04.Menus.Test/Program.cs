using System;
using Interfaces = Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfaceMenu system = new InterfaceMenu(2);
            system.ShowInterfaceMenu();

        }

    }
}
