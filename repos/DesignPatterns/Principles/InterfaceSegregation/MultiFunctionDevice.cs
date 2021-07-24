using DesignPatterns.Principles.InterfaceSegregation.Interfaces;
using System;

namespace DesignPatterns.Principles.InterfaceSegregation
{
    public class MultiFunctionDevice : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionDevice(IPrinter printer, IScanner scanner)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }

            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }
            this.printer = printer;
            this.scanner = scanner;
        }

        //here we are DELEGATING the calls to the inner printer/scanner objects: DECORATOR pattern
        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
}
