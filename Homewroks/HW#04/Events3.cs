/*Class activity - Make a class inherited from ArrayList and override its add functionality with event firing */

using System;
using System.Collections;        //import for ArrayList

namespace Events
{
    delegate void myEventHandler();

    //publisher class
    class myArrayList : ArrayList
    {
        public event myEventHandler added;         //event defined

        //event firing
        public override int Add(object value)
        {
            if (added != null)
            {
                added();           //event firing
            }
            return base.Add(value);
        }

    }


    class Program
    {   
        static void Main(string[] args)
        {
            myArrayList list = new myArrayList();

            //registering event
            list.added += () =>
            {
                Console.WriteLine("Event called automatically");
            };


            list.Add(12);          //calling of event
            list.Add(34);          //calling of event
        }
    }
}
