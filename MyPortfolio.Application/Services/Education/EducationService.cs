using Application.Contract;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Extension;
using Microsoft.EntityFrameworkCore;


namespace MyPortfolio.Application.Services.Education
{
   public class EducationService : IEducationService
    {
        private readonly IContext _context;

        public EducationService(IContext context)
        {
            _context = context;
        }

        public async Task CreateEducationAsync(EducationDto dto)
        {
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;

            var entity = new EducationEntity()
            {
                Id = dto.Id,
                TitleFa = dto.TitleFa,
                TitleEn = dto.TitleEn,
                InstituteNameFa = dto.InstituteNameFa,
                InstituteNameEn = dto.InstituteNameEn,

                DescriptionFa = dto.DescriptionFa,
                DescriptionEn = dto.DescriptionEn,

                DateOfStart = (culture == "fa-IR")
                    ? dto.DateOfStart.ConvertToGregorian()
                    : DateTime.Parse(dto.DateOfStart),

                DateOfEnd = (string.IsNullOrWhiteSpace(dto.DateOfEnd) || dto.DateOfEnd == "تا اکنون" || dto.DateOfEnd == "Present")
                    ? (DateTime?)null
                    : (culture == "fa-IR" ? dto.DateOfEnd.ConvertToGregorian() : DateTime.Parse(dto.DateOfEnd))
            };

            _context.Set<EducationEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEducationAsync(Guid id)
        {
            EducationEntity entity = await _context.Set<EducationEntity>().FirstOrDefaultAsync(f => f.Id == id);

            if(entity == null)
            {
                throw new Exception("تحصیلاتی یافت نشد");

            }

            entity.IsDelete = true;
            _context.Set<EducationEntity>().Update(entity);

           await _context.SaveChangesAsync();
        }

        public async Task<EducationDto> GetEducationByIdAsync(Guid id)
        {
            var education = await _context.Set<EducationEntity>().FindAsync(id);

            if (education == null)
                return null;

            // تشخیص زبان فعلی
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;

            var educationDto = new EducationDto()
            {
                Id = education.Id,

                // فیلدهای متنی (چون فرم ویرایش است، هر دو را پر می‌کنیم)
                TitleFa = education.TitleFa,
                TitleEn = education.TitleEn,
                InstituteNameFa = education.InstituteNameFa,
                InstituteNameEn = education.InstituteNameEn,

                DescriptionFa = education.DescriptionFa,
                DescriptionEn = education.DescriptionEn,

                // تاریخ شروع: فرمت‌بندی بر اساس زبان کاربر
                DateOfStart = (culture == "fa-IR")
                    ? education.DateOfStart.PersianDateWithOutTime()
                    : education.DateOfStart.ToString("yyyy-MM-dd"), // استاندارد ورودی date در HTML

                // تاریخ پایان: فرمت‌بندی بر اساس زبان کاربر
                DateOfEnd = education.DateOfEnd.HasValue
                    ? (culture == "fa-IR"
                        ? education.DateOfEnd.Value.PersianDateWithOutTime()
                        : education.DateOfEnd.Value.ToString("yyyy-MM-dd"))
                    : (culture == "fa-IR" ? "تا اکنون" : "Present")
            };

            return educationDto;

        }

        public async Task<PagedListViewModel<EducationViewModel>> GetPagedEducationAsync(int page, int pageSize)
        {
            var query = _context.GetQueryable<EducationEntity>().Where(x => !x.IsDelete);

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

            var result = items.Select(x => new EducationViewModel
            {
                Id = x.Id,

                // اگر در ویومدل فیلدهای اختصاصی دارید پر شوند
                TitleFa = x.TitleFa,
                TitleEn = x.TitleEn,
                InstituteNameFa = x.InstituteNameFa,
                InstituteNameEn = x.InstituteNameEn,
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

            return new PagedListViewModel<EducationViewModel>
            {
                Items = result,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalExperiences
            };


        }

        public async Task UpdateEducationAsync(EducationDto dto)
        {
            var education = await _context.Set<EducationEntity>().FindAsync(dto.Id);

            if (education == null)
                throw new Exception("تحصیلاتی با این شناسه یافت نشد");

            // تشخیص زبان فعلی سایت در لحظه ویرایش
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;

            // آپدیت فیلدهای متنی
            education.TitleFa = dto.TitleFa;
            education.TitleEn = dto.TitleEn;
            education.InstituteNameFa = dto.InstituteNameFa;
            education.InstituteNameEn = dto.InstituteNameEn;
            education.DescriptionFa = dto.DescriptionFa;
            education.DescriptionEn = dto.DescriptionEn;

            // --- منطق تبدیل تاریخ شروع ---
            if (culture == "fa-IR")
            {
                education.DateOfStart = dto.DateOfStart.ConvertToGregorian();
            }
            else
            {
                // در حالت انگلیسی، رشته مستقیم به DateTime تبدیل می‌شود
                education.DateOfStart = DateTime.Parse(dto.DateOfStart);
            }

          
            if (string.IsNullOrWhiteSpace(dto.DateOfEnd) ||
                dto.DateOfEnd == "تا اکنون" ||
                dto.DateOfEnd == "Present")
            {
                education.DateOfEnd = null;
            }
            else
            {
                education.DateOfEnd = (culture == "fa-IR")
                    ? dto.DateOfEnd.ConvertToGregorian()
                    : DateTime.Parse(dto.DateOfEnd);
            }

            await _context.SaveChangesAsync();
        }
    }
}
