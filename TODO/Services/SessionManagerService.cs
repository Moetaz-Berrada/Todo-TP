using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using TODO.Models;

namespace TODO.Services
{
    public class SessionManagerService : ISessionManagerService
    {
        public void Add(string key ,object obj,HttpContext context)
        {
            string chaine = JsonSerializer.Serialize(obj);
            context.Session.SetString(key, chaine);
        }

        public T Get<T>(string key, HttpContext context)
        {
            return JsonSerializer.Deserialize<T>(context.Session.GetString(key) ?? "[]");
        }
    }
}
