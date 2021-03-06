﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.DTO;
using XforumTest.Services;
using static System.Net.Mime.MediaTypeNames;

namespace XforumTest.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {


        //[HttpPost]
        //public async Task<IActionResult> Upload(string[] bas464StringList)
        //{
        //    var guid = Guid.NewGuid();
        //    var service = new ImgService();
        //    if (bas464StringList != null)
        //    {

        //        var imgList = new List<string>();//controllerbase
        //        foreach (var bytes in bas464StringList)
        //        {
        //            byte[] a = Convert.FromBase64String(bytes);
        //            string b = System.Text.Encoding.UTF8.GetString(a);
        //            imgList.Add(b);
        //        }

        //        //Imgurapi
        //        var apiClient = new ApiClient("0a9f2fb7434821b", "60f9a494f1607de3b90582298fc88c8e29560199");
        //        var httpClient = new HttpClient();

        //        var imageEndpoint = new ImageEndpoint(apiClient, httpClient);

        //        var testList = new List<string>();
        //        foreach (var file in imgList)
        //        {
        //            var imageUpload = await imageEndpoint.UploadImageAsync(file);
        //            testList.Add(imageUpload.Link);
        //            return testList;
        //        }
        //        // var stringTest = String.Join(",", testList);
        //        //  service.UploadImage(id, stringTest);



        //    }


        //    return Content("Uploadimg");
        //}

        ///// <summary>
        ///// 圖片上傳測試格式2(files與 postid)
        ///// </summary>
        ///// <param name="files"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<IActionResult> Upload(List<IFormFile> files, Guid id)
        //{
        //    var service = new ImgService();
        //    var guid = Guid.NewGuid();
        //    if (files != null)
        //    {

        //        // var File = HttpContext.Current.Request.Files[0];
        //        var imgList = new List<string>();//controllerbase
        //        foreach (var bytes in files)
        //        {
        //            byte[] a = Convert.FromBase64String(bytes.FileName);
        //            string b = System.Text.Encoding.UTF8.GetString(a);
        //            imgList.Add(b);
        //        }

        //        //Imgurapi
        //        var apiClient = new ApiClient("0a9f2fb7434821b", "60f9a494f1607de3b90582298fc88c8e29560199");
        //        var httpClient = new HttpClient();

        //        var imageEndpoint = new ImageEndpoint(apiClient, httpClient);



        //        var testList = new List<string>();
        //        foreach (var file in imgList)
        //        {
        //            var imageUpload = await imageEndpoint.UploadImageAsync(file);
        //            testList.Add(imageUpload.Link);

        //        }
        //        var stringTest = String.Join(",", testList);
        //        service.UploadImage(id, stringTest);





        //    }


        //    return Content("Uploadimg");
        //}

        /// <summary>
        /// 傳dto物件 會回傳imgur網址
        /// public string base64String { get; set; }
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<string> UploadImg([FromBody] ImguploadDto dto)
        {

            if (dto != null)
            {
                //convert base64 to byte[]
                byte[] imageBytes = Convert.FromBase64String(dto.base64String);

                //convert  byte[] to imgStream
                // var imgStream = System.Text.Encoding.UTF8.GetString(imageBytes);
                var imgStream = new MemoryStream(imageBytes);

                //Imgurapi
                var apiClient = new ApiClient("0a9f2fb7434821b", "60f9a494f1607de3b90582298fc88c8e29560199");
                var httpClient = new HttpClient();
                var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
                var imageUpload = await imageEndpoint.UploadImageAsync(imgStream);


                return imageUpload.Link;


            }

            else
            {
                return "dataURL= null";
            }
        }

        /// <summary>
        /// 傳dto物件 會回傳imgur網址
        /// public string base64String { get; set; }
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<string> UploadImg2(ImguploadDto dto)
        {

            if (dto != null)
            {
                //convert base64 to byte[]
                byte[] imageBytes = Convert.FromBase64String(dto.base64String);

                //convert  byte[] to imgStream
                // var imgStream = System.Text.Encoding.UTF8.GetString(imageBytes);
                var imgStream = new MemoryStream(imageBytes);

                //Imgurapi
                var apiClient = new ApiClient("0a9f2fb7434821b", "60f9a494f1607de3b90582298fc88c8e29560199");
                var httpClient = new HttpClient();
                var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
                var imageUpload = await imageEndpoint.UploadImageAsync(imgStream);


                return imageUpload.Link;


            }

            else
            {
                return "dataURL= null";
            }
        }
    }
}
