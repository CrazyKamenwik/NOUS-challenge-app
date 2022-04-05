using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUS_challenge_app.DAL.Interfaces
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
    }
}
