using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface ICountryVerificationService
    {
        Task<bool> IsValidCountry(string country);
    }
}
