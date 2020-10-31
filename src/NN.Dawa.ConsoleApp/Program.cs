using Mock.Dawa.Lib;
using System;
using System.IO;

namespace Mock.Dawa.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new DawaClient();

            for (int i = 0; i < 300; i++)
            {
                var recievedData = client.GetDataFromDawa(GetRandomString());
                Console.WriteLine(recievedData);
                StreamWriter writer = new StreamWriter("../../../output.csv", true);
                writer.WriteLine(recievedData);
                writer.Close();
            }

        }
        static string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
