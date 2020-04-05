using System;
namespace BlogManagement.Data.Models
{
    public class ApiVersionEntity : BaseEntity
    {
        public string VersionName { get; set; }
        public string VersionDetail { get; set; }
    }
}
