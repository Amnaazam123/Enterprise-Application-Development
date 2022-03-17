/*
- delegates are used for events..
- publisher class define event and fire event.
- to define the event, we use delegate.
- if we are to register event, we assign the function against event in main. 
 
 */

using System;

namespace Events
{
    delegate void myEventHandler();        
    

    //publisher class
    class Button
    {
        public event myEventHandler myevent;        //define event
        
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

            b1.onClick();     //calling the event
        }
    }
}
