using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Models.ViewModel
{
    public class StudentModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentModel()
        {
            this.Assignment = new HashSet<Assignment>();
        }

        public int StudentID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignment { get; set; }
        public virtual Cities Cities { get; set; }
    }
}
