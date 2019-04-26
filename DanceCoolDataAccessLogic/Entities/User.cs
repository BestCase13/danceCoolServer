﻿using System;
using System.Collections.Generic;

namespace DanceCoolDataAccessLogic.Entities
{
    public partial class User
    {
        public User()
        {
            PaymentUserReceiver = new HashSet<Payment>();
            PaymentUserSender = new HashSet<Payment>();
            UserCredentials = new HashSet<UserCredentials>();
            UserGroup = new HashSet<UserGroup>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Payment> PaymentUserReceiver { get; set; }
        public virtual ICollection<Payment> PaymentUserSender { get; set; }
        public virtual ICollection<UserCredentials> UserCredentials { get; set; }
        public virtual ICollection<UserGroup> UserGroup { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}