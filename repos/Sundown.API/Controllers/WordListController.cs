using Sundown.Domain;
using Sundown.Domain.Interfaces;
using Sundown.Repository;
using System.Web.Http;


namespace Sundown.API.Controllers
{
    public class WordListController : ApiController
    {
        [HttpGet]
        [ActionName("Default")]

        public string Get()
        {
            return "Hello world";
        }

        [HttpGet]
        public string Get(string word)
        {
            IWordSource wordSource = new FileWordSource(@"C:\Temp\dictionary.csv");
            IWordSource wordsourceDB = new DBWordSource(@"Data Source = Servername; Initial Catalog = DBName; Integrated Security = True; MultipleActiveResultsSets = True");

            WordFileRepository rep = new WordFileRepository(wordsourceDB);

            return rep.IsWordInDictionary(word).ToString();
        
        }
    }
}
