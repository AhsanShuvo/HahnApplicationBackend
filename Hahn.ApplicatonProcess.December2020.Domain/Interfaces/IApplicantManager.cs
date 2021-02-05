using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantManager
    {
        List<string> HandleErrors(ApplicantViewModel model);
        ApplicantViewModel GetApplicantById(int id);
        ApplicantViewModel SaveApplicant(ApplicantViewModel model);
        ReturnCode UpdateApplicant(int id, ApplicantViewModel model);
        ReturnCode DeleteApplicant(int id);
    }
}
