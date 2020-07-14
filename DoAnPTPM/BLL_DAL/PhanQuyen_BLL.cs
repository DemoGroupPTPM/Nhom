using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
     public class PhanQuyen_BLL
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public PhanQuyen_BLL() { }

        public IQueryable<CTPHANQUYEN> LoadChucNang_PhanQuyen_BLL(string maphanquyen)
        {
            return qlch.CTPHANQUYENs.Where(s => (s.MAPHANQUYEN == maphanquyen));
        }

        //load combobox phân quyền
        public IQueryable<PHANQUYEN> LoadcboPhanQuyen_BLL()
        {
            return qlch.PHANQUYENs.Select(k => k);
        }

    }
}
