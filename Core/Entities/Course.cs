using System;
using System.Collections.Generic;

using Core.Common;

namespace Core.Entities {

    public class Course : AuditableEntity {
        public string Title { get; set; }

        public IList<Group> Groups { get; set; }
    }
}