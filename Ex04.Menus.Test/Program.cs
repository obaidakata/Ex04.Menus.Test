using System;
using Interfaces = Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfaceMenu interfaceMenu = new InterfaceMenu(2);
            interfaceMenu.ShowInterfaceMenu();
        }
    }
}
