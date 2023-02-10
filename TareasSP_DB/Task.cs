using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasSP_DB
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Task { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Notificacion_Date { get; set; }
        public int ID_User { get; set; }
        [ForeignKey("ID_User")]
        public virtual User User { get; set; }
    }
}
