using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace POO_Examen3.Models
{
    public class ToyModel : BaseModel
    {
        public ToyModel()
        {
            ListCategoria = new List<SelectListItem>();
           
        }

        public Guid Id { get; set; }
        public string NombreJu { get; set; }
        public decimal Precio { get; set; }
        public List<SelectListItem> ListCategoria { get; set; }
         public Guid CategoriaId { get; set; }
          public CategoryModel? Categoria { get; set; }
              public string? CategoriaName { get; set; }


    
     
    }
}