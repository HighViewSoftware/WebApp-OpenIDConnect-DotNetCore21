﻿using System;

namespace WebApp_OpenIDConnect_DotNetCore21.Models.DashboardViewModels
{
    public class IndexViewModel : LayoutViewModel
    {
        [Obsolete(error: true, message: "This method is only for framework!")]
        public IndexViewModel()
        {
        }

        public IndexViewModel(ColossusUser user) : base(user, "Quick upload")
        {

        }

        public string SiteName { get; set; }
    }
}
