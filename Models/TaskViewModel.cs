using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Premitik.Task_1.Models
{
    public class TaskViewModel
    {
        public string Subject { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Case Num")]
        public int CaseNumber { get; set; }

        public string Source { get; set; }
        [Display(Name = "Customer Num")]
        public string CustomerName { get; set; }
        [Display(Name = "Release Num")]
        public int ReleaseNumber { get; set; }

    }
}