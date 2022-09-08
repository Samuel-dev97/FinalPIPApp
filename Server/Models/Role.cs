//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

//namespace Server.Models
//{
//    [Table("Role", Schema = "Identity")]
//    public partial class Role
//    {
//        public Role()
//        {
//            RoleClaims = new HashSet<RoleClaims>();
//            User = new HashSet<User>();
//        }

//        [Key]
//        public string Id { get; set; }
//        [StringLength(256)]
//        public string Name { get; set; }
//        [StringLength(256)]
//        public string NormalizedName { get; set; }
//        public string ConcurrencyStamp { get; set; }

//        [InverseProperty("Role")]
//        public virtual ICollection<RoleClaims> RoleClaims { get; set; }
//        [ForeignKey(nameof(RoleId))]
//        [InverseProperty(nameof(User.Role))]
//        public virtual ICollection<User> User { get; set; }
//    }
//}
