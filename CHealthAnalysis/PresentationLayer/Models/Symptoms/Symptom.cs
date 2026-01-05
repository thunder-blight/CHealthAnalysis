using System;
using CHealthAnalysis.Common;

namespace CHealthAnalysis.PresentationLayer.Models.Symptoms
{
    public class Symptom
    {
        // Name of the symptom
        public string SymptomName { get; }
        
        public Symptom(string name)
        {
            
            SymptomName = name;
        }

        public Symptom(SymptomType mySymptom)
        {
            throw new NotImplementedException();
        }

        // When the symptom started
        public DateTime DateStarted { get; private set; }
        
        // // Automatically calculates how many days since the symptom began
        public int DaysSinceStart => (int)(DateTime.Now - DateStarted).TotalDays;
        
        public virtual void CollectFromUser()
        {
            while (true)
            {
                Console.Write($"When did your {SymptomName} start? (YYYY-MM-DD): ");
                string input = Console.ReadLine().Trim();
            
                if (DateTime.TryParse(input, out DateTime date))
                {
                    DateStarted = date;
                    break;
                }
                
                Console.WriteLine("Invalid date format. Please try again. (e.g., 2025-01-30");
            }
        }

        public virtual string Evaluate()
        {
            return
                $"Sorry to hear you have been suffering from {SymptomName} for the last {DaysSinceStart} days" ;
        }
    }
}