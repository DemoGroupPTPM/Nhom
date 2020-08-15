package com.example.doanmonhoc.LoaiHang;

import java.io.Serializable;

public class LoaiHang implements Serializable {
        String maloai,tenloai;

    public LoaiHang() {
    }

    public LoaiHang(String maloai, String tenloai) {
        this.maloai = maloai;
        this.tenloai = tenloai;
    }

    public String getMaloai() {
        return maloai;
    }

    public void setMaloai(String maloai) {
        this.maloai = maloai;
    }

    public String getTenloai() {
        return tenloai;
    }

    public void setTenloai(String tenloai) {
        this.tenloai = tenloai;
    }
}
