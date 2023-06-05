using crudapi.Data;
using crudapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext Context;
        public CustomerController(CustomerContext context) { 
            this.Context = context;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var data=Context.customers.ToList();
            if (data.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var data = Context.customers.Where(e => e.Id == id).SingleOrDefault();
                if (data == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(data);
                }
            }
        }
        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var data = new Customer
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    IsActive = model.IsActive,
                };
                Context.customers.Add(data);
                Context.SaveChanges();
                return Ok("record inserted");
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
         public IActionResult UpdateCustomer([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var data=Context.customers.Where(e=>e.Id == model.Id).SingleOrDefault();
                if(data == null)
                {
                    return BadRequest();
                }
                else
                {
                    data.Name = model.Name;
                    data.Gender = model.Gender;
                    data.IsActive = model.IsActive;
                    Context.customers.Update(data);
                    Context.SaveChanges();
                    return Ok("record updated");
                }
               
            }
        }
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]

        public IActionResult DeleteCustomer(int id)
        {
            if (id != 0)
            {
                var data=Context.customers.Where(e=>e.Id==id).SingleOrDefault();
                if(data == null)
                {
                    return BadRequest();
                }
                else
                {
                    Context.customers.Remove(data);
                    Context.SaveChanges();
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok("record deleted");
        }
    }

    

}
