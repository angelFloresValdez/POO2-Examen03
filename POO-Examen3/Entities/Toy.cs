using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Entities
{
    public class Toy : BaseEntity
    {
        public Guid? CategoriaId { get; set; }
         public Category? Category { get; set; }
        

    }
}