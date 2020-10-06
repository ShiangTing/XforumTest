using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;

namespace XforumTest.Interface
{
    public interface ILikeService<T> where T :class
    {

        //void  PostLike(Guid id);

        //void PostDisLike(Guid id);

        void PostLikeAndDisLike(T entity);
      //  void PostDisLike(T entity);
        //void GetAllLike(Guid postId);

        //void GetAllMsgLike(Guid msgId);


        //void GetAllDisLike();

        //void GetAllMsgDisLike(Guid msgId);
    }
}
