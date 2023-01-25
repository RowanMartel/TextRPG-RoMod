﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Program
    {

        static bool play = true;
        static ConsoleKey key;

        static Player player = new Player(5, 5, '@');
        


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (play)
            {
                if(Console.CursorVisible) Console.CursorVisible = false;
                key = Console.ReadKey(true).Key;
                if(key == ConsoleKey.Escape)
                {
                    play = false;
                }
                else
                {
                    player.Move(key);
                }
            }

        }
    }
}
