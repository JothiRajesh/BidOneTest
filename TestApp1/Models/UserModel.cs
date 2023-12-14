using System.ComponentModel.DataAnnotations;

namespace TestApp1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        [Display(Name="Last Name")]
        public required string LastName { get; set; }
    }
}
