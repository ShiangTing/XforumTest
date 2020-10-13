using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.Interface;


namespace XforumTest.Services
{
    public class ImgService : IImgService
    {
        private readonly IRepository<Forums> _forums;

        public ImgService(IRepository<Forums> forums)
        {
            _forums = forums;
        }
        public void UploadImage(Guid ForumId,string link)
        {
            try
            {
                var fourm = _forums.GetFirst(x => x.ForumId == ForumId);
                fourm.Img = link;
                _forums.SaveContext();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void UploadImage()
        {
            throw new NotImplementedException();
        }
    }
}
