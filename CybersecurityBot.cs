using System;

namespace Prog6221_part_1
{
    namespace CybersecurityAwarenessBot
    {
        class CybersecurityBot
        {
            private SoundManager soundManager;
            private ImageManager imageManager;
            private QuestionAnswerManager qaManager;
            private string userName; // Variable to store user's name

            public CybersecurityBot()
            {
                soundManager = new SoundManager();
                imageManager = new ImageManager();
                qaManager = new QuestionAnswerManager();
            }

            public void Start()
            {
                soundManager.PlayGreeting();
                imageManager.DisplayCybersecurityImage();
                GreetUser();
                Chat();
            }

            private void GreetUser()
            {
                Console.Write("Please enter your name: ");
                userName = Console.ReadLine(); 

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("+==========================================================================+\r\n|__        _______ _     ____ ___  __  __ _____   _____ ___       _    ___ |\r\n|\\ \\      / / ____| |   / ___/ _ \\|  \\/  | ____| |_   _/ _ \\     / \\  |_ _||\r\n| \\ \\ /\\ / /|  _| | |  | |  | | | | |\\/| |  _|     | || | | |   / _ \\  | | |\r\n|  \\ V  V / | |___| |__| |__| |_| | |  | | |___    | || |_| |  / ___ \\ | | |\r\n|  _\\_/\\_/  |_____|_____\\____\\___/|_|_ |_|_____|   |_| \\___/  /_/   \\_\\___||\r\n| / ___| | | |  / \\|_   _| | __ ) / _ \\_   _|                              |\r\n|| |   | |_| | / _ \\ | |   |  _ \\| | | || |                                |\r\n|| |___|  _  |/ ___ \\| |   | |_) | |_| || |                                |\r\n| \\____|_| |_/_/   \\_\\_|   |____/ \\___/ |_|                                |\r\n+==========================================================================+");
                Console.WriteLine($"\nHello, {userName}! I'm the Cybersecurity Awareness Bot.");
                Console.WriteLine("How can I help you today?");
                Console.ResetColor();
            }

            private void Chat()
            {
                while (true)
                {
                    Console.WriteLine($"\n {userName}:"); 
                    string userInput = Console.ReadLine().Trim().ToLower();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Bot: Please enter a question.");
                        Console.ResetColor();
                        continue;
                    }

                    if (userInput == "exit")
                    {
                        Console.WriteLine("Bot: Goodbye! Stay safe online.");
                        break;
                    }

                    string response = qaManager.GetResponse(userInput);
                    TypewriterEffect(response);
                }
            }

            private void TypewriterEffect(string text, int delay = 30)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (char c in text)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(delay);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}