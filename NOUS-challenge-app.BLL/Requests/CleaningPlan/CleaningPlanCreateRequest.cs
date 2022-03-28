using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.Generics;

namespace NOUS_challenge_app.BLL.Requests.CleaningPlan
{
    public class CleaningPlanCreateRequest : GenericCreateRequest<CleaningPlanModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }

        public CleaningPlanCreateRequest(int customerId, string description, string title)
        {
            CustomerId = customerId;
            Description = description;
            Title = title;
        }
    }
}