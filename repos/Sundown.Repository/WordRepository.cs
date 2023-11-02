using Sundown.Domain;
using Sundown.Domain.Interfaces;
using Sundown.Repository.Interfaces;
using System;

namespace Sundown.Repository
{
    public class WordFileRepository : IRepository
    {
        private SourceName NameOfResource { get; set; }
        private string connstring { get; set; }

        private string wordtoCheck { get; set; }

        public WordFileRepository(IWordSource wordsource)
        {
            NameOfResource = wordsource.sourceName;
            connstring = wordsource.SourceConnection;
        }

        public bool? IsWordInDictionary(string WordToTest)
        {
            wordtoCheck = WordToTest;
            if(NameOfResource == SourceName.DB)
            {
                
                return ReturnWordFromDatabase();
            }
            else
            {
                return ReturnWordFromFileList();
            }
        }

        private bool? ReturnWordFromDatabase()
        {
            //connect to DB etc
            throw new NotImplementedException();
        }

        private bool? ReturnWordFromFileList()
        {
            // search using file
            throw new NotImplementedException();
        }


    }
}
