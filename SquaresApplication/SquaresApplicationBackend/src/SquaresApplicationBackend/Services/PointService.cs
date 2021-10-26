using SquaresApplicationBackend.Api.Repositories;
using System;
using System.Threading.Tasks;

namespace SquaresApplicationBackend.Api.Services
{
    public class PointService
    {
        private PointRepository _pointRepository;

        public PointService(PointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        public async Task RemovePoint(int id)
        {
            var point = await _pointRepository.GetByIdAsync(id);

            if (point == null)
            {
                throw new ArgumentException("Point was not found");
            }

            await _pointRepository.RemoveAsync(point);
        }
    }
}
