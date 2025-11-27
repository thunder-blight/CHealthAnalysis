namespace CHealthAnalysis.Models.Symptoms
{
    public class Symptom
    {
        // Property holding the symptom name
        public string Name { get; }

        // Constructor for setting the name
        protected Symptom(string name)
        {
            // Store name in lowercase for consistency
            Name = name.ToLower(); 
        }

        // Optional evaluation method
        public virtual string Evaluate() 
        {
            // Default: no evaluation
            return null;
        }

        // Optional input collection, does nothing by default
        public virtual void CollectInputFromUser() { } 
    }
}