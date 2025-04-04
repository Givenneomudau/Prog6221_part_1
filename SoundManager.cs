using System;
using System.IO;
using System.Media;

namespace Prog6221_part_1
{
    namespace CybersecurityAwarenessBot
    {
       public class SoundManager
        {
            private string greetingSoundPath = "greeting.wav";

            public void PlayGreeting()
            {
                try
                {
                    string fullSoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, greetingSoundPath);
                    SoundPlayer player = new SoundPlayer(fullSoundPath);
                    player.PlaySync();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error playing greeting: {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("Continuing without voice greeting.");
                }
            }
        }
    }
}