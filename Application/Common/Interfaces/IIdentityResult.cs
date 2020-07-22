namespace Application.Common.Interfaces {

    public interface IIdentityResult {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
    }
}
