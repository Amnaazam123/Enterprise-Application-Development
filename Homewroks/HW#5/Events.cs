using System;
using System.Collections;      //for ArrayList


namespace events2
{
    //aisa delegate jis se aisa event define kia jaye ga jis k argument me 2 parameters huwy
    delegate void eventHandler(object sender, EventArgs e);


    //publisher class
    class myArrayList : ArrayList
    {
        //define event
        public event eventHandler Added;

        //firing/raising event
        public void onAdded()
        {
            if (Added != null)
            {
                Added(this,new EventArgs());        //is event ko delegate ne btaya k tmey 2 parameters chahiye hony
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
            myArrayList list = new myArrayList();

            //assigning/registering event
            list.Added += delegate(object sender,EventArgs e)
            {
                Console.WriteLine(sender);
            };

            //calling event
            //list.onAdded();        => not right way
            //Actually you want to call this event when you add any item in list
            //simply call this function in Add(overrided function).

            list.Add(123);
        }
    }
}
