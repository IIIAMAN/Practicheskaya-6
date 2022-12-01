using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;


namespace PRAKTICHESKAYA_6
{
    internal class Program
    {
        public static string a;
        public static ConsoleKeyInfo key;

        static void Main(string[] args)
        {
            nach();
        }

        static void nach()
        {
            Human human = new Human("Илья", "70", "180");
            Human human1 = new Human("Серёжа", "68", "185");    
            Human human2 = new Human("Никита", "75", "187");
            string txt = human.Name + "\n" + human.Ves + "\n" + human.Rost + "\n" + human1.Name + "\n" + human1.Ves + "\n" + human1.Rost + "\n" + human2.Name + "\n" + human2.Ves + "\n" + human2.Rost;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите путь до файла ( вместе с названием ), который вы хотите открыть\n-----------------------------------------------------------------------");
                string a = Console.ReadLine();
                string myText = File.ReadAllText(a);
                Console.Clear();
                Console.WriteLine("Сохранить файл в одном из форматов (txt, json, xml) - F1. Закрыть программу - Escape\n-----------------------------------------------------------------------");
                Console.WriteLine(myText);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
                if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите путь файла(с названием), куда вы хотите сохранить текст?");
                    Console.WriteLine("--------------------------------------------------------------");
                    a = Console.ReadLine();
                    if (a.EndsWith("n"))
                    {
                        JsonConvert.SerializeObject(txt);
                        File.WriteAllText(a, txt);

                    }
                    if (a.EndsWith("l"))
                    {
                        List<Human> koko = new List<Human>();
                        koko.Add(human);
                        koko.Add(human1);
                        koko.Add(human2);
                        XmlSerializer xml = new XmlSerializer(typeof(List<Human>));
                        using (FileStream fs = new FileStream(a, FileMode.OpenOrCreate))
                        {
                            xml.Serialize(fs, koko);
                        }
                    }
                    if (a.EndsWith("t"))
                    {
                        File.WriteAllText(a, txt);
                    }
                    
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }

}