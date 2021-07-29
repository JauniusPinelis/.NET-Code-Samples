using BookKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Services
{
    public class TextFileService : IFileService
    {
        public List<string> GetAllData()
        {


            List<string> textData = System.IO.File.ReadLines("filePath").ToList();
            foreach (var item in textData)
            {
                
            }
            return null;
        }

        public IEnumerable<BookModel> Test()
        {
            List<string> textData = System.IO.File.ReadLines("filePath").ToList();
            foreach (var item in textData)
            {
                yield return new BookModel()
                {
                    Name = item
                };
            }
        }

        public void SaveAllData()
        {
            throw new NotImplementedException();
        }
    }
}
