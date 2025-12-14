using TODO.Models;
using TODO.ViewModels;

namespace TODO.Mappers
{
    public class TodoMapper
    {
        public static Todo GetTodoFromTodoAddVM(TodoAddVM vm)
        {
            return new Todo
            {
                Libelle = vm.Libelle,
                Description = vm.Description,
                DateLimite = vm.DateLimite,
                Statut = vm.Statut
            };
        }
    }
}
