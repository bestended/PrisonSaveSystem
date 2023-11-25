using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class PrisonBlock
    {

        [Key]
        public int BlockId { get; set; }
        public string? BlockName { get; set; }
        public string? BlockDirection { get; set; }





    }
}
