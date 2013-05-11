using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vuuvv.web.Helper
{
    public class Paginator<T>
    {
        private IEnumerable<T> objs;
        private int perPage;

        public Paginator(IEnumerable<T> objs, int perPage)
        {
            this.objs = objs;
            this.perPage = perPage;
            PageCount = GetPageCount();
        }

        private int GetPageCount()
        {
            return (int)Math.Ceiling((decimal)objs.Count() / perPage);
        }

        public IEnumerable<T> Page(int number)
        {
            var bottom = number > PageCount ? (PageCount - 1) * perPage : (number - 1) * perPage;
            return objs.Skip(bottom).Take(perPage);
        }

        public int PageCount { get; private set; }
    }

    public class Pager<T>
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Page { get; set; }
        public Paginator<T> Paginator { get; set; }
        public string UrlPrefix { get; set; }
        public List<T> Items { get; set; }

        public Pager()
        {
        }

        public Pager(IEnumerable<T> query, int page, string urlPrefix, int perPage = 20, int showCount = 6)
        {
            Paginator = new Paginator<T>(query, perPage);
            Items = Paginator.Page(page).ToList();

            Page = page;
            UrlPrefix = urlPrefix;

            var count = Paginator.PageCount;
            var after = count - page;
            var half = (int)Math.Floor((decimal)showCount / 2);

            if (count <= showCount)
            {
                Min = 1;
                Max = count;
            }
            else if (page < half)
            {
                Min = 1;
                Max = showCount;
            }
            else if (after < half)
            {
                Min = count - showCount + 1;
                Max = count;
            }
            else
            {
                Min = page - half + 1;
                Max = page + half;
            }
        }

        virtual public string PageUrl(int page)
        {
            return string.Format("{0}/{1}", UrlPrefix, page);
        }

        public string FirstPageUrl
        {
            get
            {
                return PageUrl(1);
            }
        }

        public string LastPageUrl
        {
            get
            {
                return PageUrl(Paginator.PageCount);
            }
        }
    }

    public class PPager<T> : Pager<T>
    {
        public PPager(IEnumerable<T> query, int page, string urlPrefix, int perPage = 16, int showCount = 6)
            :base(query, page, urlPrefix, perPage, showCount)
        {
        }

        public override string PageUrl(int page)
        {
            return string.Format("{0}/p/{1}", UrlPrefix, page);
        }
    }
}