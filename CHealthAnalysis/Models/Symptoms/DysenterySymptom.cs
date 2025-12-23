using System;

namespace CHealthAnalysis.Models.Symptoms
{
    public class DysenterySymptom : Symptom
    {
        public int Frequency { get; private set; }

        public string StoolConsistency { get; private set; }
        
        public string Colour { get; private set; }

        public DysenterySymptom() : base("dysentery") { }

        public override void CollectFromUser()
        {
            base.CollectFromUser();

            while (true)
            {
                Console.WriteLine("How many times a day does this occur? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int freq) && freq > 0)
                {
                    Frequency = freq;
                    break;
                }

                Console.WriteLine("Please enter a valid response.");
            }

            while (true)
            {
                Console.Write("What is the stool consistency? (soft / hard / liquid): ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "soft" || input == "hard" || input == "liquid")
                {
                    StoolConsistency = input;
                    break;
                }
                
                Console.WriteLine("Please enter: soft, hard, or liquid");
            }

            while (true)
            {
                Console.Write("What colour is it? ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (!string.IsNullOrEmpty(input))
                {
                    Colour = input;
                    break;
                }
                
                Console.WriteLine("Colour cannot be empty.");
            }
            
        }
        
        public override string Evaluate()
        {
            return
                $"Your dysentery problem sounds bad {StoolConsistency} poo, {Frequency} times a day is painful. " +
                $"Sorry to hear that.";
        }
    }
   
}
