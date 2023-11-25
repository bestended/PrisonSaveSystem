using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model.ViewModels
{
    public class PrisonerVM
    {

        public Prisoner? Prisoner { get; set; }
        public IEnumerable<SelectListItem>? PrisonWardList { get; set; }


    }
}
