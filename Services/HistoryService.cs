using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Interface;
using XforumTest.DTO;
using XforumTest.DataTable;

namespace XforumTest.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IRepository<History> _history;
        private readonly IRepository<Category> _category;
        private readonly IRepository<ForumMembers> _users;

        public HistoryService(IRepository<History> history, IRepository<Category> category, IRepository<ForumMembers> users)
        {
            _history = history;
            _category = category;
            _users = users;
        }

        public void GetAllHistory()
        {
            throw new NotImplementedException();
        }

        public void GetPoint(int id)
        {
            throw new NotImplementedException();
        }

        public void GetSingleHistory(string id)
        {
            throw new NotImplementedException();
        }

        public void Record(HistoryDto model)
        {
            // 紀錄取得點數
            var record = new History()
            {
                HistoryId = Guid.Parse(model.HistoryId),
                UserId = Guid.Parse(model.UserId),
                DateTime = DateTime.Parse(model.Time),
                CategoryId = model.CategoryId,
                PointChanged = model.PointsChange
            };
            _history.Create(record);

            // 增加點數
            var user = _users.GetAll2().FirstOrDefault(x => x.UserId.ToString() == model.UserId);
            var getpoints = _category.GetAll2().FirstOrDefault(x => x.CategoryId == model.CategoryId).Points;
            user.Points = user.Points + getpoints;
            _users.Update(user);

            try
            {
                _history.SaveContext();
                _users.SaveContext();
            }
            catch (Exception ex)
            { 
                
            }

        }
    }
}
}
