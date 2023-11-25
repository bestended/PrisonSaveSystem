using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class PrisonWard
    {
        [Key]
        public int PrisonWardId { get; set; }
        public string? WardBlock { get; set; }
        public int WardNumber { get; set; }
        public int Size { get; set; }
        public int HowManyPrisonNum { get; set; }
        public int BlockId { get; set; }

        [ForeignKey("BlockId")]
        public virtual PrisonBlock? PrisonBlock { get; set; }

    }
}
