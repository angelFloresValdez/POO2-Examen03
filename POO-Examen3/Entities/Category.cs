using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Toy=new List<Toy>();
        }

        public List<Toy>Toy {get; set;}
    }
}