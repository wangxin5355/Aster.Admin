using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Services.ViewModels.Permission
{
    public class PermissionSearchViewModel
    {
        public int? PermissionId { get; set; }

        public bool? IsDeleted { get; set; }


        public int? Status { get; set; }
    }
}
