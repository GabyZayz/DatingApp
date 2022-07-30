using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            return await _context.Users.ToListAsync();;
        }

            //api/users/3
         [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int Id ){

            return  await _context.Users.FindAsync(Id);;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(AppUser user){
        
            _context.Users.Add(user);
           await _context.SaveChangesAsync();
           return Ok();
        }       
    }
}