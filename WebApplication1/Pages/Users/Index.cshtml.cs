using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Utilities;


namespace WebApplication1.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.WebApplication1ScheduleContext _context;

        public IndexModel(WebApplication1.Models.WebApplication1ScheduleContext context)
        {
            _context = context;
        }


        //以下是异步排序与查找程序
        public string NameSort { get; set; } //按姓名排序
        public string DateSort { get; set; } //按日期排序
        public string CurrentFilter { get; set; }//当前查找
        public PaginatedList<User> User { get; set; }//分页
        //public IList<User> User { get;set; } //不分页用这个
        public string CurrentSort { get; set; } //当前分页
        public async Task OnGetAsync(string sortOrder, string searchString,string currentFilter, int? pageIndex)//在括号中增加sortOrder用来排序， searchString用来查询
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";//增加排序条件
            CurrentFilter = searchString;//定义查找
            CurrentSort = sortOrder;//定义分页

            //分页
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            //排序查询语句, userIQ 就是userIQuerable的缩写
            IQueryable<User> userIQ = from s in _context.User
                                            select s;

            //查找
            if (!String.IsNullOrEmpty(searchString))
            {
                userIQ = userIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Sex.Contains(searchString));
            }
            
            //排序
            switch (sortOrder)
            {
                case "name_desc":
                            userIQ = userIQ.OrderBy(s => s.Name);
                            break;
                default:
                    userIQ = userIQ.OrderByDescending(s => s.Name);
                    break;

            }
            int pageSize = 5;//每页显示行数
            User = await PaginatedList<User>.CreateAsync(userIQ.AsNoTracking(), pageIndex ?? 1, pageSize);//分页用这个
            //User = await userIQ.AsNoTracking().ToListAsync();//不分页用这个
        }
    }
}
