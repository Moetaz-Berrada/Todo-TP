using System.ComponentModel.DataAnnotations;
using TODO.Enums;

namespace TODO.ViewModels
{
    public class TodoAddVM
    {
        [Required(ErrorMessage = "Le libelle est obligatoire !")]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [Required]
        public State Statut { get; set; }
    }
}
