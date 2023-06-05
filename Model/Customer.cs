using System.ComponentModel.DataAnnotations;

namespace crudapi.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Length Must Be Between 3-20 CHAR")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Select One")]
        public string Gender { get; set; }
        [Display(Name ="Active")]
        public bool IsActive {  get; set; }
    }
}
