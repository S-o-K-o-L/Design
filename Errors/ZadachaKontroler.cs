using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Errors
{
    public class ZadachaKontroler
    {
        private List<Zadacha> zadachi = new List<Zadacha>();
        private int zadachaIdCounter = 1;

        public void AddZadacha(Zadacha newTask)
        {
            zadachi.Add(newTask);
        }

        public void AssignZadacha(int taskId, int userId)
        {
            var zadacha = zadachi.Find(t => t.Id == taskId);
            if (zadacha != null)
            {
                zadacha.OtvetstvenniyPolzovatel = userId;
            }
        }

        public List<Zadacha> GetTasksByUserId(int userId)
        {
            return zadachi.FindAll(t => t.OtvetstvenniyPolzovatel == userId);
        }

        public void PomenyaiStatusZadachi(int taskId, string newStatus)
        {
            var task = zadachi.Find(t => t.Id == taskId);
            if (task != null)
            {
                task.Status = newStatus;
            }
        }

        public void CloseVishedshiiSrokZadacha()
        {
            var now = DateTime.Now;
            var expiredTasks = zadachi.Where(t => t.Status == "Open" && t.Sroki < now).ToList();
            foreach (var task in expiredTasks)
            {
                task.Status = "Closed (Expired)";
            }
        }
    }
}