using System;
using System.ComponentModel.DataAnnotations;

namespace BopodaMVP.Models.DashboardViewModels
{
    public class DeleteFolderViewModel : LayoutViewModel
    {
        [Obsolete(message: "This method is only for framework", error: true)]
        public DeleteFolderViewModel() { }
        public DeleteFolderViewModel(MVPUser user) : base(user, "Delete folder")
        {

        }

        public void Recover(MVPUser user)
        {
            RootRecover(user, "Delete file");
        }

        [Required]
        public string Path { get; set; }
    }
}
