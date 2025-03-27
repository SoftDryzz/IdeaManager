using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManager.Models
{
    public enum IdeaStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class Idea
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public Priority Priority { get; set; }
        public IdeaStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Idea()
        {
            Tags = new List<string>();
            CreatedAt = DateTime.Now;
        }
    }
}
