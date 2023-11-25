using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class Prison
    {
        [Key]
        public int PrisonId { get; set; }
        public string? PrisonPlace { get; set; }
        public string? Phone { get; set; }
        public int BlockCount { get; set; }
        public int Size { get; set; }

        public int CateringId { get; set; }
        [ForeignKey("CateringId")]
        public virtual CateringCompany? CateringCompany { get; set; }

    }
}
