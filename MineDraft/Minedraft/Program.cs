using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        DraftManager manager = new DraftManager();
        while (true)
        {
            var input = Console.ReadLine().Split(new [] {' '});
            string command = input[0];
            if (input[0] == "Shutdown")
            {
                Console.WriteLine(manager.ShutDown());
                break;
                
            }

            var list = input.Skip(1).ToList();
            if (command == "RegisterHarvester")
            {
                Console.WriteLine(manager.RegisterHarvester(list));
            }
            else if (command == "RegisterProvider")
            {
                Console.WriteLine(manager.RegisterProvider(list));
            }
            else if (command == "Day")
            {
                Console.WriteLine(manager.Day());
            }
            else if (command == "Mode")
            {
                Console.WriteLine(manager.Mode(list));
            }
            else if (command == "Check")
            {
                Console.WriteLine(manager.Check(list));
            }
        }
    }
}

