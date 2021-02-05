using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.EntityModels;
using Hahn.ApplicatonProcess.December2020.Domain.Models;

namespace Hahn.ApplicatonProcess.December2020.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicantViewModel, Applicant>();
            CreateMap<Applicant, ApplicantViewModel>();
        }
    }
}
