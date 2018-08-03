using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly Context _context;

        public CostumerController(Context context)
        {
            _context = context;

            if (_context.costumers.Count() == 0)
            {
                _context.costumers.Add(new Costumer { Name = "Tugba ", LastName = "bıçakcı" });
                _context.costumers.Add(new Costumer { Name = "Tugba2 ", LastName = "bıçakcı" });
                _context.costumers.Add(new Costumer { Name = "Tugba3 ", LastName = "bıçakcı" });


                _context.SaveChanges();
            }
        }


        [HttpGet]
        public ActionResult<List<Costumer>> GetAll()
        {
            return _context.costumers.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<Costumer> GetById(long id)
        {
            var item = _context.costumers.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Costumer item)
        {
            _context.costumers.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Costumer item)
        {
            var todo = _context.costumers.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.LastName = item.LastName;
            todo.Name = item.Name;

            _context.costumers.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.costumers.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.costumers.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
