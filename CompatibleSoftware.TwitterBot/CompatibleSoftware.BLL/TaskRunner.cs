using System.Collections.Generic;

namespace CompatibleSoftware.BLL
{
    public class TaskRunner
    {
        private readonly IList<ITask> _tasks;

        public TaskRunner(IList<ITask> tasks)
        {
            _tasks = tasks;
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
