using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTracking.API.Models;
using DocumentTracking.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTracking.API.Controllers
{

    [ApiController]
    [Route("api/accounts/{userId}/audit")]
    public class AuditTrailsController : ControllerBase
    {
        private readonly IAuditTrailsRepository _auditTrailsRepository;

        private readonly IUsersRepository _usersRepository;

        public AuditTrailsController(IAuditTrailsRepository auditTrailsRepository, IUsersRepository usersRepository)
        {
            _auditTrailsRepository = auditTrailsRepository ??
                throw new ArgumentNullException(nameof(auditTrailsRepository));

            _usersRepository = usersRepository ??
                throw new ArgumentNullException(nameof(usersRepository));
        }

        [HttpGet]
        public IActionResult GetUserAuditTrails(Guid userId)
        {
            if(userId == null)
            {
                return NotFound();
            }
            if (!_usersRepository.UserExists(userId).Result)
            {
                return NotFound();
            }
            var result = _auditTrailsRepository.GetAuditTrails(userId).Result;
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{auditId:guid}", Name = "GetUserAuditTrail")]
        public IActionResult GetUserAuditTrail(Guid userId, Guid auditId)
        {
            if (!_usersRepository.UserExists(userId).Result)
            {
                return NotFound();
            }

            //get the record for the audit
            var result = _auditTrailsRepository.GetAuditTrail(userId, auditId).Result;

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<AuditTrailsDto> CreateAudit(Guid userId, AuditTrailsCreateDto auditTrails)
        {
            if(!_usersRepository.UserExists(userId).Result)
            {
                return NotFound();
            }

            var result = _auditTrailsRepository.CreateAudit(userId, auditTrails).Result;

            return CreatedAtRoute("GetUserAuditTrail",
                new { userId = userId, auditId = result.Id }, result);
        }

        [HttpPut]
        public ActionResult<AuditTrailsDto> UpdateAudit(Guid auditId, Guid userId, AuditTrailsCreateDto auditTrails)
        {
            if (!_usersRepository.UserExists(userId).Result)
            {
                return NotFound();
            }

            var result = _auditTrailsRepository.CreateAudit(userId, auditTrails).Result;

            return CreatedAtRoute("GetUserAuditTrail",
                new { userId = userId, auditId = result.Id }, result);
        }
    }
}