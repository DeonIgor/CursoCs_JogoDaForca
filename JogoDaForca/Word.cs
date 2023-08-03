namespace CursoCS2.Modulo17.Projetos.JogoDaForca
{
    internal class Word
    {
        public string Value { get; private set; } = string.Empty;

        public Word()
        {
            try
            {
                Value = WordsCollection.GetRandom();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Contains(char letter)
        {
            return Value.Contains(letter);
        }
    }
}
