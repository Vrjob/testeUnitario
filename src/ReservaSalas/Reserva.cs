public class Reserva
{
    public Sala Sala { get; }
    public DateTime Horario { get; }

    public Reserva(Sala sala, DateTime horario)
    {
        Sala = sala;
        Horario = horario;
    }
}
