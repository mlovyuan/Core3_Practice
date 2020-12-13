using BabyStroller.sdk;
using System;

namespace AnaimalsPlugin_ForReflection
{
    public class Cat : IAnimal
    {
        public void Voice(int times)
        {
            for(int i = 0; i < times; i++)
            {
                Console.WriteLine("Meow!");
            }
        }
    }
}
