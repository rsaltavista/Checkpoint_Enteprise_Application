using System.ComponentModel.DataAnnotations;

namespace MercadoEletro.Enums
{
    public enum ImpactoEnum
    {
        [Display(Name = "Nenhum")]
        Nenhum = 0,

        [Display(Name = "Baixa Criticídade")]
        BaixaCriticidade = 1,

        [Display(Name = "Críticos")]
        ProdutoCritico = 2,

        [Display(Name = "Vitais")]
        ProdutoVital = 3,
    }
}
