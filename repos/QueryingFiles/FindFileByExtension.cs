using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-query-for-files-with-a-specified-attribute-or-name

namespace QueryingFiles
{
    public class FindFileByExtension
    {


        // This query will produce the full path for all .txt files  
        // under the specified folder including subfolders.  
        // It orders the list according to the file name.  
        public static void Search(string startFolder = @"C:\Users\Bruce\Desktop\", string fileExt = ".txt")
        {

            // Take a snapshot of the file system.  
            DirectoryInfo dir = new DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions  
            // for all folders under the specified path.  
            IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

            //Create the query  
            IEnumerable<FileInfo> fileQuery =
                from file in fileList
                where file.Extension == fileExt
                orderby file.Name
                select file;

            ////Execute the query. This might write out a lot of files!  
            //foreach (FileInfo fi in fileQuery)
            //{
            //    Console.WriteLine(fi.FullName);
            //}

            // Create and execute a new query by using the previous
            // query as a starting point. fileQuery is not
            // executed again until the call to Last()  
            var newestFile =
                (from file in fileQuery
                 orderby file.CreationTime descending
                 select new { file.FullName, file.CreationTime })
                .Last();

            Console.WriteLine($"\r\nThe oldest {nameof(fileExt)} file is {Path.GetFileName(newestFile.FullName)}. Creation time: {newestFile.CreationTime}");

            Console.ReadKey();
        }
    }
}
