using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
   public class PersonaModel
    {
       public PersonaType PersonaType { get; set; }
    }

    public enum PersonaType
    {
        [Display(Name = "Other Types")] 
        OTHERS
    }
}
