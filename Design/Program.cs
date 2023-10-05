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

            var task1 = new Task(1, "Task 1", "Description 1", DateTime.Now.AddDays(7), Status.OPEN, user1.Id);
            var task2 = new Task(2, "Task 2", "Description 2", DateTime.Now.AddDays(5), Status.OPEN, user2.Id);
            var task3 = new Task(2, "Task 3", "Description 3", DateTime.Now,
                Status.OPEN, user2.Id);
            taskController.AddTask(task1);
            taskController.AddTask(task2);
            taskController.AddTask(task3);

            taskController.AssignTask(task1.Id, user1.Id);

            taskController.AssignTask(task2.Id, user2.Id);

            taskController.AssignTask(task3.Id, user2.Id);

            taskController.CloseExpiredTasks();

            taskController.ChangeTaskStatus(task2.Id, Status.IN_PROGRESS);

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