using Hahn.ApplicatonProcess.December2020.Data.EntityModels;

namespace Hahn.ApplicatonProcess.December2020.Data.Interfaces
{
    public interface IApplicantRepository
    {
        Applicant GetApplicantInfo(int id);
        Applicant SaveApplicantInfo(Applicant model);
        ReturnCode UpdateApplicantInfo(int id, Applicant model);
        ReturnCode DeleteApplicant(int id);
    }
}
