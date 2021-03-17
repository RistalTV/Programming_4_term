using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Lab_1_console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настраиваем косоль
            Console.Title = "Лабораторная работа №1 |   Вариант 6";
            Console.SetWindowSize(80, 40);
            Console.SetWindowPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorSize = 16;
            // Запускаем диалоговую воронку
            GUI.Start();
            //Console.ReadKey();
        }
    }
}
