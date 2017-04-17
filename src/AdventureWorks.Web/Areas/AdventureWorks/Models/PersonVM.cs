namespace AdventureWorks.Web.Areas.AdventureWorks.Models
{
    public class PersonVM : BusinessEntityVM
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
    }
}
