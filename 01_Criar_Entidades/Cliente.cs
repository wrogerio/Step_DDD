using System.Collections.Generic;

namespace MWEstacionamentos.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Fone { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
        public string Modo { get; set; }

        // Relacionamento
        public virtual IEnumerable<Veiculo> Veiculos { get; set; }
    }
}
