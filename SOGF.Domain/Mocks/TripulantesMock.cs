using SOGF.Domain.Model;

namespace SOGF.Domain.Mocks
{
    public static class TripulantesMock
    {
        public static List<Tripulante> GetTripulantesMockList()
        {
            var list = new List<Tripulante>(30);

            list.Add(new Tripulante(1,"Luke Skywalker",    Patente.Capitao, Especialidade.Estrategista));
            list.Add(new Tripulante(2,"Wedge Antilles",    Patente.Tenente, Especialidade.Medicina));
            list.Add(new Tripulante(3,"Chewbacca",         Patente.Tenente, Especialidade.Engenharia));
            list.Add(new Tripulante(4,"Leia Organa",       Patente.Capitao, Especialidade.Batalha));
            list.Add(new Tripulante(5,"Han Solo",          Patente.Tenente, Especialidade.Engenharia));
            list.Add(new Tripulante(6,"Poe Dameron",       Patente.Capitao, Especialidade.Estrategista));
            list.Add(new Tripulante(7,"Finn",              Patente.Cadete,  Especialidade.Medicina));
            list.Add(new Tripulante(8,"Rey",               Patente.Tenente, Especialidade.Batalha));
            list.Add(new Tripulante(9,"Rose Tico",         Patente.Cadete,  Especialidade.Engenharia));
            list.Add(new Tripulante(10,"Biggs Darklighter", Patente.Tenente, Especialidade.Medicina));
            list.Add(new Tripulante(12,"Jek Porkins",       Patente.Tenente, Especialidade.Batalha));
            list.Add(new Tripulante(13,"Dak Ralter",        Patente.Cadete,  Especialidade.Engenharia));
            list.Add(new Tripulante(14,"Lando Calrissian",  Patente.Capitao, Especialidade.Batalha));
            list.Add(new Tripulante(15,"Nien Nunb",         Patente.Tenente, Especialidade.Engenharia));
            list.Add(new Tripulante(16,"Bodhi Rook",        Patente.Tenente, Especialidade.Engenharia));
            list.Add(new Tripulante(17,"Cassian Andor",     Patente.Capitao, Especialidade.Medicina));
            list.Add(new Tripulante(18,"Jyn Erso",          Patente.Tenente, Especialidade.Medicina));
            list.Add(new Tripulante(19,"Sabine Wren",       Patente.Tenente, Especialidade.Engenharia));
            list.Add(new Tripulante(20,"Hera Syndulla",     Patente.Capitao, Especialidade.Batalha));

            return list;
        }
    }
}