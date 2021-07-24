namespace HelloWorld.Fundamentals
{
    public class Validity
    {
        public static bool IsValid(int NumberToTest)
        {

            if (NumberToTest >= 1 && NumberToTest <= 10) return true;

            return false;
        }
        
    }
}