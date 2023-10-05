using System;

namespace Errors
{
    public class Zadacha
    {
        public int Id { get; set; }
        public string Nazvanie { get; set; }
        public string Opisanie { get; set; }
        public DateTime Sroki { get; set; }
        public string Status { get; set; }
        public int OtvetstvenniyPolzovatel { get; set; }

        public Zadacha(int id, string title, string description, DateTime deadline, string status, int assignedUserId)
        {
            Id = id;
            Nazvanie = title;
            Opisanie = description;
            Sroki = deadline;
            Status = status;
            OtvetstvenniyPolzovatel = assignedUserId;
        }
    }
}