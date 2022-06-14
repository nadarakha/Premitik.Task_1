using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Premitik.Task_1.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Requirde")]
        public string Subject { get; set; }
        public string Name { get; set; }

        public int CaseNumber { get; set; }

        public string Source { get; set; }

        public string CustomerName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string MobilePhone { get; set; }

        public int ReleaseNumber { get; set; }
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
}