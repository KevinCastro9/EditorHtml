using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");

            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            
            Console.WriteLine("Deseja Salvar o arquivo S/N ?");

            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Clear();
                Console.WriteLine("Em qual caminho deseja salvar o arquivo ?");
                var path = Console.ReadLine();

                Salve(file.ToString(), path);

                Viewer.Show(file.ToString(), path);
               
            }
            else
            {
                Menu.Show();
            }
            
        }

        public static void Salve(string text, string path)
        {
            try
            {          
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }          
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu o erro: {ex.Message} ao tentar salvar o arquivo. Por gentileza tente novamente!");
                Menu.Show();
            }
        }
    }
}
