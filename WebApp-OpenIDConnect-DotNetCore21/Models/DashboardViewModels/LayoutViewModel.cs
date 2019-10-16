﻿using System;

namespace WebApp_OpenIDConnect_DotNetCore21.Models.DashboardViewModels
{
    public class LayoutViewModel
    {
        [Obsolete(error: true, message: "This method is only for framework!")]
        public LayoutViewModel() { }
        public LayoutViewModel(ColossusUser user, string title)
        {
            RootRecover(user, title);
        }

        public bool ModelStateValid { get; set; } = true;
        public bool JustHaveUpdated { get; set; } = false;

        public void RootRecover(ColossusUser user, string title)
        {
            UserName = "Unknown";
            EmailConfirmed = true;
            Title = title;
            HasASite = !string.IsNullOrWhiteSpace(user.SiteName);
        }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Title { get; set; }
        public bool HasASite { get; set; }
    }
}
