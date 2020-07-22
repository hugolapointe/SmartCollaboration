using System;

namespace Core.Common {
    public abstract class BaseEntity {
        public Guid Id { get; private set; }
    }
}
