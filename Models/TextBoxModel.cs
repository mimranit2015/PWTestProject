
namespace PWTestProject.Models
{
    public class TextBoxModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }

        public TextBoxModel(string fullName, string email, string currentAddress, string permanentAddress)
        {
            FullName = fullName;
            Email = email;
            CurrentAddress = currentAddress;
            PermanentAddress = permanentAddress;
        }
    }
}