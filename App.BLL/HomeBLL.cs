using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IBLL;
using App.IDAL;

namespace App.BLL
{
    public class HomeBLL : BaseBLL,IHomeBLL
    {
        public IHomeRepository HomeRepository;
        public HomeBLL(IHomeRepository homeRepository)
        {
            this.HomeRepository = homeRepository;
        }
        List<Models.SysModule> IHomeBLL.GetMenuByPersonId(string personId,string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(personId,moduleId);
        }
    }
}
