using System.Collections.Generic;

namespace BookKeeper.Services
{
    public interface IFileService
    {
        List<string> GetAllData();
        void SaveAllData();
    }
}