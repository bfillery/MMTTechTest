namespace DesignPatterns.Patterns.Builder
{
    public class Person
    {
        public string Name;
        public string Position;


        //public Person(string name, string position)
        //{
        //    Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        //    Position = position ?? throw new ArgumentNullException(paramName: nameof(position));
        //}

        public class Builder : PersonJobBuilder<Builder>
        {
            
        }

        public static Builder New =>new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }




    }
}
