﻿namespace AutoMapperWebApi.Data.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public decimal Experience { get; set; }
        public Address Address { get; set; }
    }
}
