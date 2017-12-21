using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ICT13580042FinalA.Models
{
    public class Profile
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Name { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Surname { get; set; }

        [NotNull]
        [MaxLength(10)]
        public decimal Old { get; set; }

        [NotNull]
        [MaxLength(10)]
        public string Sex { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Type { get; set; }

        [NotNull]
        [MaxLength(20)]
        public decimal Tel { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Email { get; set; }

        [NotNull]
        [MaxLength(300)]
        public string Address { get; set; }

        
        [MaxLength(10)]
        public string Status { get; set; }

        
        [MaxLength(10)]
        public decimal Boy { get; set; }

        [MaxLength(20)]
        public decimal Salary { get; set; }

    }
}


