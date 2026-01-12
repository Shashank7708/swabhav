using System;
public class Program{
    public static void Main(string[] args){
        Console.WriteLine("hello World");
        Colorful.Console.WriteAscii($"hello {args[0]}");
    }
}