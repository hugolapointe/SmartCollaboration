using System.Collections.Generic;
using System.Linq;

using Application.Common.Interfaces;

namespace Application.Common.Models {

    public class IdentityResult : IIdentityResult {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        protected IdentityResult() {
            Succeeded = true;
            Errors = new string[] { };
        }

        protected IdentityResult(IEnumerable<string> errors) {
            Succeeded = false;
            Errors = errors.ToArray();
        }

        public static IdentityResult Success() => new IdentityResult();
        public static IdentityResult Failure(IEnumerable<string> errors) => new IdentityResult(errors);
    }
}
