using System;
using System.Collections.Generic;
using System.IO;
using E_Players_Asp_Net_Core.Interfaces;

namespace E_Players_Asp_Net_Core.Models
{
    public class Noticias : BaseEplayers , INoticias
    {
        public int IdNoticias { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string  Imagem { get; set; }
        private const string PATH = "Database/Noticias.csv";

        public void Create(Noticias n)
        {
             string[] linha = { Prepare(n) };
            File.AppendAllLines(PATH, linha);
        }

        private string Prepare(Noticias n){
            return $"{n.IdNoticias} ; {n.Titulo} ; {n.Texto} ; {n.Imagem}";
        }

        public List<Noticias> ReadAll()
        {

            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticias = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
            
        }

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticias.ToString());
            linhas.Add( Prepare(n) );
            RewriteCSV(PATH, linhas);
        }
        public void DeleteN(int Id)
        {
            List<string> linhasN = ReadAllLinesCSV(PATH);
            linhasN.RemoveAll(x => x.Split(";")[0] == Id.ToString());
            RewriteCSV(PATH, linhasN);
        }


    }
}