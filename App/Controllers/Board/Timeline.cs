﻿using Microsoft.AspNetCore.Http;
using System.Text;

namespace Kandu.Pages
{
    public class Timeline : BoardPage
    {
        public Timeline(HttpContext context) : base(context)
        {
        }

        public override string Render(string[] path, string body = "", object metadata = null)
        {
            var html = new StringBuilder();

            if (path.Length > 0)
            {
                //load timeline for board

            }

            return html.ToString();
        }
    }
}
