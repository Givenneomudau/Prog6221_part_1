using System;
using System.Collections.Generic;
using System.Linq;

namespace Prog6221_part_1
{
    namespace CybersecurityAwarenessBot
    {
        public class QuestionAnswerManager
        {
            private readonly QuestionAnswerPair[] qaPairs = {
                new QuestionAnswerPair("what is cybersecurity, and why is it important?", "Cybersecurity protects computer systems, networks, and data from theft, damage, or unauthorized access. It's important to safeguard sensitive information, maintain privacy, prevent financial losses, and protect critical infrastructure from cyber threats."),
                new QuestionAnswerPair("define the terms encryption and decryption.", "Encryption: Converting plaintext data into a coded format to protect it from unauthorized access.\r\nDecryption: Converting encrypted data back into its original, readable form.\r\n"),
                new QuestionAnswerPair("define the terms virus, malware, and ransomware.", "Virus: A program that replicates itself and spreads to other files or systems, often causing harm.\r\nMalware: A broader term encompassing any malicious software that disrupts or gains unauthorized access to computer systems.\r\nRansomware: A malicious software encrypting files or computer systems and requesting a ransom for their decryption."),
                new QuestionAnswerPair("how are you?", "I'm doing well, thank you for asking! Ready to help you learn about cybersecurity."),
                new QuestionAnswerPair("what is a password?", "A password is a secret sequence of characters used to authenticate identity or gain access to a secured resource. A good password should be unique, strong, long, random, and changed regularly."),
                new QuestionAnswerPair("what's your purpose?", "My purpose is to educate you about cybersecurity awareness and best practices."),
                new QuestionAnswerPair("what are cookies in a web browser?", "Cookies are small text files that websites store on your computer to remember information about you, such as your login details or preferences."),
                new QuestionAnswerPair("what can i ask you about?", "You can ask me about password safety, phishing, safe browsing, malware, social engineering, data breaches, and other cybersecurity topics."),
                new QuestionAnswerPair("tell me about password safety", "Password safety is crucial! Use strong, unique passwords for each account."),
                new QuestionAnswerPair("tell me about phishing", "Phishing is a type of online scam where criminals try to trick you into giving them your personal information."),
                new QuestionAnswerPair("tell me about safe browsing", "Safe browsing involves taking precautions to protect your online security and privacy while using the internet."),
                new QuestionAnswerPair("tell me about malware", "Malware is software designed to harm or secretly access a computer system."),
                new QuestionAnswerPair("tell me about social engineering", "Social engineering is a technique that relies on human interaction to trick individuals into revealing sensitive information."),
                new QuestionAnswerPair("what is a data breach?", "A data breach is a security incident where sensitive data is accessed by unauthorized individuals."),
                new QuestionAnswerPair("how can i protect myself from malware?", "To protect yourself from malware, install and keep updated anti-malware software."),
                new QuestionAnswerPair("what is two-factor authentication?", "Two-factor authentication (2FA) adds an extra layer of security to your online accounts."),
                new QuestionAnswerPair("what are the signs of a phishing email?", "Signs of a phishing email include suspicious sender addresses and urgent language."),
                
                
                // Additional Questions and Answers
                new QuestionAnswerPair("what is a firewall?", "A firewall is a network security device that monitors and controls incoming and outgoing network traffic based on predetermined security rules."),
                new QuestionAnswerPair("what is a VPN?", "A VPN (Virtual Private Network) creates a secure connection over the internet, allowing users to send and receive data as if their devices were directly connected to a private network."),
                new QuestionAnswerPair("what is social media security?", "Social media security involves protecting your personal information and privacy on social media platforms."),
                new QuestionAnswerPair("how to create a strong password?", "To create a strong password, use a mix of letters, numbers, and symbols, and avoid using easily guessable information."),
                new QuestionAnswerPair("what is identity theft?", "Identity theft is the act of obtaining and using someone else's personal information without their consent, often for fraudulent purposes.")
            };

            public string GetResponse(string question)
            {
                foreach (var qa in qaPairs)
                {
                    if (question.Contains(qa.Question.ToLower()))
                    {
                        string response = "Bot: " + qa.Answer;
                        response += "\nBot: I hope this solution is helpful.";
                        return response;
                    }
                }

                // Suggest corrections if the question is not found
                string suggestion = SuggestCorrection(question);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Bot: I didn't quite understand that. Did you mean: {suggestion}?");
                Console.ResetColor();
                return "Bot: I'm sorry, I don't have an answer for that question. Please try asking something else.";
            }

            private string SuggestCorrection(string input)
            {
                // Simple spelling correction logic
                var keywords = qaPairs.Select(qa => qa.Question.ToLower()).ToArray();
                string closestMatch = keywords.OrderBy(k => LevenshteinDistance(input.ToLower(), k)).FirstOrDefault();
                return closestMatch ?? "something else";
            }

            private int LevenshteinDistance(string s, string t)
            {
                int n = s.Length;
                int m = t.Length;
                var d = new int[n + 1, m + 1];

                for (int i = 0; i <= n; i++) d[i, 0] = i;
                for (int j = 0; j <= m; j++) d[0, j] = j;

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                        d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                    }
                }

                return d[n, m];
            }
        }
    }
}