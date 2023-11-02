using System;

namespace Delegates
{
    public class PhotoProcessor
    {
        //instead of: public delegate filterHandler PhotFilterHandler(Photophoto);

        //note there are two built-in generic delegates,  Func<> and Action<>. 
        //Func points to a method that returns a value, Action to a method that returns void

        //Here we are saying - accept as a paremet 'any method that takes Photo as a paremeter and returns void'
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }
}