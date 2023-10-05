using System;

namespace Design
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var taskController = new TaskController();
            var user1 = new User { Id = 1, Name = "User 1" };
            var user2 = new User { Id = 2, Name = "User 2" };

            taskController.CreateTask("Task 1", "Description 1", DateTime.Now.AddDays(7), user1.Id);
            taskController.CreateTask("Task 2", "Description 2", DateTime.Now.AddDays(5), user2.Id);

            taskController.AssignTask(1, user2.Id);

            taskController.CloseExpiredTasks();

            taskController.ChangeTaskStatus(2, "In Progress");

            var user1Tasks = taskController.GetTasksByUserId(user1.Id);
            var user2Tasks = taskController.GetTasksByUserId(user2.Id);

            Console.WriteLine("Tasks assigned to User 1:");
            foreach (var task in user1Tasks)
            {
                Console.WriteLine($"Task {task.Id}: {task.Title}, Status: {task.Status}");
            }

            Console.WriteLine("\nTasks assigned to User 2:");
            foreach (var task in user2Tasks)
            {
                Console.WriteLine($"Task {task.Id}: {task.Title}, Status: {task.Status}");
            }
        }
    }
}