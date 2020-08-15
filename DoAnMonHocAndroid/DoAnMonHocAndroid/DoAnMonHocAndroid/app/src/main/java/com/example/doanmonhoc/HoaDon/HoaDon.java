package com.example.doanmonhoc.HoaDon;

import java.io.Serializable;
import java.util.Date;

public class HoaDon implements Serializable {
    String mahd,masp,makh;
    Double dongia;
    int soluong;
    String donvitinh;
    Double thanhtien;
    public HoaDon() {
    }

    public HoaDon(String mahd, String masp, String makh, Double dongia, int soluong, String donvitinh, Double thanhtien) {
        this.mahd = mahd;
        this.masp = masp;
        this.makh = makh;
        this.dongia = dongia;
        this.soluong = soluong;
        this.donvitinh = donvitinh;
        this.thanhtien = thanhtien;
    }

    public String getMahd() {
        return mahd;
    }

    public void setMahd(String mahd) {
        this.mahd = mahd;
    }

    public String getMasp() {
        return masp;
    }

    public void setMasp(String masp) {
        this.masp = masp;
    }

    public String getMakh() {
        return makh;
    }

    public void setMakh(String makh) {
        this.makh = makh;
    }

    public Double getDongia() {
        return dongia;
    }

    public void setDongia(Double dongia) {
        this.dongia = dongia;
    }

    public int getSoluong() {
        return soluong;
    }

    public void setSoluong(int soluong) {
        this.soluong = soluong;
    }

    public String getDonvitinh() {
        return donvitinh;
    }

    public void setDonvitinh(String donvitinh) {
        this.donvitinh = donvitinh;
    }

    public Double getThanhtien() {
        return thanhtien;
    }

    public void setThanhtien(Double thanhtien) {
        this.thanhtien = thanhtien;
    }
}
