using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model.ViewModels
{
    public class PrisonManagerVM
    {

        public PrisonManager? PrisonManager { get; set; }
        public IEnumerable<SelectListItem>? PrisonList { get; set; }

    }
}
