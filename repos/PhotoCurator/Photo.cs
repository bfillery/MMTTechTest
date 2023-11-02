using System;
using System.IO;

namespace PhotoCurator
{
    public class Photo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public string NewFileName { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Photo(string FilePath, string HashCode,
                DateTime? DateTaken, DateTime? DateCreated, DateTime? DateModified)
        {

            if (FilePath != null)
            {
                this.FilePath = Path.GetDirectoryName( FilePath);              
                this.FileName = Path.GetFileName(FilePath);
                
            }

            this.HashCode = HashCode;

            //date taken will thus be the minimum of these three dates and now
            this.DateModified = DateModified.GetValueOrDefault(DateTime.Now);
            this.DateCreated = DateCreated.GetValueOrDefault(this.DateModified);
            this.DateTaken = DateTaken.GetValueOrDefault(this.DateCreated);

            this.NewFileName = GetNewFileName();

        }


        public string HashCode { get; set; }

        //get a new unique filename based on image attributes
        private string GetNewFileName()
        {
            
            string ret = DateTaken.ToString("yyyy-MM-dd hhmmss");

            if (FileName != null)
                ret += Path.GetExtension(FileName);
            
            return ret;

        }

    }
}
