namespace Prog6221_part_1
{
    namespace CybersecurityAwarenessBot
    {
        public class QuestionAnswerPair
        {
            public string Question { get; }
            public string Answer { get; }

            public QuestionAnswerPair(string question, string answer)
            {
                Question = question;
                Answer = answer;
            }
        }
    }
}