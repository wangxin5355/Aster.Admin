using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aster.Common.Data.Core.Repositories;
using Aster.Common.Data.Core.Sessions;
using Aster.Entities;
using Aster.Entities.Models;
using Aster.Services.Models;
using Dapper;
using static Aster.Entities.CommonEnum;

namespace Aster.Services.Impl
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Menu> _menuRepository;
        private readonly IDapperSessionContext _sessionContext;
        public AccountService(IRepository<User> userRepository, IRepository<Menu> menuRepository, IDapperSessionContext sessionContext)
        {
            _userRepository = userRepository;
            _menuRepository = menuRepository;
            _sessionContext = sessionContext;
        }
        public async Task<UserPagePermissions> GetUserPagePermissions(int userId)
        {
            var user = await _userRepository.Query(x => x.Id == userId).FirstOrDefaultAsync();
            var menus = (await _menuRepository.Query(x => x.IsDeleted && x.Status == Status.Normal).ToListAsync()).ToList();
            var sqlPermission = @"SELECT P.id AS permissionId,P.actionCode AS permissionActionCode,P.name AS permissionName,P.type AS permissionType,M.name AS menuName,M.id AS menuId,M.alias AS menuAlias,M.isDefaultRouter FROM RolePermissionMapping AS RPM 
LEFT JOIN permission AS P ON P.id = RPM.permissionId
INNER JOIN menu AS M ON M.id = P.menuId
WHERE P.isDeleted=0 AND P.status=1 AND EXISTS (SELECT 1 FROM UserRoleMapping AS URM WHERE URM.userId=@userId AND URM.roleid=RPM.roleid)";
            if (user.UserType == (int)UserType.SuperAdministator)
            {
                sqlPermission = @"SELECT P.id AS permissionId,P.actionCode AS permissionActionCode,P.name AS permissionName,P.type AS permissionType,M.name AS menuName,M.id AS menuid,M.alias AS menuAlias,M.isDefaultRouter FROM permission AS P 
INNER JOIN menu AS M ON M.id = P.menuId
WHERE P.isDeleted=0 AND P.status=1";
            }
            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("userId", userId);
            var session = _sessionContext.GetSession("DefaultConnectionString");
            var permissions = await session.QueryAsync<PermissionWithMenu>(sqlPermission, paras, commandTimeout: (int)TimeSpan.FromMinutes(1).TotalSeconds);
            var allowPages = new List<string> { };
            if (user.UserType == (int)UserType.SuperAdministator)
            {
                allowPages.AddRange(menus.Select(x => x.Alias));
            }
            else
            {
                allowPages.AddRange(menus.Where(x => x.IsDefaultRouter).Select(x => x.Alias));
                foreach (var permission in permissions.Where(x => x.PermissionType == PermissionType.Menu))
                {
                    allowPages.AddRange(FindParentMenuAlias(menus, permission.MenuId));
                }
            }

            var pages = allowPages.Distinct().ToList();
            var pagePermissions = permissions.GroupBy(x => x.MenuAlias).ToDictionary(g => g.Key, g => g.Select(x => x.PermissionActionCode).ToList());
            UserPagePermissions userPagePermissions = new UserPagePermissions();
            userPagePermissions.Access = new string[] { };
            userPagePermissions.Avator = user.Avatar;
            userPagePermissions.UserId = user.Id;
            userPagePermissions.UserName = user.DisplayName;
            userPagePermissions.UserType = user.UserType;
            userPagePermissions.Pages = pages;
            userPagePermissions.PagePermissions = pagePermissions;

            return userPagePermissions;

        }

        private List<string> FindParentMenuAlias(List<Menu> menus, int parentId)
        {
            var pages = new List<string>();
            var parent = menus.FirstOrDefault(x => x.Id == parentId);
            if (parent != null)
            {
                if (!pages.Contains(parent.Alias))
                {
                    pages.Add(parent.Alias);
                }
                else
                {
                    return pages;
                }
                if (parent.ParentId !=0)
                {
                    pages.AddRange(FindParentMenuAlias(menus, parent.ParentId));
                }
            }

            return pages.Distinct().ToList();
        }
    }
}
