using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.Generics;

namespace NOUS_challenge_app.BLL.Requests.CleaningPlan
{
    public class CleaningPlanUpdateRequest : GenericUpdateRequest<CleaningPlanModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CleaningPlanUpdateRequest(CleaningPlanModel model)
        {
            Description = model.Description;
            Title = model.Title;
        }


    }
}