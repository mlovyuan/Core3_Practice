using BabyStroller.sdk;
using System;

namespace Animals2
{
    public class Sheep : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Baa!");
            }
        }
    }
}
