using System.ComponentModel.DataAnnotations;

namespace MercadoEletro.Enums
{
    public enum ImportanciaEnum
    {
        Nenhum = 0,
        [Display(Name = "Maior Consumo")]
        ConsumoMaior = 1,

        [Display(Name = "Consumo Moderado")]
        ConsumoModerado = 2,

        [Display(Name = "Consumo Reduzido")]
        ConsumoReduzido = 3,
    }
}
