using System;
namespace BlogManagement.Data.Models
{
    /// <summary>
    /// Tabloların bulunduğu genel
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
