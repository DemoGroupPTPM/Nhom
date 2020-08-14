package com.example.doanmonhoc.NhaCungCap;

import java.io.Serializable;

public class NhaCungCap implements Serializable {
    String mancc, tenncc, diachi,dienthoai,chuthich;

    public NhaCungCap() {
    }

    public NhaCungCap(String mancc, String tenncc, String diachi, String dienthoai, String chuthich) {
        this.mancc = mancc;
        this.tenncc = tenncc;
        this.diachi = diachi;
        this.dienthoai = dienthoai;
        this.chuthich = chuthich;
    }

    public String getMancc() {
        return mancc;
    }

    public void setMancc(String mancc) {
        this.mancc = mancc;
    }

    public String getTenncc() {
        return tenncc;
    }

    public void setTenncc(String tenncc) {
        this.tenncc = tenncc;
    }

    public String getDiachi() {
        return diachi;
    }

    public void setDiachi(String diachi) {
        this.diachi = diachi;
    }

    public String getDienthoai() {
        return dienthoai;
    }

    public void setDienthoai(String dienthoai) {
        this.dienthoai = dienthoai;
    }

    public String getChuthich() {
        return chuthich;
    }

    public void setChuthich(String chuthich) {
        this.chuthich = chuthich;
    }
}
