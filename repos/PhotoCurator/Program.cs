using System;
using System.Collections.Generic;
using System.IO;

namespace PhotoCurator
{


    public class Program
    {


        static void Main(string[] args)
        {
            //string SourcePath = @"\\NASE8C623\homes\admin";
            string SourcePath = @"\\NASE8C623\homes\admin\Consolidated\test";
            //string SourcePath = @"\\NASE8C623\homes\admin\Owen and Lynne wedding";
            //string TargetPath = @"\\NASE8C623\homes\admin\Consolidated";

            //MoveImages (SourcePath, TargetPath);
            List<Photo> photos = new();
            
            using PhotoRepository photoRepo = new(sourcePath: SourcePath, includeDateTaken: false, includeHashCode: true);

            photos = photoRepo.GetPhotos();
            foreach(Photo photo in photos)
            {
                Console.WriteLine("File: {0}, Hash: {1}", photo.FileName, photo.HashCode);
            }

            Console.WriteLine("...done.");
        }

        static bool MoveImages(string sourcePath, string targetPath)
        {
            int i = 0;
            List<Photo> photos = new();

            using PhotoRepository photoRepo = new(sourcePath: sourcePath, includeDateTaken: true, includeHashCode: false);

            photos = photoRepo.GetPhotos();

            foreach (Photo photo in photos)
            {
                i++;
                string source = photo.FilePath + "\\" + photo.FileName;

                string extension = Path.GetExtension(photo.FileName);
                string fileName = Path.GetFileNameWithoutExtension(photo.NewFileName);

                string target = targetPath + "\\" + fileName + extension;

                int suffix = 0;

                string photoCount = photos.Count.ToString();

                if (File.Exists(target))
                    do
                    {
                        suffix++;
                        target = targetPath + "\\" + fileName + "_" + suffix.ToString("00") + extension;

                    } while (File.Exists(target));

                Console.Write("\r{0}   ", "Moving: " + i.ToString() + " of " + photoCount + "...");


                File.Move(source, target);
            }
            Console.WriteLine("");
            return true;
        }




    }
}

