using NOUS_challenge_app.DAL.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOUS_challenge_app.DAL.Entities
{
    public class CleaningPlanEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
