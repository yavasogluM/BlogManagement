using System;
namespace BlogManagement.Data.Models
{
    public class LogEntity : BaseEntity
    {
        public string LogTitle { get; set; }
        public string LogText { get; set; }
    }
}
