using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Middlewares
{
    public class TestMiddleWare
    {
        private readonly RequestDelegate _next;
        public TestMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 这里可以读到 但是这里如果读完 api那边就读不到了 
        /// 如果这里注释掉 api那边正常读到
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var stream = new StreamReader(request.Body, Encoding.UTF8);
            var body = stream.ReadToEnd();
            await _next(context);
        }
    }
}
