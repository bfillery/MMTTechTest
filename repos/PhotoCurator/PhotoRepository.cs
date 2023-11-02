using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoCurator
{
    public class PhotoRepository : IDisposable
    {

        private static List<Photo> Photos { get; set; }



        public PhotoRepository(string sourcePath, bool includeDateTaken, bool includeHashCode)
        {
            Photos = new List<Photo>();

            PopulatePhotos(sourcePath, includeDateTaken, includeHashCode);
        }




        private static void PopulatePhotos(string SourcePath, bool IncludeDateTaken, bool IncludeHashCode)
        {
            DirectoryInfo dInfo = new (SourcePath);
            Console.WriteLine("Searching {0} for images...", SourcePath);
            var files = FileHelper.GetFilesByExtensions(dInfo, InScopeFileTypes());
            
            int i = 0;


            Console.WriteLine("...{0} images found", files.Count());
            Console.WriteLine();

            string fileCount = files.Count().ToString();

            Size size = new Size(1000, 1000); //stanard height/width for hashng images

            foreach (FileInfo file in files)
            {
                string filePath = file.FullName;

                i++;

                Console.Write("\r{0}   ", "Adding to list: " + i.ToString() + " of " + fileCount + "...");

                    Photo photo = new
                    (
                        FilePath: filePath,
                        DateTaken: IncludeDateTaken == true ? GetDateTakenFromImage(filePath) : file.LastWriteTime,
                        HashCode: IncludeHashCode == true ? ImageHash.GetHash(ResizeImage(filePath, size) : string.Empty,
                        DateCreated: file.CreationTime,
                        DateModified: file.LastWriteTime
                    ) ;

                //photo.HashCode = ImageHash.GetHash(filePath);

                Photos.Add(photo);
            }
            Console.WriteLine("...done.");
        }


       


        //https://stackoverflow.com/questions/180030/how-can-i-find-out-when-a-picture-was-actually-taken-in-c-sharp-running-on-vista
        //https://stackoverflow.com/questions/14308284/date-taken-not-showing-up-in-image-propertyitems-while-it-shows-in-file-detail
        private static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
                try
                {
                    //Console.WriteLine("Getting new filename for {0}", path);

                    using (Image myImage = Image.FromStream(fs, false, false))

                    {
                        PropertyItem propItem = null;

                        if (myImage.PropertyIdList.Any(x => x == 36867))
                        {
                            propItem = myImage.GetPropertyItem(36867);
                        }

                        if (propItem != null)
                        {
                            //string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-",StringComparison.InvariantCulture);

                            string dateTaken = Encoding.UTF8.GetString(propItem.Value, 0, propItem.Len - 1);

                            //// Parse the date and time. 
                            return DateTime.ParseExact(dateTaken, "yyyy:MM:d H:m:s", CultureInfo.InvariantCulture);

                        }
                        else
                            return DateTime.Now;
                    }
                }
                catch
                {
                    return DateTime.Now;
                }
        }






        public static string[] InScopeFileTypes()
        {
            return new string[4] { ".JPEG", ".JPG", ".PNG", ".BMP" };
        }


        public List<Photo> GetPhotos()
        {
            return Photos;
        }


        public static Image ResizeImage(string filePath, Size size)
        {
            using Image image = Image.FromFile(filePath);
            return ResizeImage(image, size);

        }
        public static Image ResizeImage(Image imgToResize, Size size)
        {

            //https://www.c-sharpcorner.com/UploadFile/ishbandhu2009/resize-an-image-in-C-Sharp/#:~:text=To%20resize%20an%20image%20in%20ASP.Net%2FC%23%20we%20will,desired%20format%20I%20used%20the%20method%20given%20below%3A
            //Image i = ResizeImage(b, new Size(100, 100));


            //Get the image current width  
            int sourceWidth = imgToResize.Width;

            //Get the image current height  
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);

            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        //public int x()
        //{
        //    List<bool> iHash1 = GetHash(new Bitmap(@"C:\mykoala1.jpg"));
        //    List<bool> iHash2 = GetHash(new Bitmap(@"C:\mykoala2.jpg"));

        //    //determine the number of equal pixel (x of 256)
        //    return iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);

            
        //}

        public void Dispose()
        {
            //throw new NotImplementedException();

            Photos = null;
        }
    }
}
