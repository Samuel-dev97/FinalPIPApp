//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

//namespace Server.Models
//{
//    [Table("RoleClaims", Schema = "Identity")]
//    [Index(nameof(RoleId), Name = "IX_RoleClaims_RoleId")]
//    public partial class RoleClaims
//    {
//        [Key]
//        public int Id { get; set; }
//        [Required]
//        public string RoleId { get; set; }
//        public string ClaimType { get; set; }
//        public string ClaimValue { get; set; }

//        [ForeignKey(nameof(RoleId))]
//        [InverseProperty("RoleClaims")]
//        public virtual Role Role { get; set; }
//    }
//}
