using DesignPatterns.Principles.DependencyInversion.Interfaces;
using System;

namespace DesignPatterns.Principles.DependencyInversion
{
    public class Research
    {

        public Research(IRelationshipBrowser browser)
        {
            foreach(var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }


        //prior to introducing the IRelationshipBrowser interface
        //we expose teh low-level class data store, which comits us to a 
        //particular way of storing teh data and stops the low level class from changing

        //public Research(Relationships relationships)
        //{

        //    //note: access the attributes of the tuple using a numbered Item object
        //    var relations = relationships.Relations;
        //    foreach(var r in relations.Where(
        //        x => x.Item1.Name == "John" &&
        //        x.Item2 == Relationship.Parent
        //        ))
        //    {
        //        Console.WriteLine( $"John has a child called {r.Item3.Name}");
        //    }

        //}


        public static void RunResearch()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            //inject the dependency in the constuctor, pre-interface
            //new Research(relationships);
        }
    }
}
