using System;
using System.ComponentModel.DataAnnotations;

namespace BopodaMVP.Models.DashboardViewModels
{
    public class DeleteFileViewModel : LayoutViewModel
    {
        [Obsolete(message: "This method is only for framework", error: true)]
        public DeleteFileViewModel() { }
        public DeleteFileViewModel(MVPUser user) : base(user, "Delete file")
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
