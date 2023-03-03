using DesignPatterns.Principles.InterfaceSegregation.Interfaces;
using System;

namespace DesignPatterns.Principles.InterfaceSegregation
{
    public class MultiFunctionDevice : IMultiFunctionDevice
    {
        private readonly IPrinter printer;
        private readonly IScanner scanner;

        public MultiFunctionDevice(IPrinter printer, IScanner scanner)
        {
            this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
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
