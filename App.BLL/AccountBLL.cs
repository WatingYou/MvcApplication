using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using App.IBLL;

namespace App.BLL
{
    public class AccountBLL : BaseBLL, IAccountBLL
    {
        IAccountRepository AccountRepository;
        public AccountBLL(IAccountRepository accountRepository)
        {
            this.AccountRepository = accountRepository;
        }
        public SysUser Login(string username, string pwd)
        {
            return AccountRepository.Login(username, pwd);

        }
    }
}
