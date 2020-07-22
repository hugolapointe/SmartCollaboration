using System.Collections.Generic;

using Core.Common;
using Core.ValueObjects;

namespace Core.Entities {

    public class Student : AuditableEntity {
        public DaNumber DA { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Group> Groups { get; set; }
    }
}
