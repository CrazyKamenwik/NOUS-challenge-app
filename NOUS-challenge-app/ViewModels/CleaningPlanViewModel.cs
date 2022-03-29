using System;
using NOUS_challenge_app.Interfaces;

namespace NOUS_challenge_app.ViewModels
{
    public class CleaningPlanViewModel : IViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
    }
}