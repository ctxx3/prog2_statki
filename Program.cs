using prog2_statki.Models;

namespace prog2_statki;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Game game = new();
        game.Start();
    }
}