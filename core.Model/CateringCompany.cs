using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class CateringCompany
    {
        [Key]
        public int CateringId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? Place { get; set; }
        public string? OfficialName { get; set; }



    }
}
