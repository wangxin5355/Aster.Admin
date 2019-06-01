using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Services.ViewModels.User
{
    public class UserSearchViewModel
    {
        public int? UserId { get; set; }

        public bool? IsDeleted { get; set; }


        public int? Status { get; set; }
    }
}
