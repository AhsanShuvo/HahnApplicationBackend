using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.SwaggerExample
{
    public class ApplicantExample : IExamplesProvider<ApplicantViewModel>
    {
        public ApplicantViewModel GetExamples()
        {
            return new ApplicantViewModel
            {
                Name = "Ahsan",
                FamilyName = "Shuvo",
                Address = "Mirpur-1, Dhaka",
                CountryOfOrigin = "Bangladesh",
                EmailAddress = "ahsan@shuvo",
                Age = 23,
                Hired = false
            };
        }
    }
}
