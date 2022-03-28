using System;

namespace NOUS_challenge_app.ViewModels
{
    public class CleaningPlanViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
    }
}
