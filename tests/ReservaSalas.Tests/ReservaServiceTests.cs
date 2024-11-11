namespace ReservaSalas.Tests
{
    public class ReservaServiceTests
    {
        [Fact]
        public void DeveReservarSalaSeDisponivel()
        {
            var sala = new Sala(1, "Sala A");
            var service = new ReservaService();
            var horario = DateTime.Now;

            var resultado = service.ReservarSala(sala, horario);

            Assert.True(resultado);
        }

        [Fact]
        public void NaoDeveReservarSalaSeIndisponivel()
        {
            var sala = new Sala(1, "Sala A");
            var service = new ReservaService();
            var horario = DateTime.Now;

            service.ReservarSala(sala, horario); // Primeira reserva
            var resultado = service.ReservarSala(sala, horario); // Tentativa de segunda reserva

            Assert.False(resultado);
        }

        [Fact]
        public void DeveCancelarReserva()
        {
            var sala = new Sala(1, "Sala A");
            var service = new ReservaService();
            var horario = DateTime.Now;

            service.ReservarSala(sala, horario);
            var resultado = service.CancelarReserva(sala, horario);

            Assert.True(resultado);
            Assert.True(service.EstaDisponivel(sala, horario));
        }

        [Fact]
        public void SalaDeveEstarDisponivelAposCancelamento()
        {
            var sala = new Sala(1, "Sala A");
            var service = new ReservaService();
            var horario = DateTime.Now;

            service.ReservarSala(sala, horario);
            service.CancelarReserva(sala, horario);

            Assert.True(service.EstaDisponivel(sala, horario));
        }
    }
}
