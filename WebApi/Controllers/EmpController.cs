using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpController : ControllerBase
	{

		private readonly ApplicationDbContext db;

		public EmpController(ApplicationDbContext db)
		{
			this.db = db;
		}

		[Route("AddEmp")]
		[HttpPost]
		public IActionResult AddEmp(Emp e)
		{
			db.Emp.Add(e);
			db.SaveChanges();
			return Ok("Emp Added Successfully !!");

		}
        [Route("AddEmpMul")]
        [HttpPost]
        public IActionResult AddEmpMul(List<Emp> e)
        {
			foreach (Emp emp in e)
			{
                db.Emp.Add(emp);
                db.SaveChanges();
            }
            
            return Ok("Emp Added Successfully !!");

        }

        [Route("GetEmp")]
		[HttpGet]
		public IActionResult GetEmp() 
		{
			var data = db.Emp.ToList();
			return Ok(data);

		}
		[Route("DeleteEmp/{id}")]
		[HttpDelete]
		public IActionResult DeleteEmp(int id ) 
		{
			 var data = db.Emp.Find(id);
			  db.Emp.Remove(data);
			db.SaveChanges();
			return Ok("Emp Deleted Successfully");
		}

		[Route("DeleteEmpMul")]
		[HttpDelete]
		public IActionResult DeleteEmpMul(List<int> id ) 
		{

			
			 var data = db.Emp.Where(x=>id.Contains(x.Id)).ToList();
			  db.Emp.RemoveRange(data);
			db.SaveChanges();
			
			return Ok("Emp Deleted Successfully");
		}
	}
}
