﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Trucazo_Console
{
    public class Carta
    {
        public Carta(Pintas pinta, Valores valor)
        {
            this.Pinta = pinta;
            this.Valor = valor;
        }

        public Pintas Pinta { get; set; }
        public Valores Valor { get; set; }
         
        public enum Pintas
        {
            [Description(" de Espada")]
            Espada,
            [Description(" de Oro")]
            Oro,
            [Description(" de Basto")]
            Basto,
            [Description(" de Copa")]
            Copa
        }
        public enum Valores
        {
            Cuatro = 1,
            Cinco = 2,
            Seis = 3,
            Siete = 4,
            Diez = 5,
            Once = 6,
            Doce = 7,
            Uno = 8,
            Dos = 9,
            Tres = 10
        }
        public override string ToString()
        {
            if (((int)this.Valor) == 11)
                return "Siete de Oro";
            if ((int)this.Valor == 12)
                return "Siete de Espada";
            if ((int)this.Valor == 13)
                return "Bastillo";
            if ((int)this.Valor == 14)
                return "Espadilla";
            return (this.Valor) + GetEnumDescription(this.Pinta);
        }
        public static string GetEnumDescription(Enum enumVal)
        {
            System.Reflection.MemberInfo[] memInfo = enumVal.GetType().GetMember(enumVal.ToString());
            DescriptionAttribute attribute = CustomAttributeExtensions.GetCustomAttribute<DescriptionAttribute>(memInfo[0]);
            return attribute.Description;
        }
    }
}