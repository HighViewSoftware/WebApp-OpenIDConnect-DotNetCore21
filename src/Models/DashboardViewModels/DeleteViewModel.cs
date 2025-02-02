﻿using System;

namespace BopodaMVP.Models.DashboardViewModels
{
    public class DeleteViewModel : LayoutViewModel
    {
        [Obsolete(message: "This method is only for framework", error: true)]
        public DeleteViewModel() { }
        public DeleteViewModel(MVPUser user) : base(user, "Delete site")
        {

        }

        public void Recover(MVPUser user)
        {
            RootRecover(user, "Delete site");
        }

        public string SiteName { get; set; }
    }
}
