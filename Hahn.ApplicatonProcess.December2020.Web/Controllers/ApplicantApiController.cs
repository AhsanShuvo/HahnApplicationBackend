using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Data.Repository;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ApplicantApiController : ControllerBase
    {
        private readonly ILogger<ApplicantApiController> _logger;
        private readonly IApplicantManager _manager;

        public ApplicantApiController(IApplicantManager manager, ILogger<ApplicantApiController> logger)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet("id:int")]
        public ActionResult GetApplicantInfo(int id)
        {
            _logger.LogInformation("Accept request to provide applicant info by id");
            var applicant = _manager.GetApplicantById(id);
            if (applicant == null) return NotFound();
            return Ok(applicant);
        }

        [HttpPost]
        public ActionResult PostApplicant(ApplicantViewModel model)
        {
            _logger.LogInformation("Accespt request to save applicant info");
            var result = _manager.HandleErrors(model);
            if(result.Count > 0)
            {
                return BadRequest(result);
            }
            else
            {
                var response = _manager.SaveApplicant(model);
                if (response == null)
                    return StatusCode(500);
                return StatusCode(201, response);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateApplicant(int id, [FromBody] ApplicantViewModel model)
        {
            _logger.LogInformation("Accept request to update applicant info");
            var errors = _manager.HandleErrors(model);
            if (errors.Count > 0) return BadRequest(errors);
            var result = _manager.UpdateApplicant(id, model);
            if (result == ReturnCode.Failed)
                return StatusCode(500);
            else if (result == ReturnCode.NotFound)
                return NotFound();
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("id:int")]
        public ActionResult DeleteApplicant(int id)
        {
            _logger.LogInformation("Accept request to delete applicant info.");
            var response = _manager.DeleteApplicant(id);
            if (response == ReturnCode.Failed)
                return StatusCode(500);
            else if (response == ReturnCode.Success)
                return StatusCode(201);
            else return NotFound();
        }
    }
}
