using Hahn.ApplicatonProcess.December2020.Data.EntityModels;
using Hahn.ApplicatonProcess.December2020.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicantRepository> _logger;

        public ApplicantRepository(ApplicationDbContext context, ILogger<ApplicantRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public Applicant GetApplicantInfo(int id)
        {
            _logger.LogInformation("Connecting to the database server to fetch applicant by id");
            try
            {
                return _context.Applicants.Find(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to connect to the database server to fetch applicant.");
                return null;
            }
        }

        public Applicant SaveApplicantInfo(Applicant model)
        {
            _logger.LogInformation("Connecting to the database server to add applicant info");
            try
            {
                _context.Applicants.Add(model);
                _context.SaveChanges();
                return model;

            }
            catch(Exception e)
            {
                _logger.LogError(e, "Failed to connect to the database server to add applicant.");
                return null;
            }
        }

        public ReturnCode UpdateApplicantInfo(int id, Applicant model)
        {
            _logger.LogInformation("Connecting to the database server to update applicant info");
            try
            {
                var response = _context.Applicants.Any(x => x.ID == id);
                if (response == false) return ReturnCode.NotFound;
                model.ID = id;
                _context.Attach(model);
                _context.Entry(model).CurrentValues.SetValues(model);
                _context.SaveChanges();
                return ReturnCode.Success;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Failed to connect to the database server to update applicant info.");
                return ReturnCode.Failed;
            }
        }

        public ReturnCode DeleteApplicant(int id)
        {
            _logger.LogInformation("Connecting to the database server to delete applicant info.");
            try
            {
                var applicant = _context.Applicants.Find(id);
                if (applicant == null) return ReturnCode.NotFound;
                _context.Attach(applicant);
                _context.Entry(applicant).State = EntityState.Deleted;
                _context.SaveChanges();
                return ReturnCode.Success;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Failed to connect to the database server to delete applicant.");
                return ReturnCode.Failed;
            }
        }
    }
}
