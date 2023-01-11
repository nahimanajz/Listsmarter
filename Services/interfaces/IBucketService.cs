﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Services.interfaces
{
    public interface IBucketService
    {
        List<BucketDto> GetAll();
        BucketDto GetById(Guid id);
        BucketDto Create(BucketDto record);
        bool Delete(Guid id);
        BucketDto Update(BucketDto record);
        
        BucketDto GetByStatus(int status);
    }
}
