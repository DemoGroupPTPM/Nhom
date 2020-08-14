using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
  public  class NhomHang_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();

        public NhomHang_BLL() { }

        public IQueryable<NHOMHANG> LoadNhomHang_BLL()
        {
            return qlch.NHOMHANGs.Select(n => n);
        }
    }
}
