﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Sys
{
    public class SysSampleModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }


        [Display(Name = "名称")]
        public string Name { get; set; }


        [Display(Name = "年龄")]
        [Range(0, 10000)]
        public int? Age { get; set; }

        [Display(Name = "生日")]
        public DateTime? Bir { get; set; }

        [Display(Name = "照片")]
        public string Photo { get; set; }


        [Display(Name = "简介")]
        public string Note { get; set; }

        [Display(Name = "创建时间")]
        public DateTime? CreatTime { get; set; }

    }
}
