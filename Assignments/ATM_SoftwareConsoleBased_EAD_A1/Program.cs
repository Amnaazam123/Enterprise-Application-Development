/*
 * 1 - This is console based ATM Application with 2 users in N-Tier Architecture.
 * 
 * ------------------------------------  BSEF19M009-AMNA AZAM  ----------------------------
 */


using System;
using PresentationLayer;
namespace EAD_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            presentaionLayerClass PL = new presentaionLayerClass();
            PL._interface();
        }
    }
}
