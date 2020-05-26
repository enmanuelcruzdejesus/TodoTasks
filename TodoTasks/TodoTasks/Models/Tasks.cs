using System;
using System.ComponentModel.DataAnnotations;

namespace TodoTasks.Models
{
    public class Tasks
    {
        [Key]

        public int taskid { get; set; }
        public string taskname { get; set; }
        public Boolean completed { get; set; }
        public DateTime created { get; set; }
        public Tasks()
        {
        }
    }
}
