using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TODO.Filters;
using TODO.Mappers;
using TODO.Models;
using TODO.Services;
using TODO.ViewModels;

namespace TODO.Controllers
{
    [LoginFilter]
    [ThemeFilter]
    public class TodoController : Controller 
    {
        ISessionManagerService session;

        public TodoController(ISessionManagerService session)
        {
            this.session = session;
        }
        public IActionResult Index()
        {
            List<Todo> list = session.Get<List<Todo>>("todo",HttpContext) ?? new List<Todo>();
            ViewBag.count = list.Count;
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TodoAddVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            List<Todo> list;
            if (HttpContext.Session.GetString("todo") == null)
            {
                list = new List<Todo>();
            }
            else
            {
                list = session.Get<List<Todo>>("todo", HttpContext);
            }
          
            Todo todo = TodoMapper.GetTodoFromTodoAddVM(vm);
            list.Add(todo);

            
            session.Add("todo", list, HttpContext);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            List<Todo> list = session.Get<List<Todo>>("todo", HttpContext) ?? new List<Todo>();

            if (id < 0 || id >= list.Count)
            {
                return RedirectToAction(nameof(Index));
            }

            var todo = list[id];
            var vm = new TodoEditVM
            {
                Libelle = todo.Libelle,
                Description = todo.Description,
                DateLimite = todo.DateLimite,
                Statut = todo.Statut
            };

            ViewBag.Id = id;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, TodoEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;
                return View();
            }

            List<Todo> list = session.Get<List<Todo>>("todo", HttpContext) ?? new List<Todo>();

            if (id < 0 || id >= list.Count)
            {
                return RedirectToAction(nameof(Index));
            }

            list[id].Libelle = vm.Libelle;
            list[id].Description = vm.Description;
            list[id].DateLimite = vm.DateLimite;
            list[id].Statut = vm.Statut;

            session.Add("todo", list, HttpContext);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            List<Todo> list = session.Get<List<Todo>>("todo", HttpContext) ?? new List<Todo>();

            if (id >= 0 && id < list.Count)
            {
                list.RemoveAt(id);
                session.Add("todo", list, HttpContext);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
