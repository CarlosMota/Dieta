using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dieta.Classes;

namespace Dieta.Classes
{
    class ConversorMeta
    {
        public string MetaEmString(Meta meta)
        {
            if (meta == Meta.GANHAR_2KG)
                return "Ganhar 2kg/semana";
            else if (meta == Meta.GANHAR_1_5KG)
                return "Ganhar 1.5kg/semana";
            else if (meta == Meta.GANHAR_1KG)
                return "Ganhar 1kg/semana";
            else if (meta == Meta.GANHAR_0_5KG)
                return "Ganhar 0.5kg/semana";
            else if (meta == Meta.MANTER)
                return "Manter peso";
            else if (meta == Meta.PERDER_0_5KG)
                return "Perder 0.5kg/semana";
            else if (meta == Meta.PERDER_1KG)
                return "Perder 1kg/semana";
            else if (meta == Meta.PERDER_1_5KG)
                return "Perder 1.5kg/semana";
            else if (meta == Meta.PERDER_2KG)
                return "Perder 2.0kg/semana";
            else
                throw new NotImplementedException();
        }

        public string[] VetorStringMeta()
        {
            string[] metas = { MetaEmString(Meta.GANHAR_2KG),MetaEmString(Meta.GANHAR_1_5KG),MetaEmString(Meta.GANHAR_1KG),
                               MetaEmString(Meta.GANHAR_0_5KG), MetaEmString(Meta.MANTER), MetaEmString(Meta.PERDER_0_5KG),
                               MetaEmString(Meta.PERDER_1KG), MetaEmString(Meta.PERDER_1_5KG), MetaEmString(Meta.PERDER_2KG)};
            return metas;
        }

        public Meta StringEmMeta(string s)
        {
            if (MetaEmString(Meta.GANHAR_2KG).Equals(s))
                return Meta.GANHAR_2KG;
            else if (MetaEmString(Meta.GANHAR_1_5KG).Equals(s))
                return Meta.GANHAR_1_5KG;
            else if (MetaEmString(Meta.GANHAR_1KG).Equals(s))
                return Meta.GANHAR_1KG;
            else if (MetaEmString(Meta.GANHAR_0_5KG).Equals(s))
                return Meta.GANHAR_0_5KG;
            else if (MetaEmString(Meta.MANTER).Equals(s))
                return Meta.MANTER;
            else if (MetaEmString(Meta.PERDER_0_5KG).Equals(s))
                return Meta.PERDER_0_5KG;
            else if (MetaEmString(Meta.PERDER_1KG).Equals(s))
                return Meta.PERDER_1KG;
            else if (MetaEmString(Meta.PERDER_1_5KG).Equals(s))
                return Meta.PERDER_1_5KG;
            else if (MetaEmString(Meta.PERDER_2KG).Equals(s))
                return Meta.PERDER_2KG;
            else
                throw new NotImplementedException();
        }

        public double MetaEmDouble(Meta meta)
        {
            if (meta == Meta.GANHAR_2KG)
                return 2;
            else if (meta == Meta.GANHAR_1_5KG)
                return 1.5;
            else if (meta == Meta.GANHAR_1KG)
                return 1;
            else if (meta == Meta.GANHAR_0_5KG)
                return 0.5;
            else if (meta == Meta.MANTER)
                return 0;
            else if (meta == Meta.PERDER_0_5KG)
                return -0.5;
            else if (meta == Meta.PERDER_1KG)
                return 1;
            else if (meta == Meta.PERDER_1_5KG)
                return -1.5;
            else if (meta == Meta.PERDER_2KG)
                return -2;
            else
                throw new NotImplementedException();
        }
    }
}
