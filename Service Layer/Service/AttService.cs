using Domain_Layer.Migrations;
using Domain_Layer.Model;
using Repository_Layer.IRepository;
using Service_Layer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service_Layer.Service.AttService;

namespace Service_Layer.Service
{
    public class AttService : IAttService<Attendences>
    {
        private readonly IAttRepository<Attendences> _AttendenceRepository;
        public AttService(IAttRepository<Attendences> AttendenceRepository)
        {
            _AttendenceRepository = AttendenceRepository;
        }

        public IAttRepository<Attendences>? AttendenceRepository
        {
            get; private set;
        }
        public IEnumerable<Attendences> GetAttendanceByMonth(string month)
        {
            return _AttendenceRepository.GetAttendenceByMonth(month);
        }
        
         public IEnumerable<Attendences> GetAttendanceByEmployeeName(string employeeName)
            {
                return _AttendenceRepository.GetAttendanceByEmployeeName(employeeName);
            }
        public async Task<IEnumerable<string>> GetAllEmployeeNames()
        {
            return await _AttendenceRepository.GetAllEmployeeNames();
        }
        public async Task<IEnumerable<string>> GetAllMonthsAsync()
        {
            return await _AttendenceRepository.GetAllMonthsAsync();
        }




        public void Delete(Attendences entity)
        {
            try
            {
                if (entity != null)
                {
                    _AttendenceRepository.Delete(entity);
                    _AttendenceRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Attendences? Get(int EmpId)
        {
            try
            {
                var obj = _AttendenceRepository.Get(EmpId);
                if (obj != null)
                {
                    return (Attendences)obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Attendences>? GetAll()
        {
            try
            {
                var obj = _AttendenceRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(Attendences entity)
        {
            try
            {
                if (entity != null)
                {
                    _AttendenceRepository.Insert(entity);
                    _AttendenceRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Attendences entity)
        {
            try
            {
                if (entity != null)
                {
                    _AttendenceRepository.Update(entity);
                    _AttendenceRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
