package com.example.doanmonhoc.SanPham;

import java.io.Serializable;
import java.text.DecimalFormat;

public class sanpham implements Serializable {
    String masp, maloai, tenhang, hinhanh, baohanh, mancc;
    double dongia;
    int soluong;

    public sanpham() {
    }

    public sanpham(String masp, String maloai, String tenhang, String hinhanh, String baohanh, String mancc, double dongia, int soluong) {
        this.masp = masp;
        this.maloai = maloai;
        this.tenhang = tenhang;
        this.hinhanh = hinhanh;
        this.baohanh = baohanh;
        this.mancc = mancc;
        this.dongia = dongia;
        this.soluong = soluong;
    }

    public String getMasp() {
        return masp;
    }

    public void setMasp(String masp) {
        this.masp = masp;
    }

    public String getMaloai() {
        return maloai;
    }

    public void setMaloai(String maloai) {
        this.maloai = maloai;
    }

    public String getTenhang() {
        return tenhang;
    }

    public void setTenhang(String tenhang) {
        this.tenhang = tenhang;
    }

    public String getHinhanh() {
        return hinhanh;
    }

    public void setHinhanh(String hinhanh) {
        this.hinhanh = hinhanh;
    }

    public String getBaohanh() {
        return baohanh;
    }

    public void setBaohanh(String baohanh) {
        this.baohanh = baohanh;
    }

    public String getMancc() {
        return mancc;
    }

    public void setMancc(String mancc) {
        this.mancc = mancc;
    }

    public double getDongia() {
        return dongia;
    }

    public void setDongia(double dongia) {
        this.dongia = dongia;
    }

    public int getSoluong() {
        return soluong;
    }

    public void setSoluong(int soluong) {
        this.soluong = soluong;
    }
}
