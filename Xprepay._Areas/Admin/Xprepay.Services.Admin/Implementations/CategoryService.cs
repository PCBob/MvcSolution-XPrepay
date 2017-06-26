using System;
using System.Collections.Generic;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin.Implementations
{
    public class CategoryService :ServiceBase, ICategoryService
    {
        public bool Add(Category entity)
        {
            using (var db=base.NewDB())
            {
                entity.NewId();
                db.Categorys.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delflag(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Categorys.Find(id);
                if (entity!=null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                    if (entity.Delflag==(int)EnumDelflag.正常)
                    {
                        entity.Delflag = (int)EnumDelflag.删除;
                    }
                    else
                    {
                        entity.Delflag = (int)EnumDelflag.正常;
                    }
                }
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(Category entity)
        {
            using (var db=base.NewDB())
            {
                var model = db.Categorys.Find(entity.Id);
                if (entity!=null)
                {
					
                }
                return db.SaveChanges() > 0;
            }
        }

        public CategoryDto Get(Guid id)
        {
            using (var db=base.NewDB())
            {
                return db.Categorys.Find(id).ToDto();
            }
        }

        public PageResult<CategoryDto> Search(CategorySearchCriteria csc, PageRequest request)
        {
            using (var db=base.NewDB())
            {
                var data = db.Categorys.AsQueryable();
                if (csc.StarTime!=null)
                {
                    data = data.Where(c => c.CreatedTime >= csc.StarTime);
                }
                if (csc.EndTime!=null)
                {
                    data = data.Where(c => c.CreatedTime <= csc.EndTime);
                }
                if (!string.IsNullOrEmpty(csc.Search))
                {
                    data = data.Where(c => c.CategoryName.Contains(csc.Search));
                }
                return data.ToDtos().ToPageResult(request);
            }
        }

        public List<CategoryDto> GetList()
        {
            using (var db=base.NewDB())
            {
                return db.Categorys.Where(c => c.Delflag != (int)EnumDelflag.删除).ToDtos().ToList();
            }
        }
    }
}

