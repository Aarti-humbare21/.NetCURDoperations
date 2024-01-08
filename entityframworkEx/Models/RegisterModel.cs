using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityframworkEx.Models
{
    [Table("tbl_Student")]
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string password { get; set; }
        public byte Age { get; set; }
        public DateTime Dob { get; set; }
        public decimal Fee { get; set; }
        public string Dept { get; set; }
        public bool status { get; set; }
        public string role { get; set; }
    }
    public class t1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
public class LoginModel
{
    public string EmailID { get; set; }
    public string password { get; set; }
}

