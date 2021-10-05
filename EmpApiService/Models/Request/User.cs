using EmpApiService.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApiService.Models.Request
{
    [Table("Users", Schema = "Emp")]
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public UserRole Role { get; set; }
    }
}
