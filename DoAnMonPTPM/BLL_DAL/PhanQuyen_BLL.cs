using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
  public  class PhanQuyen_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        public PhanQuyen_BLL() { }

        public IQueryable<CTPHANQUYEN> LoadChucNang_PhanQuyen_BLL(string maphanquyen)
        {
            return qlch.CTPHANQUYENs.Where(s => s.MAPHANQUYEN == maphanquyen);
            // return qlch.CTPHANQUYENs.Where(s => (s.MAPHANQUYEN == maphanquyen)).Select(n => n.MACHUCNANG).ToList();
        }

        //load combobox phân quyền
        public IQueryable<PHANQUYEN> LoadcboPhanQuyen_BLL()
        {
            return qlch.PHANQUYENs.Select(k => k);
        }
    }
}
