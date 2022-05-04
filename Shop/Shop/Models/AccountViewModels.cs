namespace Shop.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UserItemViewModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
    }

    public class LoginViewModel
    {
        /// <summary>
        /// The email of the user
        /// </summary>
        /// <example>jon@gmail.com</example>
        public string Email { get; set; }
        /// <summary>
        /// The password of the user
        /// </summary>
        /// <example>12345</example>
        public string Password { get; set; }
    }

    public class TokenResponceViewModel
    {
        /// <summary>
        /// token
        /// </summary>
        /// <example>eyJpZCI6IjEzMzciLCJ1c2VybmFtZSI6ImJpem9uZSIsImlhdCI6MTU5NDIwOTYwMCwicm9sZSI6InVzZXIifQ</example>
        public string token { get; set; }
    }
}