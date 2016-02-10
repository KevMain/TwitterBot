using System;
using System.Collections.Generic;
using CompatibleSoftware.BLL;

namespace CompatibleSoftware.TwitterBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up...");
            
            var taskRunner = new TaskRunner(
                new List<ITask>
                {
                    new ReminderTask(
                        new Twitter(new TwitterConfigFileSettings()),
                        new GitHub(new GitHubConfigFileSettings()))
                });
        

            taskRunner.RunTasks();

            Console.WriteLine("Done.");

            Console.ReadLine();
        }
    }
}
