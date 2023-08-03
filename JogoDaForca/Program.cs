namespace CursoCS2.Modulo17.Projetos.JogoDaForca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Game jogo = new Game();
                jogo.Start();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

