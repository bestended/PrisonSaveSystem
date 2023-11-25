using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model.ViewModels
{
    public class VisitorVM
    {

        public Visitor? Visitor { get; set; }
        public IEnumerable<SelectListItem>? PrisonerList { get; set; }




    }
}
