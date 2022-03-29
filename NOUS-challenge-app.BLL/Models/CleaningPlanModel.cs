using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOUS_challenge_app.BLL.Interfaces;

namespace NOUS_challenge_app.BLL.Models
{
    public class CleaningPlanModel : IModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(256, ErrorMessage = "Title length must be less than 257 characters long.")]
        public string Title { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(512, ErrorMessage = "Description length must be less than 513 characters long.")]
        public string Description { get; set; }
    }
}