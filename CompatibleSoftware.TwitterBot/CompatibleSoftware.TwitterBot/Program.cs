using System;
using CompatibleSoftware.BLL;

namespace CompatibleSoftware.TwitterBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up...");

            var taskRunner = new TaskRunner();

            taskRunner.RunTasks();

            Console.WriteLine("Done.");

            Console.ReadLine();
        }
    }
}
