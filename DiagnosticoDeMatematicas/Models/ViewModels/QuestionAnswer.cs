namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Class representing a question and the answer that was chosen.
    /// </summary>
    public class QuestionAnswer
    {
        /// <summary>
        /// Object used to generate random values consistently.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Dictionary used to store the IDs of objects and the order in which the options are displayed.
        /// </summary>
        private static Dictionary<Guid, int[]> swapDictionary = new Dictionary<Guid, int[]>();

        /// <summary>
        /// Gets or sets the ID of the question.
        /// </summary>
        public int QuestionID { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        public Question Question { get; set; }

        /// <summary>
        /// Gets or sets the selected option.
        /// </summary>
        public int SelectedOption { get; set; }

        /// <summary>
        /// Gets or sets the ID of this object.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Shuffles the options of the question randomly.
        /// </summary>
        public void Shuffle()
        {
            int[] swaps = { 0, 1, 2, 3 };
            int n = 4;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = swaps[k];
                swaps[k] = swaps[n];
                swaps[n] = value;
            }

            QuestionAnswer aux = new QuestionAnswer
            {
                Question = new Question
                {
                    OptionA = Question.OptionA,
                    OptionB = Question.OptionB,
                    OptionC = Question.OptionC,
                    OptionD = Question.OptionD
                }
            };

            Question.OptionA = aux.GetOption(swaps[0]);
            Question.OptionB = aux.GetOption(swaps[1]);
            Question.OptionC = aux.GetOption(swaps[2]);
            Question.OptionD = aux.GetOption(swaps[3]);

            Guid = Guid.NewGuid();
            swapDictionary.Add(Guid, swaps);
        }

        /// <summary>
        /// Gets the option number that was chosen in the random state.
        /// </summary>
        /// <returns>The number of the option.</returns>
        public int GetAnswer()
        {
            var swaps = swapDictionary[Guid];
            swapDictionary.Remove(Guid);
            return swaps[SelectedOption];
        }

        /// <summary>
        /// Gets the option given the option number.
        /// </summary>
        /// <param name="option">The number of the option.</param>
        /// <returns>The option string.</returns>
        private string GetOption(int option)
        {
            switch (option)
            {
                case 0: return Question.OptionA;
                case 1: return Question.OptionB;
                case 2: return Question.OptionC;
                case 3: return Question.OptionD;
                default: return null;
            }
        }
    }
}