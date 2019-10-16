using Aiursoft.Pylon.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BopodaMVP.Models.DashboardViewModels
{
    public class NewFolderViewModel : LayoutViewModel
    {
        [Obsolete(message: "This method is only for framework", error: true)]
        public NewFolderViewModel() { }
        public NewFolderViewModel(MVPUser user) : base(user, "Create new folder") { }
        public void Recover(MVPUser user)
        {
            RootRecover(user, "Create new folder");
        }

        [ValidFolderName]
        public string NewFolderName { get; set; }

        [FromRoute]
        public string Path { get; set; }
    }
}
