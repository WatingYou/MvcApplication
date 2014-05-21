using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class HomeRepository : IHomeRepository, IDisposable
    {

        public List<SysModule> GetMenuByPersonId(string personId, string moduleId)
        {
            using (DBContainer db = new DBContainer())
            {
                var menus =
                (
                    from m in db.SysModules
                    join rl in db.SysRights
                    on m.Id equals rl.ModuleId
                    join r in
                        (from r in db.SysRoles
                         from u in r.SysUsers
                         where u.Id == personId
                         select r)
                    on rl.RoleId equals r.Id
                    where rl.Rightflag == true
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                          ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }


        public void Dispose()
        {

        }
    }
}
