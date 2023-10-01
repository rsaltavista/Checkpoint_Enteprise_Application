using MercadoEletro.Enums;
using System.ComponentModel.DataAnnotations;

namespace MercadoEletro.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Atualizacao { get; set; }

        public string? Nome { get; set; }

        public string? Marca { get; set; }

        public double Preco { get; set; }

        public int MaterialTipoId { get; set; }

        public MaterialTipo MaterialTipo { get; set; }

        public ImpactoEnum Impacto { get; set; }

        public ImportanciaEnum Importancia { get; set; }

        public bool Ativo { get; set; }

    }
}
