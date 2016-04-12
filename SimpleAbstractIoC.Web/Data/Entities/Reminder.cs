using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleIoCContainerIoC.Domain.Data.Entities
{
    public partial class Reminder
    {
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserID { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public virtual User User { get; set; }
    }
}
