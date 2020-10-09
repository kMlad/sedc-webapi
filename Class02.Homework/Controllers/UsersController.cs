using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Class01.Homework.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Class01.Homework.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.usersList);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if(id<0 || id>=StaticDb.usersList.Count)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "There is no such user! Enter a valid ID!");
            }
            return StatusCode(StatusCodes.Status200OK, StaticDb.usersList[id]);
        }

        [HttpPost]
        public ActionResult<string> Post()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string body = reader.ReadToEnd();
                    
                    StaticDb.usersList.Add(body);
                    return StatusCode(StatusCodes.Status201Created, $"The Username {body} was succesfully added to the list");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error!");
            }

                
        }

        [HttpDelete] 
        public IActionResult Delete()
        {
            try
            {
                using(StreamReader reader = new StreamReader(Request.Body))
                {
                    string num = reader.ReadToEnd();
                    int id = Int32.Parse(num);
                    if(id<0 || id>=StaticDb.usersList.Count)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "No such username exists!");
                    }
                    StaticDb.usersList.RemoveAt(id);
                    return StatusCode(StatusCodes.Status200OK, $"Successfully deleted the username with id {id}");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error!");
            }

        }
        
        [HttpGet("usermodels")]
        public ActionResult<List<User>> GetUsers()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.userModelsList);
        }

        [HttpPost("usermodels")]
        public IActionResult PostUsers()
        {
            try
            {
                using(StreamReader reader = new StreamReader(Request.Body))
                {
                    string userjson = reader.ReadToEnd();
                    User user = JsonConvert.DeserializeObject<User>(userjson);
                    StaticDb.userModelsList.Add(user);
                    return StatusCode(StatusCodes.Status201Created, $"The user {user.FirstName} {user.LastName} was succesfully created");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error!");
            }
        }
    }
}
