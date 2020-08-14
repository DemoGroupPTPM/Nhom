package com.example.doanmonhoc.BaoHanh;

import net.sourceforge.jtds.jdbc.DateTime;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class BaoHanh implements Serializable {
    String mabh,makh,masp,yeucau,tinhtrang;
    Date ngaynhan,ngaytra;

    public BaoHanh() {
    }

    public BaoHanh(String mabh, String makh, String masp, String yeucau, String tinhtrang, Date ngaynhan, Date ngaytra) {
        this.mabh = mabh;
        this.makh = makh;
        this.masp = masp;
        this.yeucau = yeucau;
        this.tinhtrang = tinhtrang;
        this.ngaynhan = ngaynhan;
        this.ngaytra = ngaytra;
    }

    public String getMabh() {
        return mabh;
    }

    public void setMabh(String mabh) {
        this.mabh = mabh;
    }

    public String getMakh() {
        return makh;
    }

    public void setMakh(String makh) {
        this.makh = makh;
    }

    public String getMasp() {
        return masp;
    }

    public void setMasp(String masp) {
        this.masp = masp;
    }

    public String getYeucau() {
        return yeucau;
    }

    public void setYeucau(String yeucau) {
        this.yeucau = yeucau;
    }

    public String getTinhtrang() {
        return tinhtrang;
    }

    public void setTinhtrang(String tinhtrang) {
        this.tinhtrang = tinhtrang;
    }

    public Date getNgaynhan() {
        return ngaynhan;
    }

    public void setNgaynhan(Date ngaynhan) {
        this.ngaynhan = ngaynhan;
    }

    public Date getNgaytra() {
        return ngaytra;
    }

    public void setNgaytra(Date ngaytra) {
        this.ngaytra = ngaytra;
    }
    /**
     * lấy định dạng ngày
     * @param d
     * @return
     */
    public String getDateFormat(Date d)
    {
        SimpleDateFormat dft=new
                SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
        return dft.format(d);
    }

}
