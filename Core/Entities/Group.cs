using System.Collections.Generic;

using Core.Common;

namespace Core.Entities {

    public class Group : AuditableEntity {
        public int Number { get; set; }

        public Course Course { get; set; }
        public IList<Student> Students { get; set; }
    }
}
