using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Data.EntityModels;
using Hahn.ApplicatonProcess.December2020.Data.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Domain.Validator;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Domain.Manager
{
    public class ApplicantManager : IApplicantManager
    {
        private ApplicantValidator _validator;
        private IApplicantRepository _applicantRepository;
        private IMapper _mapper;

        public ApplicantManager(ApplicantValidator validator,
            IApplicantRepository applicantRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
            _validator = validator;
        }

        public List<string> HandleErrors(ApplicantViewModel applicant)
        {
            var errors = new List<string>();

            var result = _validator.Validate(applicant);
            if (!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors;
        }

        public ApplicantViewModel GetApplicantById(int id)
        {
            var applicant = _applicantRepository.GetApplicantInfo(id);
            if (applicant != null)
            {
                return _mapper.Map<Applicant, ApplicantViewModel>(applicant);
            }
            
            return null;
        }

        public ApplicantViewModel SaveApplicant(ApplicantViewModel model)
        {
            var applicant = _mapper.Map<ApplicantViewModel, Applicant>(model);
            var result = _applicantRepository.SaveApplicantInfo(applicant);
            var applicantViewModel = _mapper.Map<Applicant, ApplicantViewModel>(result);
            return applicantViewModel;
        }
        
        public ReturnCode UpdateApplicant(int id, ApplicantViewModel model)
        {
            var applicant = _mapper.Map<ApplicantViewModel, Applicant>(model);
            return _applicantRepository.UpdateApplicantInfo(id, applicant);
        }

        public ReturnCode DeleteApplicant(int id)
        {
            return _applicantRepository.DeleteApplicant(id);
        }
    }
}
