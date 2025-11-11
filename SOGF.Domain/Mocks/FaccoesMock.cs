using SOGF.Domain.Model;

namespace SOGF.Domain.Mocks;

public static class FaccoesMock
{
    public static List<Faccao> GetFaccaoMockList()
    {
        var list = new List<Faccao>(8)
        {
            new Faccao(1,"Império Galáctico", StatusDiplomatico.Agressivo, NivelAmeaca.Alto),
            new Faccao(2,"Aliança Rebelde", StatusDiplomatico.Pacifico, NivelAmeaca.Alto),
            new Faccao(3,"Nova República",      StatusDiplomatico.Pacifico, NivelAmeaca.Baixo),
            new Faccao(4,"Primeira Ordem",      StatusDiplomatico.Agressivo, NivelAmeaca.Alto),
            new Faccao(5,"Resistência",         StatusDiplomatico.Pacifico, NivelAmeaca.Medio),
            new Faccao(6,"Guilda de Caçadores", StatusDiplomatico.Neutro, NivelAmeaca.Medio),
            new Faccao(7,"Clãs Mandalorianos",  StatusDiplomatico.Neutro, NivelAmeaca.Medio),
            new Faccao(8,"Sindicatos Hutt",     StatusDiplomatico.Neutro, NivelAmeaca.Alto)
        };

        return list;
    }
}