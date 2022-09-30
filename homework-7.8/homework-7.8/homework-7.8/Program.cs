using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework_7._8
{
    internal class Program
    {
        const string file = "file.txt";
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Введем 1 - вывести данные на экран");
                Console.WriteLine("Введем 2 - заполнить данные и добавить новую запись в конец файла");
                consoleKeyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (consoleKeyInfo.KeyChar)
                {
                    case '1':
                        Print();
                        break;

                    case '2':
                        Input();
                        break;
                }
            }

            while (consoleKeyInfo.Key != ConsoleKey.D0);
        }

        static void Input()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int id = 1;

            if (!File.Exists(file))
            {
                File.Create(file).Close();
                Console.WriteLine("Файл создан");
            }

            else
            {
                id = File.ReadAllLines(file).Length + 1;
            }

            Console.WriteLine($"{id}: Дата и время добавления записи: {DateTime.Now.ToString()}");
            stringBuilder.Append($"{id++}#");
            stringBuilder.Append($"{DateTime.Now.ToString()}#");
            Console.WriteLine("\n Введите Ф.И.О.:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите возраст:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите рост:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите дату рождения:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите место рождения:");
            stringBuilder.Append($"{Console.ReadLine()}");
            using (StreamWriter list = new StreamWriter("file.txt", true, Encoding.Unicode))

            {
                list.WriteLine(stringBuilder.ToString());
            }
        }

        static void Print()
        {

            if (!File.Exists(file))
            {
                Console.WriteLine("Файл не существует");
                return;
            }
            using (StreamReader list2 = new StreamReader(file, Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"id",5} {"Дата и время",10} {"Ф.И.О.",10} {"Возраст",26} {"Рост",10} {"Дата рождения",18} {"Место рождения",20}");

                while ((line = list2.ReadLine()) != null)
                {
                    string[] daty = line.Split('#');
                    Console.WriteLine($"{daty[0],0} {daty[1],5} {daty[2],5} {daty[3],5} {daty[4],12} {daty[5],17} {daty[6],18}");
                }
            }
        }
    }
}
