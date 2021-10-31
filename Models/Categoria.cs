using System.Collections.Generic;
namespace ControleDeEstoque.Models
  
{
    public class Categoria
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}
