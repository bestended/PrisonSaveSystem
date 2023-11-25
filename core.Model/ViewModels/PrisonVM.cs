using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model.ViewModels
{
    public class PrisonVM
    {
        public Prison? Prison { get; set; }

        public IEnumerable<SelectListItem>? CateringCompaniesList { get; set; }


    }
}
