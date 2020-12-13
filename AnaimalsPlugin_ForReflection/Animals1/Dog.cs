using BabyStroller.sdk;
using System;

namespace AnaimalsPlugin_ForReflection
{
    public class Dog : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Woof!");
            }
        }
    }
}
