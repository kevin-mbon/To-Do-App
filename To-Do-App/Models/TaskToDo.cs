using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace To_Do_App.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }
         public string Task { get; set; } 
        public string Description { get; set ; }
      
        public DateTime? StartingTime { get; set; } = null!;
        public DateTime? EndingTime { get; set; } = null!;
        public TaskToDo()
        {
            StartingTime = DateTime.Now;
            EndingTime = DateTime.Now;  
        }


    }
}
