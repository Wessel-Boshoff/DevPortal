using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppPortalApiService.Requests
{
    public class AjaxResult : BaseResponse
    {
        public object? Data { get; set; }
    }
}
