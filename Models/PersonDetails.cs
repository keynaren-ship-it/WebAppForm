using System.ComponentModel.DataAnnotations;

namespace WebAppForm.Models;

public class PersonDetails
{
    [Required, StringLength(100)]
    [Display(Name = "First name")]
    public string FirstName { get; set; } = "";

    [Required, StringLength(100)]
    [Display(Name = "Last name")]
    public string LastName { get; set; } = "";

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of birth")]
    public DateTime? DOB { get; set; }

    [Required, StringLength(200)]
    public string Location { get; set; } = "";
}
