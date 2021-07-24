using System.Collections.Generic;

namespace DesignPatterns.Principles.DependencyInversion.Interfaces
{
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
        

        
    }
}
