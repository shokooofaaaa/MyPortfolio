using Application.Common.Extension;
using Application.Contract;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.WorkExperience
{
   public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IContext _context;

        public WorkExperienceService(IContext context)
        {
            _context = context;
        }

        public async Task CreateWorkExperienceAsync(WorkExperienceDto dto)
        {
            // تشخیص زبان فعلی سایت در لحظه ثبت فرم
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;

            var entity = new WorkExperienceEntity()
            {
                Id = dto.Id,
                TitleFa = dto.TitleFa,
                TitleEn = dto.TitleEn,
                CompanyNameFa = dto.CompanyNameFa,
                CompanyNameEn = dto.CompanyNameEn,
                DescriptionFa = dto.DescriptionFa,
                DescriptionEn = dto.DescriptionEn,

                DateOfStart = (culture == "fa-IR")
                    ? dto.DateOfStart.ConvertToGregorian() 
                    : DateTime.Parse(dto.DateOfStart),      

                DateOfEnd = (string.IsNullOrWhiteSpace(dto.DateOfEnd) || dto.DateOfEnd == "تا اکنون" || dto.DateOfEnd == "Present")
                    ? (DateTime?)null
                    : (culture == "fa-IR" ? dto.DateOfEnd.ConvertToGregorian() : DateTime.Parse(dto.DateOfEnd))
            };

            _context.Set<WorkExperienceEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }



        public async Task  DeleteWorkExperienceAsync(Guid ExprienceId)
        {
           WorkExperienceEntity entity = await _context.Set<WorkExperienceEntity>()
                           .FirstOrDefaultAsync(f => f.Id == ExprienceId);

           if (entity == null)
            {
                throw new Exception("تجربه ای با این شناسه یافت نشد.");
            }
            entity.IsDelete = true;
            _context.Set<WorkExperienceEntity>().Update(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<PagedListViewModel<WorkExperienceViewModel>> GetPagedWorkExperienceAsync(int page, int pageSize)
        {
            var query = _context.GetQueryable<WorkExperienceEntity>().Where(x => !x.IsDelete);

            int totalExperiences = await query.CountAsync();

            var skip = (page - 1) * pageSize;
            var take = pageSize;

            var items = await query
                .OrderByDescending(x => x.DateOfStart) // بهتر است بر اساس تاریخ مرتب شود تا ID
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            // تشخیص زبان فعلی سایت
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;

            var result = items.Select(x => new WorkExperienceViewModel
            {
                Id = x.Id,

                // اگر در ویومدل فیلدهای اختصاصی دارید پر شوند
                TitleFa = x.TitleFa,
                TitleEn = x.TitleEn,
                CompanyNameFa = x.CompanyNameFa,
                CompanyNameEn = x.CompanyNameEn,
                DescriptionFa = x.DescriptionFa,
                DescriptionEn = x.DescriptionEn,

                // --- منطق دو زبانه برای تاریخ ---
                DateOfStart = (culture == "fa-IR")
                    ? x.DateOfStart.PersianDateWithOutTime()
                    : x.DateOfStart.ToString("yyyy/MM/dd"),

                DateOfEnd = x.DateOfEnd.HasValue
                    ? (culture == "fa-IR" ? x.DateOfEnd.Value.PersianDateWithOutTime() : x.DateOfEnd.Value.ToString("yyyy/MM/dd"))
                    : (culture == "fa-IR" ? "تا اکنون" : "Present"),

            }).ToList();

            return new PagedListViewModel<WorkExperienceViewModel>
            {
                Items = result,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalExperiences
            };
        }


        public async Task<WorkExperienceDto> GetWorkExperiencetByIdAsync(Guid id)
        {
            var exprience = await _context.Set<WorkExperienceEntity>().FindAsync(id);

            if (exprience == null)
                return null;

            // تشخیص زبان فعلی
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;

            var exprienceDto = new WorkExperienceDto()
            {
                Id = exprience.Id,

                // فیلدهای متنی (چون فرم ویرایش است، هر دو را پر می‌کنیم)
                TitleFa = exprience.TitleFa,
                TitleEn = exprience.TitleEn,
                CompanyNameFa = exprience.CompanyNameFa,
                CompanyNameEn = exprience.CompanyNameEn,
                DescriptionFa = exprience.DescriptionFa,
                DescriptionEn = exprience.DescriptionEn,

                // تاریخ شروع: فرمت‌بندی بر اساس زبان کاربر
                DateOfStart = (culture == "fa-IR")
                    ? exprience.DateOfStart.PersianDateWithOutTime()
                    : exprience.DateOfStart.ToString("yyyy-MM-dd"), // استاندارد ورودی date در HTML

                // تاریخ پایان: فرمت‌بندی بر اساس زبان کاربر
                DateOfEnd = exprience.DateOfEnd.HasValue
                    ? (culture == "fa-IR"
                        ? exprience.DateOfEnd.Value.PersianDateWithOutTime()
                        : exprience.DateOfEnd.Value.ToString("yyyy-MM-dd"))
                    : (culture == "fa-IR" ? "تا اکنون" : "Present")
            };

            return exprienceDto;
        }


        public async Task UpdateWorkExperienceAsync(WorkExperienceDto dto)
        {
            var exprience = await _context.Set<WorkExperienceEntity>().FindAsync(dto.Id);

            if (exprience == null)
                throw new Exception("تجربه ای با این شناسه یافت نشد");

            // تشخیص زبان فعلی سایت در لحظه ویرایش
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;

            // آپدیت فیلدهای متنی
            exprience.TitleFa = dto.TitleFa;
            exprience.TitleEn = dto.TitleEn;
            exprience.CompanyNameFa = dto.CompanyNameFa;
            exprience.CompanyNameEn = dto.CompanyNameEn;
            exprience.DescriptionFa = dto.DescriptionFa;
            exprience.DescriptionEn = dto.DescriptionEn;

            // --- منطق تبدیل تاریخ شروع ---
            if (culture == "fa-IR")
            {
                exprience.DateOfStart = dto.DateOfStart.ConvertToGregorian();
            }
            else
            {
                // در حالت انگلیسی، رشته مستقیم به DateTime تبدیل می‌شود
                exprience.DateOfStart = DateTime.Parse(dto.DateOfStart);
            }

            // --- منطق تبدیل تاریخ پایان ---
            // چک کردن مقادیر "تا اکنون" یا "Present" یا خالی بودن
            if (string.IsNullOrWhiteSpace(dto.DateOfEnd) ||
                dto.DateOfEnd == "تا اکنون" ||
                dto.DateOfEnd == "Present")
            {
                exprience.DateOfEnd = null;
            }
            else
            {
                exprience.DateOfEnd = (culture == "fa-IR")
                    ? dto.DateOfEnd.ConvertToGregorian()
                    : DateTime.Parse(dto.DateOfEnd);
            }

            await _context.SaveChangesAsync();
        }

    }
}
