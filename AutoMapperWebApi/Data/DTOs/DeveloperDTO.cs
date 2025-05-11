using AutoMapperWebApi.Data.Models;

namespace AutoMapperWebApi.Data.DTOs
{
    public class DeveloperDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal MyExperience { get; set; }
        public bool IsEmployed { get; set; }
        public Address Address { get; set; }
    }
}
