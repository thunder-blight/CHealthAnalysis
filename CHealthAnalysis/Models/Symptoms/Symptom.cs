namespace CHealthAnalysis.Models.Symptoms
{
    public class Symptom
    {
        // A property holding the symptom name
        public string Name { get; }
    
        // Ensures all symptoms have a consistent read-only name
        protected Symptom(string name)
        {
            Name = name.ToLower();
        }

    }   
}