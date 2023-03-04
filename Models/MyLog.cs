using WebApplication9.Models.Abstraction;

namespace WebApplication9.Models
{
    public sealed class MyLog : Entity
    {        
        public string Progress { get; set; }
        public DateTime CreadtedDate { get; set; } = DateTime.Now;
        public string Data { get; set; }
        public string UserId { get; set; }
    }
}
