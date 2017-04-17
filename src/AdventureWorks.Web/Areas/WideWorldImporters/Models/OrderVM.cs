using System;

namespace AdventureWorks.Web.Areas.WideWorldImporters.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public CustomerVM Customer { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
