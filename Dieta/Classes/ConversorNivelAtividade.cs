using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dieta.Classes;

namespace Dieta.Classes
{
    class ConversorNivelAtividade
    {
        public String NivelDeAtividadeEmString(NivelDeAtividade nAtividade)
        {
            if (nAtividade == NivelDeAtividade.SEDENTARIO)
                return "Sedentário";
            else if (nAtividade == NivelDeAtividade.MODERADO)
                return "Moderado";
            else if (nAtividade == NivelDeAtividade.ATIVO)
                return "Ativo";
            return "Muito ativo";
        }

        public NivelDeAtividade StringEmNivelDeAtividade(String s)
        {
            if (NivelDeAtividadeEmString(NivelDeAtividade.SEDENTARIO).Equals(s))
                return NivelDeAtividade.SEDENTARIO;
            else if (NivelDeAtividadeEmString(NivelDeAtividade.MODERADO).Equals(s))
                return NivelDeAtividade.MODERADO;
            else if (NivelDeAtividadeEmString(NivelDeAtividade.ATIVO).Equals(s))
                return NivelDeAtividade.ATIVO;
            else if (NivelDeAtividadeEmString(NivelDeAtividade.MUITO_ATIVO).Equals(s))
                return NivelDeAtividade.MUITO_ATIVO;
            throw new NotSupportedException();
        }
        
        public String[] VetorStringNiveisDeAtividade()
        {
            String[] niveis = {NivelDeAtividadeEmString(NivelDeAtividade.SEDENTARIO),
                               NivelDeAtividadeEmString(NivelDeAtividade.MODERADO),
                               NivelDeAtividadeEmString(NivelDeAtividade.ATIVO),
                               NivelDeAtividadeEmString(NivelDeAtividade.MUITO_ATIVO)};
            return niveis;
        }
    }
}
