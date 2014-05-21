using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Sys
{
    public class SysRightModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "ModuleId")]
        public string ModuleId { get; set; }

        [Display(Name = "RoleId")]
        public string RoleId { get; set; }

        [Display(Name = "Rightflag")]
        public bool Rightflag { get; set; }

        [Display(Name = "CreateTime")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }

}
