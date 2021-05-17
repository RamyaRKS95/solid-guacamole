using BeHapi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.Interfaces.Interfaces
{
    public interface IBackingStoreService
    {
        ResponseOutput LoadAPIData();
        //  void Update();
        //void Get();
        // Task GetManyAsync();
        //void Delete();
    }
}
