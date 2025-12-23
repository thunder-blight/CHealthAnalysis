using System;
using System.Collections.Generic;
using CHealthAnalysis.Common;
using CHealthAnalysis.Models.Symptoms;

namespace CHealthAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Symptom Input System ===\n");
            Console.WriteLine("Enter one symptom at a time");
            Console.WriteLine("Press ENTER after each symptom");
            Console.WriteLine("Type 'done' when finished\n");
            
            var symptoms = new List<Symptom>();

            while (true)
            {
                Console.Write("Enter a symptom (or type 'done' to finish): ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "done")
                    break;
                
                var canParse = Enum.TryParse(input ?? string.Empty, out SymptomType mySymptom);

                if (!canParse)
                {
                    Console.WriteLine("Please enter a valid symptom.\n");
                    continue;
                }

                Symptom symptom = new Symptom(mySymptom);

                switch (mySymptom)
                {
                    case SymptomType.Fever:
                        symptom = new FeverSymptom();
                        break;
                    
                    case SymptomType.HeadAche:
                        symptom = new HeadAcheSymptom();
                        break;
                    
                    case SymptomType.Dysentery:
                        symptom = new DysenterySymptom();
                        break;
                    
                }
                
                symptom.CollectFromUser();
                
                symptoms.Add(symptom);
                
                Console.WriteLine("Symptom recorded." );

            }
            
            Console.WriteLine("\n=== Summary of symptoms entered ===\n");

            foreach (var symptom in symptoms)
            {
                Console.WriteLine($"Symptom: {symptom.SymptomName}");
                
                string evaluation = symptom.Evaluate();
                
                if (!string.IsNullOrWhiteSpace(evaluation))
                    Console.WriteLine($"  → {evaluation}");
                
                Console.WriteLine();
            }
            
            Console.WriteLine("=== End of summary ===");
            
            
        }
    }
}