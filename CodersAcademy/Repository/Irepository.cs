using System.Collections.Generic;
using Underwater.Models;

namespace CodersAcademy.Repository
{
    public interface IRepository
    {
        IEnumerable<Fish> GetFishes();
        IEnumerable<Aquarium> GetAquarium();

        Fish GetFishById(int id);

        void AddFish(Fish fish);

        void RemoveFish(int id);

        void SaveChanges();
    }
}

