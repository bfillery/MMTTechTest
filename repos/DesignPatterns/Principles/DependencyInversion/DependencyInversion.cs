namespace DesignPatterns.Principles.DependencyInversion
{
    //High-level modules should not depend on low-level modules. Both should depend on abstractions.
    //Abstractions should not depend upon details.Details should depend upon abstractions.
    public class DependencyInversion
    {
        public static void Run()
        {
            Research.RunResearch();
        }
        
    }
}
