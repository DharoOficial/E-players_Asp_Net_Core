using System;

namespace E_Players_Asp_Net_Core.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int IdJogador1 { get; set; }
        public int IdJogador2 { get; set; }
        public DateTime HorarioDeInicio { get;  set; }
    }
}