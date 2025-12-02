using System;

namespace CHealthAnalysis.Models.Symptoms
{
    public class Symptom
    {
        // Name of the symptom
        public string Name { get; }
        
        protected Symptom(string name)
        {
            Name = name.ToLower();
        }
        
        // When the symptom started
        public DateTime DateStarted { get; private set; }
        
        // // Automatically calculates how many days since the symptom began
        public int DaysSinceStart => (int)(DateTime.Now - DateStarted).TotalDays;
        
        public virtual void CollectFromUser()
        {
            while (true)
            {
                Console.Write($"When did your {Name} start? (YYYY-MM-DD): ");
                string input = Console.ReadLine().Trim();
            
                if (DateTime.TryParse(input, out DateTime date))
                {
                    DateStarted = date;
                    break;
                }
                
                Console.WriteLine("Invalid date format. Please try again. (e.g., 2025-01-30");
            }
        }

        public virtual string Evaluate() => null;
    }
}