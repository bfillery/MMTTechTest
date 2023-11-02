
namespace DynamicBinding
{
    class Program
    {
        static void Main(string[] args)
        {

            object obj = "Bruce";

            //instead of e.g. obj.GetHashCode(), if the object type is not known and so the method not available at compile time
            //could use reflection:
            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null); //whatever args

            //e.g. if we wanted to work with Excel and do late binding
            //object excelObject = "someobject";
            //wouldn't work: 
            //excelObject.Optimise();

            //BUT, if we use dynamic data type:
            dynamic excelObject = "some object";
            excelObject.Optimise(); //...is fine: until run time => need ore unit tests :/



            //Also: there is implicit cast/ conversion if possible
            int i = 5;
            dynamic d = i; 
            long l = d;
        }
    }
}
