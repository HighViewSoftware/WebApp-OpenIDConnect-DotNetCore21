﻿using System;

namespace BopodaMVP.Models.DashboardViewModels
{
    public class IndexViewModel : LayoutViewModel
    {
        [Obsolete(error: true, message: "This method is only for framework!")]
        public IndexViewModel()
        {
        }

        public IndexViewModel(MVPUser user) : base(user, "Quick upload")
        {

        }

        public string SiteName { get; set; }
    }
}
