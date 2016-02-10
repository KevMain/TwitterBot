using System.Collections.Generic;

namespace CompatibleSoftware.BLL
{
    public class TaskRunner
    {
        private readonly IList<ITask> _tasks;

        public TaskRunner()
        {
            _tasks = new List<ITask> {new ReminderTask(new Twitter(), new GitHub())};
        }

        public void RunTasks()
        {
            foreach (var task in _tasks)
            {
                task.Perform();
            }
        }
    }
}
