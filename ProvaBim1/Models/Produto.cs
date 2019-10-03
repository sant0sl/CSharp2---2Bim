using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaBim1.Models
{
    public class Produto
    {

        public int idProduto { get; set; }
        public int categoria { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string nome { get; set; }

        public int preco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "A descrição deve conter mais que 1 e menos que 255 caracteres")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "A descrição deve conter mais que 1 e menos que 100 caracteres")]
        public string marca { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "A descrição deve conter mais que 1 e menos que 100 caracteres")]
        public string modelo { get; set; }

        public Produto()
        {

        }
    }
}