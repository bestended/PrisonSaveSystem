using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class PrisonManager
    {
        [Key]
        public int ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Title { get; set; }

        public int PrisonId { get; set; }
        [ForeignKey("PrisonId")]
        public virtual Prison? Prison { get; set; }



    }
}
