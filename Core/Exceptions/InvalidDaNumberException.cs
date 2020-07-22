using System;
using System.Runtime.Serialization;

namespace Core.Exceptions {
    [Serializable]
    internal class InvalidDaNumberException : Exception {
        public InvalidDaNumberException() {
        }

        public InvalidDaNumberException(string message) : base(message) {
        }

        public InvalidDaNumberException(string message, Exception innerException) : base(message, innerException) {
        }

        protected InvalidDaNumberException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}