package com.example.doanmonhoc.LoaiHang;

import java.io.Serializable;

public class LoaiHang implements Serializable {
        public String maloai,manhom,tenloai;

    public LoaiHang() {
    }
    public LoaiHang(String maloai) {
        this.maloai = maloai;
    }
    public LoaiHang(String maloai, String manhom, String tenloai) {
        this.maloai = maloai;
        this.manhom = manhom;
        this.tenloai = tenloai;
    }

    public String getMaloai() {
        return maloai;
    }

    public void setMaloai(String maloai) {
        this.maloai = maloai;
    }

    public String getManhom() {
        return manhom;
    }

    public void setManhom(String manhom) {
        this.manhom = manhom;
    }

    public String getTenloai() {
        return tenloai;
    }

    public void setTenloai(String tenloai) {
        this.tenloai = tenloai;
    }
}
