public class ReservaService
{
    private List<Reserva> _reservas = new List<Reserva>();

    public bool ReservarSala(Sala sala, DateTime horario)
    {
        if (EstaDisponivel(sala, horario))
        {
            _reservas.Add(new Reserva(sala, horario));
            return true;
        }
        return false;
    }

    public bool CancelarReserva(Sala sala, DateTime horario)
    {
        var reserva = _reservas.FirstOrDefault(r => r.Sala.Id == sala.Id && r.Horario == horario);
        if (reserva != null)
        {
            _reservas.Remove(reserva);
            return true;
        }
        return false;
    }

    public bool EstaDisponivel(Sala sala, DateTime horario)
    {
        return !_reservas.Any(r => r.Sala.Id == sala.Id && r.Horario == horario);
    }
}
