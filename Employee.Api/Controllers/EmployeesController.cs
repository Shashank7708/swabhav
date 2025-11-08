using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Api.Models;
using Newtonsoft.Json;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmpDbContext _context;

        public EmployeesController(EmpDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult> Getemployees()
        {
            var items= await _context.Employee_Master.ToListAsync();
            string json = JsonConvert.SerializeObject(items);
            return Ok(json);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDb>> GetEmployee(int id)
        {
            var employee = await _context.Employee_Master.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] EmployeeDb employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            var temp =await _context.Employee_Master.FindAsync(id);
            temp.FirstName=employee.FirstName;
            temp.LastName = employee.LastName;

            temp.EmailId = employee.EmailId;
            temp.ContactNo = employee.ContactNo;
            temp.City = employee.City;
            temp.Address = employee.Address;
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.SaveChangesAsync();
              //  await DummyAsyncMethod();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }

            return NoContent();
        }

        static async Task DummyAsyncMethod()
        {
            Console.WriteLine("Dummy async started");

            // Run CPU-bound code on a background thread
            await Task.Run(() =>
            {
                for (long i = 0; i < 10000333000; i++)
                {
                    // Simulate some CPU work
                    var temp = Math.Sqrt(i);
                }
            });

            Console.WriteLine("Dummy async finished");
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDb>> PostEmployee(EmployeeDb employee)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Employee_Master.AddAsync(employee);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok("Employee Created Successfully");
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest("Something went wrong");
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee =  _context.Employee_Master.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Employee_Master.Remove(employee);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                return BadRequest("Something went wrong");
            }

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee_Master.Any(e => e.EmployeeId == id);
        }
    }
}
