using ImageProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Infrastructure
{
    public interface IMyMediaRepo
    {
        List<MyMedia> GetAll();
        MyMedia GetId(int Id);
        void Insert(MyMedia myMediaManager);
        void Update(MyMedia myMediaManager);
        void Delete(int id);
        void AddRange(List<MyMedia> model);
    }
}
