//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

//namespace Server.Models
//{
//    [Table("UserClaims", Schema = "Identity")]
//    [Index(nameof(UserId), Name = "IX_UserClaims_UserId")]
//    public partial class UserClaims
//    {
//        [Key]
//        public int Id { get; set; }
//        [Required]
//        public string UserId { get; set; }
//        public string ClaimType { get; set; }
//        public string ClaimValue { get; set; }

//        [ForeignKey(nameof(UserId))]
//        [InverseProperty("UserClaims")]
//        public virtual User User { get; set; }
//    }
//}
