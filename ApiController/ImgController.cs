using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {

        /// <summary>
        /// 圖片上傳測試格式1(base64資料與 postid)
        /// </summary>
        /// <param name="bas464StringList"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Upload(string[] bas464StringList,Guid id)
        {
            var guid = Guid.NewGuid();
            var service = new ImgService();
            if (bas464StringList != null)
            {

                var imgList = new List<string>();//controllerbase
                foreach(var bytes in bas464StringList)
                {
                    byte[] a = Convert.FromBase64String(bytes);
                    string b = System.Text.Encoding.UTF8.GetString(a);
                    imgList.Add(b);
                }
                
                //Imgurapi
                var apiClient = new ApiClient("0a9f2fb7434821b", "60f9a494f1607de3b90582298fc88c8e29560199");
                var httpClient = new HttpClient();

                var imageEndpoint = new ImageEndpoint(apiClient, httpClient);

                var testList = new List<string>();
                foreach (var file in imgList)
                {
                    var imageUpload = await imageEndpoint.UploadImageAsync(file);
                    testList.Add(imageUpload.Link);
                  
                }
                var stringTest = String.Join(",", testList);
                service.UploadImage(id, stringTest);



            }


            return Content("Uploadimg");
        }

        /// <summary>
        /// 圖片上傳測試格式2(files與 postid)
        /// </summary>
        /// <param name="files"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Upload(List<IFormFile> files, Guid id)
        {
            var service = new ImgService();
            var guid = Guid.NewGuid();
            if (files != null)
            {

                // var File = HttpContext.Current.Request.Files[0];
                var imgList = new List<string>();//controllerbase
                foreach(var bytes in files)
                {
                    byte[] a = Convert.FromBase64String(bytes.FileName);
                    string b = System.Text.Encoding.UTF8.GetString(a);
                    imgList.Add(b);
                }
                
                //Imgurapi
                var apiClient = new ApiClient("0a9f2fb7434821b", "60f9a494f1607de3b90582298fc88c8e29560199");
                var httpClient = new HttpClient();

                var imageEndpoint = new ImageEndpoint(apiClient, httpClient);

                
               
                var testList = new List<string>();
                foreach (var file in imgList)
                {
                    var imageUpload = await imageEndpoint.UploadImageAsync(file);
                    testList.Add(imageUpload.Link);

                }
                var stringTest = String.Join(",", testList);
                service.UploadImage(id, stringTest);





            }


            return Content("Uploadimg");
        }
    }
}
