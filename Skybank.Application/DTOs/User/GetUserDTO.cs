using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skybank.Application.DTOs.User
{
    public class GetUserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } 

        public GetUserDTO(Guid id, string firstName, string lastName, string email, DateTime createdAt )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedAt = createdAt;
        }
    }
}
