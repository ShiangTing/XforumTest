using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Services
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        //public string GetUserId(IRequest request)
        //{
        //    // 從QueryString中取得ID作為使用者的識別名稱
        //    var id = request.QueryString["id"];
        //    return string.IsNullOrWhiteSpace(id) ? string.Empty : id;
        //}

        public string GetUserId(HubConnectionContext connection)
        {
            
        }
    }
}
