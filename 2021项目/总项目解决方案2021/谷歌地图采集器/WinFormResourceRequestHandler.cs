﻿using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 谷歌地图采集器
{
    public class WinFormResourceRequestHandler : ResourceRequestHandler
    {
        protected override IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            var filter = FilterManager.CreateFilter(request.Identifier.ToString());
            return filter;
        }

        protected override void OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
        
            if (request.Url.ToLower().Contains("search?tbm="))
            {
                //获取response返回的body响应
                var filter = FilterManager.GetFileter(request.Identifier.ToString()) as TestJsonFilter;
                ASCIIEncoding encoding = new ASCIIEncoding();
                //这里截获返回的数据
                var data = encoding.GetString(filter.DataAll.ToArray());
                浏览器界面.json = data;
               // MessageBox.Show(data);





                //获取response返回的header参数
                //MessageBox.Show(request.Url);
                //MessageBox.Show(response.Headers["date"]);
                //StringBuilder sb = new StringBuilder();
                //foreach (var item in response.Headers)
                //{
                //    sb.Append(item.ToString()+":"+response.Headers[item.ToString()]+"\n");
                //}
               // MessageBox.Show(sb.ToString());






            }


        }
    }


}
