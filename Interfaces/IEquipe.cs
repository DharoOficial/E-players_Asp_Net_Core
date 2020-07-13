using System.Collections.Generic;
using E_Players_Asp_Net_Core.Models;

namespace E_Players_Asp_Net_Core.Interfaces
{
    public interface IEquipe
    {
        void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);
    }
}