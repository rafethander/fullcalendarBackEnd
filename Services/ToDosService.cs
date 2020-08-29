using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBack.Database;
using ToDoBack.Database.Models;
using ToDoBack.DTOs;
using ToDoBack.Helper;

namespace ToDoBack.Services
{
    public interface IToDosService
    {
        Task<ApiResult> ToDosAdd(ToDosAddDto model);
        Task<ICollection<ToDosGetDto>> ToDosGet();
        Task<ApiResult> ToDosDelete(Guid id);
    }
    public class ToDosService : IToDosService
    {
        private readonly ToDosDbContext _db;

        public ToDosService(ToDosDbContext db)
        {
            _db = db;
        }
        public async Task<ApiResult> ToDosAdd(ToDosAddDto model)
        {
            var entity = new ToDos
            {
                Olusturuldu = DateTime.UtcNow,
            };

            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.StartDate = model.Start;
            entity.EndDate = model.End;

            await _db.ToDos.AddAsync(entity);
            await _db.SaveChangesAsync();

            return new ApiResult { Data = model.Title, Message = ApiResultMessages.Ok };
        }

        public async Task<ApiResult> ToDosDelete(Guid id)
        {
            var entity = await _db.ToDos.Where(x => !x.Silindi && x.Id == id).FirstOrDefaultAsync();
            if (entity == null)
                return new ApiResult { Data = id, Message = ApiResultMessages.TWW001 };

            entity.Silindi = true;
            await _db.SaveChangesAsync();

            return new ApiResult { Data = id, Message = ApiResultMessages.Ok };
        }

        public async Task<ICollection<ToDosGetDto>> ToDosGet()
        {
            var entityList =await (from t in _db.ToDos where (t.Silindi==false)
                             select new ToDosGetDto
                             {
                                 Id = t.Id,
                                 Title = t.Title,
                                 Start = t.StartDate,
                                 End = t.EndDate,
                             }).ToListAsync();

            return entityList;
        }
    }
}
