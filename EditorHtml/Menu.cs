using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorHtml
{
    public static class Menu
    {
        private static int NumberLinesMenuGlobal = 20;
        private static int NumberColumnsMenuGlobal = 50;

        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawScreen()
        {
            Console.Write("+");
            GeneratesColumns(true, NumberColumnsMenuGlobal);
            Console.Write("+");
            Console.Write("\n");
            GenerateLines(NumberLinesMenuGlobal);
            Console.Write("+");
            GeneratesColumns(true, NumberColumnsMenuGlobal);
            Console.Write("+");
        }

        public static void GeneratesColumns(bool borda, int quantidadeColumns)
        {
            for (int columns = 0; columns <= quantidadeColumns; columns++)
            {
                if (borda)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }

        public static void GenerateLines(int numberLines)
        {
            for (int lines = 0; lines <= numberLines; lines++)
            {
                Console.Write("|");
                GeneratesColumns(false, NumberColumnsMenuGlobal);
                Console.Write("|");
                Console.Write("\n");
            }
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("--------------------------");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma das opções abaixo");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Console.WriteLine("View");break; 
                case 0:
                {
                    Console.Clear(); 
                    Environment.Exit(0);
                    break;
                }
                default: Show(); break;
            }
        }
    }
}
