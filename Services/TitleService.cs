using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;


namespace XforumTest.Services
{
    public class TitleService : ITitleService
    {
        private readonly IRepository<ForumMembers> _users;
        private readonly IRepository<Titles> _titles;
        private readonly IRepository<MemberTitle> _usertitle;

        public TitleService(IRepository<ForumMembers> users, IRepository<Titles> titles, IRepository<MemberTitle> usertitle) 
        {
            _users = users;
            _titles = titles;
            _usertitle = usertitle;
        }

        public decimal? GetPoints(GetSingle get)
        {             
            return _users.GetAll2().FirstOrDefault(x => x.UserId.ToString() == get.Id).Points;
        }
       
        public void CreateTitile(TitleCreateDto model)
        {
            try
            {
                Titles create = new Titles
                {
                    TitleId = Guid.NewGuid(),
                    TitleName = model.TitleName,
                    Price = model.Price
                };
                _titles.Create(create);
                _titles.SaveContext();
            } 
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 先不做，如果新增功能就要在欄位增加state
        /// </summary>
        public void DeleteTitile()
        {
            throw new NotImplementedException();
        }

        public void EditTitle(GetSingle get)
        {
            Titles title = _titles.GetAll().FirstOrDefault(t => t.TitleId.ToString() == get.Id);
            throw new NotImplementedException();
        }

        public List<TitleCreateDto> GetAllTitles()
        {
            return _titles.GetAll2().Select(x => new TitleCreateDto() {TitleName = x.TitleName, Price = x.Price }).ToList();
        }
        /// <summary>
        /// 取得稱號系統
        /// </summary>
        public List<HasTitle> GetHasTitles(GetSingle get)
        {
            List<HasTitle> has = (from m in _usertitle.GetAll2()
                                 join t in _titles.GetAll2()
                                 on m.HasTitleId equals t.TitleId
                                 where m.UserId.ToString() == get.Id
                                 select new HasTitle()
                                 {
                                      TitleName = t.TitleName
                                 }).ToList();                       
            
            return has;
        }
        /// <summary>
        /// 購買稱號系統
        /// </summary>
        /// <param name="buy"></param>
        /// <returns></returns>
        public string BuyTitle(BuyTitle buy)
        {
            ForumMembers user = _users.GetAll2().FirstOrDefault(u => u.UserId.ToString() == buy.UserId);
            TitleDto price = _titles.GetAll2().Select(x => new TitleDto() { 
                TitleId = x.TitleId,
                TitleName =x.TitleName,
                Price =decimal.Parse( x.Price.ToString())            
            }).FirstOrDefault(t => t.TitleName == buy.TitleId);

            if (user.Points > price.Price)
            {
                user.Points = user.Points - price.Price;
                _users.Update(user);
                _users.SaveContext();

                MemberTitle newtitle = new MemberTitle
                {
                    UserId = Guid.Parse(buy.UserId),
                    HasTitleId = price.TitleId
                };

                _usertitle.Create(newtitle);
                _usertitle.SaveContext();
                return "稱號購買完成";
            }
            return "點數不足，請加把勁";

        }
        public void ChangeTitle()
        {
            throw new NotImplementedException();
        }
    }
}
