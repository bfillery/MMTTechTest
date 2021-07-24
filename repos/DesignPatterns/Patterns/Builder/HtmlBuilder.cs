namespace DesignPatterns.Patterns.Builder
{
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            this.rootName = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);


            //fluent interface - return a reference to the object you're working with, 
            //so you can "chain" method calls together
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }
}
