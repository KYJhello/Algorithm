using System.Collections.Generic;
namespace Algorithm
{
    internal class Program
    {
        void List()
        {
            List<string> list = new List<string>();

            list.Add("A");
            list.Contains("B");
            string? findValue = list.Find(x => x.Contains('2'));
            int findIdx = list.FindIndex(x => x.Contains('2'));
        }

        static void Main(string[] args)
        {
            DataStructure.List<string> list = new DataStructure.List<string>();

            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");

            list.Remove("C");
            list.RemoveAt(1);

            Console.WriteLine(list[0] + list[1] + list.Count);
            Console.WriteLine();
            string? findValue = list.Find(x=>x.Contains('A'));

        }
    }
}