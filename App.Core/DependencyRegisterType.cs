using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using App.BLL;
using App.IBLL;
using App.DAL;
using App.IDAL;

namespace App.Core
{
    public class DependencyRegisterType
    {
        public static void SystemRegister(ref ContainerBuilder builder)
        {
            //业务层注入
            builder.RegisterType<SysSampleBLL>().As<ISysSampleBLL>();
            builder.RegisterType<HomeBLL>().As<IHomeBLL>();
            builder.RegisterType<SysLogBLL>().As<ISysLogBLL>();
            builder.RegisterType<SysExceptionBLL>().As<ISysExceptionBLL>();
            builder.RegisterType<AccountBLL>().As<IAccountBLL>();
            builder.RegisterType<SysUserBLL>().As<ISysUserBLL>();
            builder.RegisterType<SysModuleBLL>().As<ISysModuleBLL>();
            builder.RegisterType<SysModuleOperateBLL>().As<ISysModuleOperateBLL>();
            builder.RegisterType<SysRoleBLL>().As<ISysRoleBLL>();
            builder.RegisterType<SysRightBLL>().As<ISysRightBLL>();
            //数据层注入
            builder.RegisterType<SysSampleRepository>().As<ISysSampleRepository>();
            builder.RegisterType<HomeRepository>().As<IHomeRepository>();
            builder.RegisterType<SysLogRepository>().As<ISysLogRepository>();
            builder.RegisterType<SysExceptionRepository>().As<ISysExceptionRepository>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<SysRightRepository>().As<ISysRightRepository>();
            builder.RegisterType<SysModuleRepository>().As<ISysModuleRepository>();
            builder.RegisterType<SysModuleOperateRepository>().As<ISysModuleOperateRepository>();
            builder.RegisterType<SysRoleRepository>().As<ISysRoleRepository>();
            builder.RegisterType<SysRightRepository>().As<ISysRightRepository>();
            //过滤器,属性注入
            builder.Register(c => new SysUserBLL(new SysUserRepository(),new SysRightRepository())).As<ISysUserBLL>().InstancePerHttpRequest();
            builder.RegisterFilterProvider();
        }
    }
}
