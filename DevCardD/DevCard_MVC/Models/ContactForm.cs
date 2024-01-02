using System.ComponentModel.DataAnnotations;

namespace DevCard_MVC.Models

{
    public class ContactForm
    {
        [Required(ErrorMessage = " I don`t give a fuck about your name but this fucking field is requierd and you gotta fucking fill it in Nigga! ")]
        [MinLength(2 , ErrorMessage =" Minimum 3 chars! ")]
        [MaxLength(255 , ErrorMessage = " Maximum 255 chars! ")]
        public string Name { get; set; }
        [Required(ErrorMessage = " This field is necerssary! fill it in u nuty dam sht! ")]
        [EmailAddress  (ErrorMessage = "This ain`t right Email! ")]
        public string Email { get; set; }
        public string Message { get; set; }
        public string Service { get; set; }
    }
}
 