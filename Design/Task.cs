using System;

namespace Design
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Status Status { get; set; }
        public int AssignedUserId { get; set; }

        public Task(int id, string title, string description, DateTime deadline, Status status, int assignedUserId)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Status = status;
            AssignedUserId = assignedUserId;
        }
    }
}