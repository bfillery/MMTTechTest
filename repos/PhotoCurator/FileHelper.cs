using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoCurator
{
    //https://stackoverflow.com/questions/3527203/getfiles-with-multiple-extensions
    public static class FileHelper
    {
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");

            IEnumerable<FileInfo> files = dir.EnumerateFiles("*.*", SearchOption.AllDirectories);
            //return files.Where(f => extensions.Contains(f.Extension));
            return files.Where(f => extensions.Contains(f.Extension, StringComparer.OrdinalIgnoreCase));
        }

    }
}
