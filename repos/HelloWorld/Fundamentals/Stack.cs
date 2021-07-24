using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class Stack
    {
        private ArrayList objects;

        public Stack()
        {
            objects = new ArrayList();

        }

        public ArrayList GetStack()
        {
            return objects;
        }


        public void Push(object obj)
        {

            if(obj == null)
                throw new InvalidOperationException("obj parameter cannot be null");

            objects.Add(obj);

            }

        public object Pop()
        {
            if (objects.Capacity == 0)
                throw new InvalidOperationException("There is nothing on the stack");

            var obj = objects[objects.Count - 1];

            objects.RemoveAt(objects.Count - 1);

            return obj;
        }

        public void Clear()
        {
            objects.Clear();
        }

    }


    
}
