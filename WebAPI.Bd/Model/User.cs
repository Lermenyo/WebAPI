namespace WebAPI.Bd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
