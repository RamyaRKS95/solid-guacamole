using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.Models
{
    public interface IBackingStoreService
    {
        void Insert();
        void Update();
        void Get();
        Task GetManyAsync();
        void Delete();
    }
}
