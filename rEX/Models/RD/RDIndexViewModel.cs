using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rEX.Models.RD
{
    public class RDIndexViewModel : ViewModelBase
    {
        // Plain data-transfer object with only data and nearly no behavior
        // Keep ViewModel object clean only with properties for view template

        public String Country { get; set; }
        public String City { get; set; }


    }
}