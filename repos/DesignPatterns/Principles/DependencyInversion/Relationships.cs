using DesignPatterns.Principles.DependencyInversion.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Principles.DependencyInversion
{
    //low level

    //Now that Relationship implements an interface rather than exposing 
    //the data store, it can change teh data store without affecting anything
    //that consumes this class.
    public class Relationships :IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations
            = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(
                x => x.Item1.Name ==  name &&
                x.Item2 == Relationship.Parent
                ).Select (r =>r.Item3);
            
        }

        //one way to expose the lower level stuff to a higher level class. 
        //Naughty, but: inject the dependency in the Research constructor 
        //and make the relations list have a public getter
        //This means the Relationships class can't change to e.g. use a 
        //dictionary instead of tuples

        //public List<(Person, Relationship, Person)> Relations => relations;
    }
}
