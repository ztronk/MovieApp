using System.Configuration;

namespace MovieApp.Models
{
    public static class Config
    {
        public static int PageSize
        {
            get
            {
                var pageSize = ConfigurationManager.AppSettings["PageSize"];
                int pageSizeValue = 5;

                if (int.TryParse(pageSize, out pageSizeValue))
                    return pageSizeValue;
                else
                    return 5;
            }
        }
    }
}