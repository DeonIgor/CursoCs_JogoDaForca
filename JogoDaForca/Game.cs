namespace CursoCS2.Modulo17.Projetos.JogoDaForca
{
    internal class Game
    {
        public Word Word { get; private set; }
        private string guessWord;
        private HashSet<char> letters;
        private int errors = 0;
        private readonly int maxErrors = 3;

        public Game()
        {
            this.Word = new Word();
            this.guessWord = new string('_', Word.Value.Length);
            this.letters = new HashSet<char>();
        }

        public Game(int maxErrors)
        {
            this.Word = new Word();
            this.guessWord = new string('_', Word.Value.Length);
            this.letters = new HashSet<char>();
            this.maxErrors = maxErrors;
        }

        public void Start()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(guessWord);
                Console.WriteLine($"Tamanho: {guessWord.Length}");
                Console.WriteLine($"Letras já utilizadas: {string.Join(" - ", letters)}");
                Console.WriteLine($"Erros: {errors} / {maxErrors}");
                Console.Write("\nDigite uma letra: ");
                string? guess = Console.ReadLine();
                Guess(guess);
            } while (guessWord.Contains('_') && errors < maxErrors);

            if (errors >= maxErrors)
            {
                Console.Clear();
                Console.WriteLine("\nVocê perdeu!");
                Console.WriteLine($"A palavra era {Word.Value}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nVocê ganhou!");
                Console.WriteLine($"A palavra era {Word.Value}");
            }
        }

        public void Guess(string? guess)
        {
            if (guess == null)
                return;

            guess = guess.ToString().ToUpper();
            if (guess.Length > 1)
            {
                if (guess == Word.Value)
                {
                    guessWord = guess;
                }
                else
                {
                    errors = maxErrors;
                }
            }
            else if (letters.Contains(guess[0]))
            {
                Console.WriteLine("\nLetra já utilizada!");
                Console.ReadLine();
            }
            else if (Word.Contains(guess[0]))
            {
                for (int i = 0; i < Word.Value.Length; i++)
                {
                    if (Word.Value[i] == guess[0])
                    {
                        guessWord = guessWord.Remove(i, 1).Insert(i, guess);
                    }
                }
            }
            else
            {
                errors++;
            }

            letters.Add(guess[0]);
        }

    }
}
