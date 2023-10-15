namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if(hospedes.Count > Suite.Capacidade) throw new Exception("Quantidade de hospedes maior que a capacidade da suíte!");

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Usando logica
            int vaiAplicarDesconto = Convert.ToInt32(DiasReservados >= 10);
            decimal valorDesconto = vaiAplicarDesconto * (valor * 0.1M);

            // Usando operador condicional
            // decimal valorDesconto = DiasReservados >= 10 ? (valor * 0.1M) : 0;

            // Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            return valor - valorDesconto;
        }
    }
}
