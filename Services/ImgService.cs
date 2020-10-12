using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.Interface;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class ImgService : IImgService
    {
        private MyDBContext context;

        public ImgService(MyDBContext contexts)
        {
            context = contexts;
        }
        public void UploadImage(Guid ForumId,string link)
        {
            try
            {
                var repository = new GeneralRepository<Forums>(context);
                var fourm = repository.GetFirst(x => x.ForumId == ForumId);

                fourm.Img = link;
                repository.SaveContext();

            }
            catch(Exception ex)
            {

            }

        }

        public void UploadImage()
        {
            throw new NotImplementedException();
        }
    }
}
