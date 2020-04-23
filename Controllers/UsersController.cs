using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentTracking.API.Services;
using DocumentTracking.API.Models;
using AutoMapper;
using DocumentTracking.API.ResourceParameters;
using Microsoft.AspNetCore.JsonPatch;

namespace DocumentTracking.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    //or [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        //private readonly IMapper iMapper;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ??
                throw new ArgumentNullException(nameof(usersRepository));

            //_iMapper = iMapper ??
            //    throw new ArgumentNullException(nameof(iMapper));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<UsersDto>> GetUsers([FromQuery] UsersResourceParameters usersResourceParameters)
        {
            
            var objUsers = _usersRepository.GetUsers(usersResourceParameters).Result;
            //return new JsonResult(objUsers.Result);
            return Ok(objUsers);     //This code will take care of Status Codes
        }

        [HttpGet()]
        [Route("{userId:guid}", Name = "GetUser")]
        public IActionResult GetUser(Guid userId)
        {
            var objUsers = _usersRepository.GetUser(userId).Result;
            if(objUsers == null)
            {
                return NotFound();
            }
            //return new JsonResult(objUsers.Result);
            return Ok(objUsers);     //This code will take care of Status Codes
        }

        [HttpPost]
        public ActionResult<UsersDto> CreateUser(UsersCreateDto user)
        {
            var result = _usersRepository.CreateUser(user).Result;
            //Return the named user using the specified URI name
            return CreatedAtRoute("GetUser",
                new { userId = result.Id }, result);
        }

        [HttpOptions]
        public IActionResult GetUserOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateUser(Guid userId, UsersUpdateDto usersUpdate)
        {
            if(!_usersRepository.UserExists(userId).Result)
            {
                return NotFound();
            }

            var result = _usersRepository.UpdateUser(userId, usersUpdate).Result;

            return NoContent();
        }

        [HttpPatch("{userId}")]
        public ActionResult PatchUser(Guid userId, JsonPatchDocument<UsersUpdateDto> patchDocument)
        {
            if(!_usersRepository.UserExists(userId).Result)
            {
                return NotFound();
            }

            var result = _usersRepository.PatchUser(userId, patchDocument);

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(Guid userId)
        {
            if(!_usersRepository.UserExists(userId).Result)
            {
                return NotFound();
            }

            var result = _usersRepository.DeleteUser(userId);

            return NoContent();
        }
    }
}