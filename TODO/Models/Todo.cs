using System.ComponentModel.DataAnnotations;
using TODO.Enums;
using TODO.ViewModels;

namespace TODO.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State Statut { get; set; }
    }
}
