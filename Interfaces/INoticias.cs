using System.Collections.Generic;
using E_Players_Asp_Net_Core.Models;

namespace E_Players_Asp_Net_Core.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias n);

        List<Noticias> ReadAll();

        void Update(Noticias n);

        void Delete(int id);
    }
}