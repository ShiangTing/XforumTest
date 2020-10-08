﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface IPostService
    {
        void Create(PostDto po);
        IQueryable GetSingle(string id);
        void Delete(string id);
        void Edit(PostListDto json);
        IQueryable<PostListDto> GetAll();
      
    }
}
