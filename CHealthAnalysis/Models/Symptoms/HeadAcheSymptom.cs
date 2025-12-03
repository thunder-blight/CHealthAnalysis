using System;

namespace  CHealthAnalysis.Models.Symptoms
{
    public class HeadAcheSymptom : Symptom
    {
        public string Severity { get; set; }
        
        public HeadAcheSymptom() : base("headache") { }

        public override void CollectFromUser()
        {
            while (true)
            {
                base.CollectFromUser();
                
                Console.Write("How severe is your headache (mild, medium, severe)?: ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                if (input == "mild" || input == "medium" || input == "severe")
                {
                    Severity = input;
                    break;
                }
                
                Console.WriteLine("Please choose between: mild, medium, severe.");
            }
        }

        public override string Evaluate()
        {
            if (string.IsNullOrEmpty(Severity))
                return "";

            return $"Sorry to hear you've been dealing with a {Severity} headache for the last {DaysSinceStart} days.";
        }
    }
}