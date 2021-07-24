using System;
using static DesignPatterns.Principles.OpenClosed.Enums;

namespace DesignPatterns.Principles.OpenClosed
{

    //classes should be open for extension but closed for modification
    public class OpenClosed
    {
        private void OldStyle(Product[] products, Color color, Size size)
        {
            //old : you'd have to copy and edit code each time a new filter is added.
            var pf = new ProductFilter();
            Console.WriteLine($"{color} products (old):");
            foreach (var p in pf.FilterByColor(products, color))
            {
                Console.WriteLine($" - {p.Name} is {color}");
            }

            Console.WriteLine($"{size} products (old):");
            foreach (var p in pf.FilterBySize(products, size))
            {
                Console.WriteLine($" - {p.Name} is {size}");
            }

            Console.WriteLine($"{color}, {size} products (old):");
            foreach (var p in pf.FilterBySizeAndColor(products, size, color))
            {
                Console.WriteLine($" - {p.Name} is {color} and {size}");
            }
            Console.WriteLine();
        }

        private void NewStyle(Product[] products, Color color, Size size)
        {
            //By using interfaces and generics, can add filters / combination(but not change filters
            //that might already be in use elsewhere)
            var bf = new BetterFilter();
            Console.WriteLine($"{color} products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecfication(color)))
            {
                Console.WriteLine($" - {p.Name} is {color}");
            }

            Console.WriteLine($"{size} products (new):");
            foreach (var p in bf.Filter(products, new SizeSpecification(size)))
            {
                Console.WriteLine($" - {p.Name} is {size}");
            }


            Console.WriteLine($"{color}, {size} products (new):");
            foreach (var p in bf.Filter(
                                        products,
                                        new AndSpecification<Product>(
                                            new ColorSpecfication(color),
                                            new SizeSpecification(size)
                                            )
                                        )
                )
            {
                Console.WriteLine($" - {p.Name} is {color} and {size}");
            }

            Console.WriteLine();

        }

        public OpenClosed(Color color, Size size)
        {

            //this would be in program.main, of course...
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };


            OldStyle(products, color, size);

            NewStyle(products, color, size);
            
            Console.WriteLine();


        }
    }


}
