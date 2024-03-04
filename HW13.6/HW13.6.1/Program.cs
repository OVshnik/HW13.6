using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;
using HW13_6_1;
using System.Diagnostics;
using System.Windows.Markup;


namespace HW13_6_1
{
    internal class Program
{
    static void Main(string[] args)
    {
        var path = Path.Combine("C:\\Users\\MSI\\Documents", "Text.txt");

        var timer = new Stopwatch();
        timer.Start();

        Console.WriteLine("Add file in List");
        for (int i = 0; i < 10; i++)
        {
            timer.Restart();
            WriteInList(path);
            timer.Stop();
            Console.WriteLine(timer.Elapsed.Milliseconds);
        }
        Console.WriteLine();

        Console.WriteLine("Add file in LinkedList");
        for (int i = 0; i < 10; i++)
        {
            timer.Restart();
            WriteInLinkedList(path);
            timer.Stop();
            Console.WriteLine(timer.Elapsed.Milliseconds);
        }
    }
    static void WriteInLinkedList(string path)
    {

        LinkedList<string> values = new();

        string? symbols = File.ReadAllText(path);

        var array = symbols.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in array)
        {
            values.AddFirst(item);
        }


    }
    static void WriteInList(string path)
    {
        List<string> values = new();

        string? symbols = File.ReadAllText(path);

        var array = symbols.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in array)
        {
            values.Add(item);
        }


    }
}
}