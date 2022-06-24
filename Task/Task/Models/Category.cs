using System;
using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool ShowInWebsite { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long CategoryLogo { get; set; }
    }
}
