using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Models
{
    public class PagerModel
    {
        private int pageIndex = -2;
        private int pageSize;

        public int CurrentPage => PageIndex + 1;

        public int PageIndex
        {
            get
            {
                if (pageIndex < 0)
                {
                    return 0;
                }
                return pageIndex;
            }
            set => pageIndex = value;
        }

        public int PageSize
        {
            get => (pageSize <= 0) ? 10 : pageSize;
            set => pageSize = value;
        }

        public int TotalPages
        {
            get
            {
                if ((TotalRecords == 0) || (PageSize == 0))
                {
                    return 0;
                }
                var num = TotalRecords / PageSize;
                if ((TotalRecords % PageSize) > 0)
                {
                    num++;
                }
                return num;
            }
        }

        public int TotalRecords { get; set; }
        public string UrlAdress { get; set; }
        public string SearchString { get; set; }
        public UserType UserType { get; set; } = UserType.All;
    }
}
