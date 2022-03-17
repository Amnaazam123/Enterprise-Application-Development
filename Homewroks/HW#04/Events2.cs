/*Class activity - register your event defined in class button with any function defined in any other class*/

using System;

namespace Events
{
    delegate void myEventHandler();

    class myClass
    {
        public void myFun()
        {
            Console.WriteLine("Hello");
        }
    }

    //publisher class
    class Button
    {
        public event myEventHandler myevent;        //define event (publically)
        
        public void onClick()
        {
            if (myevent != null)   //means if i have assigned any action against my event
            {
                Console.WriteLine("EVENT FIRED...");
                myevent();             //firing event
            }
        }
    }

    class Program
    {   
        static void Main(string[] args)
        {
            Button b1 = new Button();
            
            //what you are TO DO against event, register your event here.
            b1.myevent += () =>
            {
                Console.WriteLine("I am event being assigned here.");
            };
            myClass c1 = new myClass();
            b1.myevent += () =>                    //lamda function
            {
                c1.myFun();
            };
            b1.myevent += delegate                  //anonymous function
            {
                c1.myFun();
            };


            b1.onClick();     //calling the event
        }
    }
}
