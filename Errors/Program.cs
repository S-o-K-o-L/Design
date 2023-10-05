using System;
using System.Collections.Generic;
using System.Linq;

namespace Errors
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Zadacha> zadachi = new List<Zadacha>();
            var user1 = new Polzovatel { Id = 1, KakZovut = "User 1" };
            var user2 = new Polzovatel { Id = 2, KakZovut = "User 2" };

            var task1 = new Zadacha(1, "Task 1", "Description 1", DateTime.Now.AddDays(7), "OPEN", user1.Id);
            var task2 = new Zadacha(2, "Task 2", "Description 2", DateTime.Now.AddDays(5), "OPEN", user2.Id);
            var task3 = new Zadacha(3, "Task 3", "Description 3", DateTime.Now, "OPEN", user2.Id);
            zadachi.Add(task1);
            zadachi.Add(task2);
            zadachi.Add(task3);
            

            var zadacha1 = zadachi.Find(t => t.Id == 1);
            if (zadacha1 != null)
            {
                zadacha1.OtvetstvenniyPolzovatel = 1;
            }

            var zadacha2 = zadachi.Find(t => t.Id == 2);
            if (zadacha2 != null)
            {
                zadacha2.OtvetstvenniyPolzovatel = 2;
            }
            
            var zadacha3 = zadachi.Find(t => t.Id == 3);
            if (zadacha2 != null)
            {
                zadacha2.OtvetstvenniyPolzovatel = 2;
            }

            var now = DateTime.Now;
            var expiredTasks = zadachi.Where(t => t.Status == "OPEN" && t.Sroki < now).ToList();
            foreach (var task in expiredTasks)
            {
                task.Status = "Closed (Expired)";
            }

            var task12 = zadachi.Find(t => t.Id == 1);
            if (task12 != null)
            {
                task12.Status = "In progress";
            }

            var user1Tasks = zadachi.FindAll(t => t.OtvetstvenniyPolzovatel == 1);
            var user2Tasks = zadachi.FindAll(t => t.OtvetstvenniyPolzovatel == 2);

            Console.WriteLine("Tasks assigned to User 1:");
            foreach (var task in user1Tasks)
            {
                Console.WriteLine($"Task {task.Id}: {task.Nazvanie}, Status: {task.Status}");
            }

            Console.WriteLine("\nTasks assigned to User 2:");
            foreach (var task in user2Tasks)
            {
                Console.WriteLine($"Task {task.Id}: {task.Nazvanie}, Status: {task.Status}");
            }
        }
    }
}