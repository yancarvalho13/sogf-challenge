namespace SOGF.Domain.Model;

public class MissaoTripulantes
{
    public long TripulanteId { get; private set; }

    public MissaoTripulantes()
    {
    }

    public MissaoTripulantes(long tripulanteId)
    {
        TripulanteId = tripulanteId;
    }
}