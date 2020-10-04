using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface ILikeService
    {

        void  PostLike(Guid id);

        void PostDisLike(Guid id);
        //void GetAllLike(Guid postId);

        //void GetAllMsgLike(Guid msgId);


        //void GetAllDisLike();

        //void GetAllMsgDisLike(Guid msgId);
    }
}
