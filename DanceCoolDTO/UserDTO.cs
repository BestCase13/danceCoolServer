﻿using DanceCoolDTO.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace DanceCoolDTO
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(ValidationRules.MAX_LENGTH_NAME,
            ErrorMessage = "LastName too long")]
        [RegularExpression(ValidationRules.ONLY_LETTERS,
            ErrorMessage = "LastName not valid")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(ValidationRules.MAX_LENGTH_NAME,
            ErrorMessage = "LastName too long")]
        [RegularExpression(ValidationRules.ONLY_LETTERS,
            ErrorMessage = "LastName not valid")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public UserDTO(int id, string firstName, string lastName, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
