using System;
using System.Collections.Generic;
using CompatibleSoftware.BLL;
using CompatibleSoftware.BLL.Configuration;
using CompatibleSoftware.BLL.Tasks;

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
                        new TwitterConfigFileSettings(),
                        new GitHubConfigFileSettings())
                });
        

            taskRunner.RunTasks();

            Console.WriteLine("Done.");

            Console.ReadLine();
        }
    }
}
