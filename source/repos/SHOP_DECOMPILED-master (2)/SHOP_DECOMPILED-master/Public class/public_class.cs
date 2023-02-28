using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Public_class
{
    internal class public_class: Controller
    {
        protected void alert(string msg_header, string msg_type, string msg)
        {
            TempData["msg"] = msg;
            TempData["msg_type"] = msg_type;
            TempData["msg_header"] = msg_header;
        }
    }
}
