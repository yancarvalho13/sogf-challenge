using SOGF.Domain.Model;

namespace SOGF.Domain.Mocks;

public static class PilotosMock
{
    public static List<Piloto> GetPilotosMockList()
    {
        var list = new List<Piloto>(12);

        list.Add(new Piloto(1,"Luke Skywalker",  Patente.Capitao));
        list.Add(new Piloto(2,"Wedge Antilles",  Patente.Tenente));
        list.Add(new Piloto(3,"Poe Dameron",     Patente.Capitao));
        list.Add(new Piloto(4,"Biggs Darklighter", Patente.Tenente));
        list.Add(new Piloto(5,"Jek Porkins",     Patente.Tenente));
        list.Add(new Piloto(6,"Han Solo",        Patente.Tenente));
        list.Add(new Piloto(7,"Leia Organa",     Patente.Capitao));
        list.Add(new Piloto(8,"Cassian Andor",   Patente.Capitao));
        list.Add(new Piloto(9,"Jyn Erso",        Patente.Tenente));
        list.Add(new Piloto(10,"Tycho Celchu",    Patente.Tenente));
        list.Add(new Piloto(11,"Wes Janson",      Patente.Tenente));
        list.Add(new Piloto(12,"Garven Dreis",    Patente.Capitao));

        return list;
    }
}