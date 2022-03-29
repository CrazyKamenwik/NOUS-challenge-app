using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.Generics;
using System;

namespace NOUS_challenge_app.BLL.Requests.CleaningPlan
{
    public class CleaningPlanUpdateRequest : GenericUpdateRequest<CleaningPlanModel>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public CleaningPlanUpdateRequest(CleaningPlanModel model)
        {
            Id = model.Id;
            Description = model.Description;
            Title = model.Title;
        }
    }
}