using System.ComponentModel.DataAnnotations;

namespace ApiCrudClient.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(75)]
        public string FirstName { get; set; } = "";
        [StringLength(75)]
        public string LastName { get; set; } = "";
        [StringLength(50)]
        public string PhoneNo { get; set; } = "";
        [StringLength(75)]
        public string emailId { get; set; } = "";
    }

}
