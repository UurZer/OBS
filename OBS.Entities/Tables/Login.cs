using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OBS.Entities.Tables
{
    [Table("Tbl_Login", Schema = "Obs")]
    public class Login
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("Son Giriş")]
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        public DateTime LastLogin { get; set; }
           
    }
}
