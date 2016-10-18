
 using System;
 using System.ComponentModel.DataAnnotations.Schema;


namespace EDeviceClaims.Entities
 {
   [Table("claims", Schema = "app")]
   public class ClaimEntity : EntityBase<Guid>
   {
    public Guid PolicyId { get; set; }
    public virtual PolicyEntity Policy { get; set; }
   }
 }

