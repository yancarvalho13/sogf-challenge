using SOGF.Domain.Model;

namespace SOGF.Domain.Mocks
{
    public static class MissoesMock
    {
        public static List<Missao> GetMissoesMockList()
        {
            var list = new List<Missao>(5);

            // Missão 1 — Infiltração (DeepCore)
            list.Add(new Missao(1,
                objetivoMissao: ObjetivoMissao.Infiltracao,
                setorGalatico: SetorGalatico.DeepCore,
                naveId: 1,
                pilotoId: 1,
                tripulantes: new List<MissaoTripulantes>
                {
                    new MissaoTripulantes(1),
                    new MissaoTripulantes(2)
                }
            ));

            // Missão 2 — Exploração (CoreWorlds)
            list.Add(new Missao(2,
                ObjetivoMissao.Exploracao,
                SetorGalatico.CoreWorlds,
                naveId: 2,
                pilotoId: 2,
                new List<MissaoTripulantes>
                {
                    new MissaoTripulantes(3),
                    new MissaoTripulantes(4)
                }
            ));

            // Missão 3 — Ataque (MidRim)
            list.Add(new Missao(3,
                ObjetivoMissao.Ataque,
                SetorGalatico.MidRim,
                naveId: 3,
                pilotoId: 3,
                new List<MissaoTripulantes>
                {
                    new MissaoTripulantes(5),
                    new MissaoTripulantes(6)
                }
            ));

            // Missão 4 — Exploração (OuterRim)
            list.Add(new Missao(4,
                ObjetivoMissao.Exploracao,
                SetorGalatico.OuterRim,
                naveId: 4,
                pilotoId: 4,
                new List<MissaoTripulantes>
                {
                    new MissaoTripulantes(7),
                    new MissaoTripulantes(8)
                }
            ));

            // Missão 5 — Ataque (OuterRim)
            list.Add(new Missao(5,
                ObjetivoMissao.Ataque,
                SetorGalatico.OuterRim,
                naveId: 5,
                pilotoId: 5,
                new List<MissaoTripulantes>
                {
                    new MissaoTripulantes(7),
                    new MissaoTripulantes(8)
                }
            ));
            

            return list;
        }
    }
}
