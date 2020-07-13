using System;
using System.Collections.Generic;
using System.IO;
using E_Players_Asp_Net_Core.Interfaces;

namespace E_Players_Asp_Net_Core.Models
{
    public class Equipe : BaseEplayers , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/equipe.csv";

        public void Create(Equipe e)
        {
            string[] linha = { Prepare(e) };
            File.AppendAllLines(PATH, linha);
        }
        private string Prepare(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public List<Equipe> ReadAll()
        {
            
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( Prepare(e) );
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}