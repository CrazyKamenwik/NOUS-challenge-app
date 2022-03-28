using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.Generics;

namespace NOUS_challenge_app.BLL.Requests.CleaningPlan
{
    public class CleaningPlanUpdateRequest : GenericUpdateRequest<CleaningPlanModel>
    {
        public CleaningPlanUpdateRequest(string description, string title)
        {
            Description = description;
            Title = title;
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}