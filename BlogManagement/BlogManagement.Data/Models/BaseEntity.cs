using System;
namespace BlogManagement.Data.Models
{
    /// <summary>
    /// Tablolar bu entity üzerinde türüyor
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
