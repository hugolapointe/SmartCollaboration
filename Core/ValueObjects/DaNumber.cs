using System.Collections.Generic;

using Core.Common;

namespace Core.ValueObjects {
    public class DaNumber : ValueObject {
        public string Number { get; set; }

        private DaNumber(string number) {
            Number = number;
        }

        public static DaNumber Parse(string number) {
            return new DaNumber(number);
        }

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Number;
        }
    }
}
