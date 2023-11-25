using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class Prisoner
    {
        [Key]
        public int PrisonerId { get; set; }
        public string? Picture { get; set; }
        public string? PrisonerName { get; set; }
        public string? PrisonerLastname { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string? PrisonersCrime { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime ExitDate { get; set; }
        public int CrimeDuration { get; set; }

        public int PrisonWardId { get; set; }
        [ForeignKey("PrisonWardId")]
        public virtual PrisonWard? PrisonWard { get; set; }




    }
}
