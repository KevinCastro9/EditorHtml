using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EditorHtml
{
    public static class Viewer
    {
        public static void Show(string text, string path)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÂO");
            Console.WriteLine("-----------");
            Replace(text);
            Console.WriteLine("-----------");
            Console.WriteLine($"O arquivo foi salvo com sucesso! No caminho: {path}");
            Console.WriteLine("Clique em qualquer tecla para voltar ao Menu!");
            Console.ReadKey();
            Menu.Show();
        }

        public static void Replace(string text)
        {
            //Ele pega tudo que está entre os dois strong
            //<\\s*strong[^>]*>
            //(.*?)
            //<\\s*/\\s*strong>
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');
            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            ((words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>'))
                        )
                    );
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }     
    }
}
