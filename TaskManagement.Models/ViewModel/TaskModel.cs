using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Models.ViewModel
{
    public class TaskModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskModel()
        {
            this.Assignment = new HashSet<Assignment>();
        }

        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<int> CreatorID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignment { get; set; }
        public virtual Teachers Teachers { get; set; }
    }

}
