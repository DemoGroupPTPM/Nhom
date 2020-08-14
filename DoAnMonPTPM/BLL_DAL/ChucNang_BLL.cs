using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
  public  class ChucNang_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        public ChucNang_BLL() { }


        // load tên chức năng bên trang quản lý nhân viên
        public IQueryable<CHUCNANG> LoadTenChucNang_BLL(string maphanquyen)
        {
            return qlch.CHUCNANGs.Where(s => (s.MACHUCNANG == maphanquyen));
        }
    }
}
