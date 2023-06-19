using System.Diagnostics;

namespace TryToGuessGame {
    internal class Program {
        private static int AskForInt(string question) {
            Console.Write(question + ' ');
            Console.ForegroundColor = ConsoleColor.Cyan;
            var answer = Console.ReadLine();
            Console.ResetColor();
            if (int.TryParse(answer, out int integer)) {
                return integer;
            }
            Console.WriteLine("Не ввел значение! Попробуй еще раз!");
            return AskForInt(question);
        }
        private struct Settings {
            public int max { get; private set; } = 100;
            public int min { get; private set; } = 0;
            public int attempts { get; private set; } = 3;
            public readonly int Answer;
            public Settings() {
                Answer = new Random().Next(min, max++);
            }
            public Settings(int max, int min, int attempts) {
                this.max = max;
                this.min = min;
                this.attempts = attempts;
                Answer = new Random().Next(min, max++);
            }
        }
        static void Main(string[] args) {
            new Program().Menu();
        }
        int input = 0;
        public void Menu() {
            while (true) {
                Settings settings = new();
                Console.WriteLine("1) Начать игру");
                Console.WriteLine("2) Настройки");
                Console.WriteLine("3) Выход");
                switch (AskForInt("Ваш выбор:")) {
                    case 1:
                        Game(settings);
                        break;
                    case 2:
                        GameSettings(ref settings);
                        break;
                    case 3:
                        return;
                }
            }
        }
        private void Game(Settings settings) {
            Console.Clear();
            int errors = 0;
            while (errors != settings.attempts) {
                input = AskForInt("Введите число:");
                if (input == settings.Answer) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вы выйграли\n");
                    Console.ResetColor();
                    return;
                }
                else if (input < settings.Answer) {
                    Console.WriteLine("Ваше число меньше");
                }
                else if (input > settings.Answer) {
                    Console.WriteLine("Ваше число Больше");
                }
                errors++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы проиграли\n");
            Console.ResetColor();
        }
        private void GameSettings(ref Settings settings) {
            Console.Clear();
            return;
            
        }

    }
    
}