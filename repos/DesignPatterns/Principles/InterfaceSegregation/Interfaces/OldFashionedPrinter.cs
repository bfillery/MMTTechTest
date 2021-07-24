namespace DesignPatterns.Principles.InterfaceSegregation.Interfaces
{
    //public class OldFashionedPrinter : IMachine
    public class OldFashionedPrinter : IPrinter
    {

        //What do we do?? All it does is print, IMachine is too broad
        //answer - interface segregation
        //NB: An interace can inherit from another interface so could have IMultiFunction...

        public void Print(Document d)
        {
            //throw new NotImplementedException();
        }
        //public void Fax(Document d)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Scan(Document d)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
