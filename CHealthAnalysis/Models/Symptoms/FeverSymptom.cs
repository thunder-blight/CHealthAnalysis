using System;

namespace CHealthAnalysis.Models.Symptoms
{
    public class FeverSymptom : Symptom
    {
        // Stores user's fever temperature
        public float Temperature { get; private set; }

        // Constructor calls base with symptom name
        public FeverSymptom() : base("fever") { }

        // Override input collection
        public override void CollectFromUser()
        {
            // Loop until valid input is entered
            while (true)
            {
                base.CollectFromUser();
                
                // Prompt user
                Console.Write("Enter your fever temperature in Celsius: ");
                // Read user input
                string input = Console.ReadLine();

                // Check if input is a number
                if (float.TryParse(input, out float temp))
                {
                    // Validate temperature is realistic
                    if (temp < 30f || temp > 45f)
                    {
                        // Error message
                        Console.WriteLine("Temperature out of realistic range. Try again.");
                        // Loop again
                        continue;
                    }

                    // Store valid temperature
                    Temperature = temp;
                    // Exit loop
                    break; 
                }
                else
                {
                    // Input was not a number
                    Console.WriteLine("Invalid input. Please enter a number."); 
                }
            }
        }

        // Override evaluation method
        public override string Evaluate()
        {
            // Low/normal temperature
            if (Temperature <= 37.5f) return "No fever";
            // Moderate fever
            if (Temperature <= 39f) return "Mild fever";
            // High temperature
            return "High fever"; 
        }
    }
}