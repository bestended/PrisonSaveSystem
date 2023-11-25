using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class Guardian
    {
        [Key]
        public int GuardianId { get; set; }
        public string? GuardianName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Gender { get; set; }

        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual PrisonManager? PrisonManager { get; set; }
        public int BlockId { get; set; }
        [ForeignKey("BlockId")]
        public virtual PrisonBlock? PrisonBlock { get; set; }

    }
}
