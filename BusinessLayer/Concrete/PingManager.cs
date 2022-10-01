using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PingManager : IPingService
    {
        IPingDal _pingDal;

        public PingManager(IPingDal pingDal)
        {
            _pingDal = pingDal;
        }

        public List<Ping> GetByFilter(Expression<Func<Ping, bool>> filter)
        {
            return _pingDal.GetListByFilter(filter);
        }

        public void TAdd(Ping t)
        {
            _pingDal.Insert(t);
        }

        public void TDelete(Ping t)
        {
            _pingDal.Delete(t);
        }

        public Ping TGetByID(int id)
        {
           return _pingDal.GetByID(id);
        }

        public List<Ping> TGetList()
        {
            return _pingDal.GetList();
        }

        public void TUpdate(Ping t)
        {
            _pingDal.Update(t);
        }
    }
}
