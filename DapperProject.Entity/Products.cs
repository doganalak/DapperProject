using Dapper.Contrib.Extensions;
using System;

namespace DapperProject.Entity
{
    [Table("Product")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
