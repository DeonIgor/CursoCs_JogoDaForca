namespace CursoCS2.Modulo17.Projetos.JogoDaForca
{
    internal abstract class WordsCollection
    {
        private static List<string> words = new List<string>();

        private static void LoadWords()
        {
            try
            {
                using (StreamReader sr = new StreamReader("words.txt"))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        words.Add(line.ToUpper());
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Erro ao carregar palavras: " + e.Message);
            }
        }
        public static string GetRandom()
        {
            if (words.Count == 0)
                LoadWords();

            if (words.Count > 0)
                return words[new Random().Next(words.Count)];
            else
                throw new Exception("Não há palavras cadastradas");
        }
    }
}

