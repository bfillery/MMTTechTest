namespace QueryingFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            //FindFileByExtension.Search();


            var pm = new PeopleManager();
            PeoplePersistence.LoadFromFile(pm.GetPeople(),@"C:\Users\Bruce\Desktop\People.txt");

            var pmF = new PeopleManager();


            foreach (var p in new PeopleFilter().Filter(
                                                            pm.GetPeople(), 
                                                            new AgeSpecification(40, 150)
                                                        ))
            {
                
                pmF.AddPerson(p);
            }
            PeoplePersistence.SaveToFile(pmF.GetPeople(), @"C:\Users\Bruce\Desktop\SoylentCandidates.txt");
        }
    }
}
