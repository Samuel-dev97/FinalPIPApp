//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

//namespace Server.Models
//{
//    [Table("User", Schema = "Identity")]
//    [Index(nameof(NormalizedEmail), Name = "EmailIndex")]
//    public partial class User
//    {
//        public User()
//        {
//            UserClaims = new HashSet<UserClaims>();
//            UserLogins = new HashSet<UserLogins>();
//            UserTokens = new HashSet<UserTokens>();
//            Role = new HashSet<Role>();
//        }

//        [Key]
//        public string Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string CreatedBy { get; set; }
//        public DateTime CreatedOn { get; set; }
//        public string LastModifiedBy { get; set; }
//        public DateTime? LastModifiedOn { get; set; }
//        public bool IsDeleted { get; set; }
//        public DateTime? DeletedOn { get; set; }
//        public bool IsActive { get; set; }
//        public string RefreshToken { get; set; }
//        public DateTime RefreshTokenExpiryTime { get; set; }
//        [StringLength(256)]
//        public string UserName { get; set; }
//        [StringLength(256)]
//        public string NormalizedUserName { get; set; }
//        [StringLength(256)]
//        public string Email { get; set; }
//        [StringLength(256)]
//        public string NormalizedEmail { get; set; }
//        public bool EmailConfirmed { get; set; }
//        public string PasswordHash { get; set; }
//        public string SecurityStamp { get; set; }
//        public string ConcurrencyStamp { get; set; }
//        public string PhoneNumber { get; set; }
//        public bool PhoneNumberConfirmed { get; set; }
//        public bool TwoFactorEnabled { get; set; }
//        public DateTimeOffset? LockoutEnd { get; set; }
//        public bool LockoutEnabled { get; set; }
//        public int AccessFailedCount { get; set; }

//        [InverseProperty("User")]
//        public virtual ICollection<UserClaims> UserClaims { get; set; }
//        [InverseProperty("User")]
//        public virtual ICollection<UserLogins> UserLogins { get; set; }
//        [InverseProperty("User")]
//        public virtual ICollection<UserTokens> UserTokens { get; set; }
//        [ForeignKey(nameof(UserId))]
//        [InverseProperty(nameof(Role.User))]
//        public virtual ICollection<Role> Role { get; set; }
//    }
//}
