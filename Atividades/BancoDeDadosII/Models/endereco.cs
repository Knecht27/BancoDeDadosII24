using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosII.Models
{
    
    public enum UF
    {
        RS , SC, PR, SP, RJ, ES, MS, MT, MG, RO, AC, RR, AM, PA, TO, GO, MA, PI, CE, RN, PB, PE, AL, SE, BA, DF
    }
    
    public class endereco
    {
        public int Id { get; set; }
        public string? Rua { get; set; }
        public string? Numero  { get; set; }
        public string? Bairro { get; set; }
        public string? cidade{ get; set; }
        public UF UF { get; set; }
        public string? Pais { get; set; } = "Brasil";
        public string? CEP { get; set; }

        public long PessoaId { get; set; }
        [ForeignKey("PessoaId")]
        public Pessoa Pessoa { get; set; }
    }
}
