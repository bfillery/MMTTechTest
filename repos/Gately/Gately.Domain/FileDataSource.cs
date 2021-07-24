using Gately.Domain.Interfaces;
using System.Data;
using System.IO;
using System.Linq;

namespace Gately.Domain
{
    public class FileDataSource :IDataSource
    {
        private string FileName { get; set; }

        private string DirectoryName { get; set; }

        

        public string FilePath { get; set; }

        public SourceName Source { get; set; }

        public FileDataSource(string directoryName, string fileName)
        {
            this.DirectoryName = directoryName;
            
            this.FileName = fileName;

            this.Source = SourceName.CsvFile;

            string ret = ValidateFile();

            if (ret != "")
                throw new InvalidDataException(ret);
        }

        private string ValidateFile()
        {
            string ret = "";

            try
            {
                if (this.DirectoryName.Substring(this.DirectoryName.Length - 1, 1) != @"\")
                    this.DirectoryName += @"\";

                this.FilePath = this.DirectoryName + this.FileName;

                if (!(File.Exists(FilePath)))
                    ret = "No such file";

                if (Path.GetExtension(FilePath) != ".csv")
                    ret = "Not a CSV file";
            }
            catch
            {
                throw new InvalidDataException("Unable to create and check filepath");
            }

            return ret;

        }


        //source: https://www.c-sharpcorner.com/blogs/read-csv-file-into-data-table1
        private DataTable ReadCsvFile(string filePath)
        {

            DataTable dtCsv = new DataTable();
            string Fulltext;

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    dtCsv.Columns.Add(rowValues[j]); //add headers  
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr); //add other rows  
                            }
                        }
                    }
                }
            }
            
            return dtCsv;
        }

        public DataTable GetDatatable()
        {
            return ReadCsvFile(this.FilePath);
        }


    }
}
