/*
 ~ class Activity - Maintain the count of list whenever you add any item in list
*/

using System;
using System.Collections;      //for ArrayList


namespace events2
{
    //This is a simple class maintained for count of list.
    class myCountClass
    {
        public int count { get; set; }
    }


    //aisa delegate jis se aisa event define kia jaye ga jis k argument me 2 parameters(sender, countInfoVariable) huwy
    delegate void eventHandlerr(object sender, myCountClass e);

    //publisher class
    class myList : ArrayList
    {
        //define event
        public event eventHandlerr Added;

        //it would be initialized once bcz myList class has one object in main. 
        private int c = 1;
        
        //firing/raising event
        public void onAdded()
        {

            if (Added != null)
            {
                //event requires 2 args here.
                myCountClass e = new myCountClass();
                e.count = c++;
                Added(this, e);         //is event ko delegate ne btaya k tmey 2 parameters chahiye hony
            }
        }

        //myArrayList ne Add k function ko override hony dia qk ye inherited tha ArrayList se aur event b isi ki class me define tha
        public override int Add(object value)
        {
            onAdded();
            return base.Add(value);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            myList list = new myList();
            list.Added += delegate (object sender, myCountClass e)
            {
                Console.WriteLine("Count : " + e.count);
            };
            list.Add(12);
            list.Add(123);
            list.Add("AMNA");
            list.Add("hehehe");
            list.Add('A');
            list.Add(0.9999);
        }
    }
}
