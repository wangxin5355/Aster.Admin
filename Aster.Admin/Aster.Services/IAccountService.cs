using Aster.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Services
{
    public interface IAccountService
    {
        Task<UserPagePermissions> GetUserPagePermissions(int userId);
    }
}
