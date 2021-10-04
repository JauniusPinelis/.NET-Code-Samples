using Microsoft.EntityFrameworkCore;
using PointsApplication.Entities;
using PointsApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsApplication.Services
{
    public class PointService
    {
        private PointRepository _pointRepository;
        private PointListRepository _pointListRepository;

        public PointService(PointRepository pointRepository, PointListRepository pointListRepository)
        {
            _pointRepository = pointRepository;
            _pointListRepository = pointListRepository;
        }

        public async Task<IEnumerable<CustomPoint>> GetAllAsync()
        {
            var data = await _pointRepository.GetAsync();
            var modified = data.ToList();
            return modified;
        }

        public async Task<List<CustomPoint>> Query()
        {
            return await _pointRepository.Query().ToListAsync();
        }

        public async Task<CustomPoint> GetByIdAsync(int id)
        {
            return await _pointRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CustomPoint point)
        {
            if (point.PointListId.HasValue)
            {
                var pointList = await _pointListRepository.GetById(point.PointListId.Value);
                if (pointList == null)
                {
                    throw new ArgumentException("PointList does not exist");
                }
            }

            await _pointRepository.AddAsync(point);
        }

        public async Task DeleteAsync(int id)
        {
            var point = await GetByIdAsync(id);
            await _pointRepository.DeleteAsync(point);
        }
    }
}
