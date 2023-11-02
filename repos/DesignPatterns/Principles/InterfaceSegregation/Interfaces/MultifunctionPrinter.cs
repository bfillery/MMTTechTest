namespace DesignPatterns.Principles.InterfaceSegregation.Interfaces
{
    //    public class MultifunctionPrinter : IMachine
    public class MultifunctionPrinter : IPrinter, IFax, IScanner
    {
        public void Fax(Document d)
        {
            //throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            //throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            //throw new NotImplementedException();
        }
    }
}
