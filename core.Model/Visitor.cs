using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        public string? idendificationNum { get; set; }
        public string? VisitorName { get; set; }
        public string? VisitorLastname { get; set; }
        public string? Phone { get; set; }

        public int PrisonerId { get; set; }
        [ForeignKey("PrisonerId")]
        public virtual Prisoner? Prisoner { get; set; }



    }
}
