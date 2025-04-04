using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Prog6221_part_1
{
    namespace CybersecurityAwarenessBot
    {
        public class ImageManager
        {
            private string originalImagePath = "cybersecurity.jpg";
            
            public void DisplayCybersecurityImage()
            {
                try
                {
                    string asciiArt = ConvertImageToAscii(originalImagePath);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(asciiArt);
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error displaying cybersecurity image: {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("Continuing without cybersecurity image.");
                    Console.WriteLine("");
                }
            }

            private string ConvertImageToAscii(string imagePath)
            {
               
                using (Bitmap bitmap = new Bitmap(imagePath))
                {
                    StringBuilder asciiArt = new StringBuilder();

                    // Characters used for ASCII art
                    const string chars = "@%#*+=-:. ";

                    // Adjust the width and height for better aspect ratio
                    int width = bitmap.Width / 5; 
                    int height = bitmap.Height / 5; 

                    for (int y = 0; y < height; y++) // Process every row
                    {
                        for (int x = 0; x < width; x++) // Process every column
                        {
                            // Get the pixel color
                            Color pixelColor = bitmap.GetPixel(x * 5, y * 5);

                            // Calculate brightness
                            int brightness = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);

                            // Map brightness to ASCII character
                            int index = (brightness * (chars.Length - 1)) / 255;
                            asciiArt.Append(chars[index]);
                        }
                        asciiArt.AppendLine();
                    }

                    return asciiArt.ToString();
                }
            }
        }
    }
}