namespace CHealthAnalysis.Models.Symptoms

{
    // Derived class for a symptom that has a temperature value
    public class FeverSymptom : Symptom
    {
        // Property to store the user's temperature
        public float Temperature { get; set; }

        // Constructor - requires a temperature value
        public FeverSymptom(float temperature) : base("fever")
        {
            Temperature = temperature;
        }
        
        // Method to check if it qualifies as a fever
        public bool IsFever()
        {
            return Temperature > 37.5f;
        }
    }   
}