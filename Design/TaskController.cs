using System;
using System.Collections.Generic;
using System.Linq;

namespace Design
{
    public class TaskController
    {
        private List<Task> tasks = new List<Task>();
        private int taskIdCounter = 1;

        public void AddTask(Task newTask)
        {
            tasks.Add(newTask);
        }

        public void AssignTask(int taskId, int userId)
        {
            var task = tasks.Find(t => t.Id == taskId);
            if (task != null)
            {
                task.AssignedUserId = userId;
            }
        }

        public List<Task> GetTasksByUserId(int userId)
        {
            return tasks.FindAll(t => t.AssignedUserId == userId);
        }

        public void ChangeTaskStatus(int taskId, Status newStatus)
        {
            var task = tasks.Find(t => t.Id == taskId);
            if (task != null)
            {
                task.Status = newStatus;
            }
        }

        public void CloseExpiredTasks()
        {
            var now = DateTime.Now;
            var expiredTasks = tasks.Where(t => t.Status == Status.OPEN && t.Deadline < now).ToList();
            foreach (var task in expiredTasks)
            {
                task.Status = Status.CLOSE;
            }
        }
    }
}