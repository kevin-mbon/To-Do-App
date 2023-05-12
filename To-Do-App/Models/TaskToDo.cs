namespace To_Do_App.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public string PartnerOnThis { get; set; }

        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public TaskToDo()
        {
            
        }
    }
}
