using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Services.interfaces
{
    internal interface IBucketService
    {
        List<BucketDto> GetAll();
        BucketDto GetById(Guid id);
        void Create(BucketDto record);
        void Delete(Guid id);
        void Update(BucketDto record);
    }
}
