﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Models.Sys
{
    public class SysRightModelByRoleAndModuleModel
    {
        public string Ids { get; set; }// RightId+ KeyCode ids
        public string Name { get; set; }
        public string KeyCode { get; set; }
        public bool? IsValid { get; set; }
        public string RightId { get; set; }
    }
}
