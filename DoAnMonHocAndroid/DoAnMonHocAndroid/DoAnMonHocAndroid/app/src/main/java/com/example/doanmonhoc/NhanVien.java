package com.example.doanmonhoc;

public class NhanVien {
   String manv;
    String matkhau;
    String tennv;
    String diachi;
    String dienthoai;
    String maphanquyen;
    String chuthich;

 public NhanVien(String manv, String matkhau) {
  this.manv = manv;
  this.matkhau = matkhau;
 }

 public NhanVien(String manv, String matkhau, String dienthoai) {
  this.manv = manv;
  this.matkhau = matkhau;
  this.dienthoai = dienthoai;
 }

 public NhanVien(String manv, String matkhau, String tennv, String diachi, String dienthoai, String maphanquyen, String chuthich) {
  this.manv = manv;
  this.matkhau = matkhau;
  this.tennv = tennv;
  this.diachi = diachi;
  this.dienthoai = dienthoai;
  this.maphanquyen = maphanquyen;
  this.chuthich = chuthich;
 }

 public String getManv() {
  return manv;
 }

 public void setManv(String manv) {
  this.manv = manv;
 }

 public String getMatkhau() {
  return matkhau;
 }

 public void setMatkhau(String matkhau) {
  this.matkhau = matkhau;
 }

 public String getTennv() {
  return tennv;
 }

 public void setTennv(String tennv) {
  this.tennv = tennv;
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

 public String getMaphanquyen() {
  return maphanquyen;
 }

 public void setMaphanquyen(String maphanquyen) {
  this.maphanquyen = maphanquyen;
 }

 public String getChuthich() {
  return chuthich;
 }

 public void setChuthich(String chuthich) {
  this.chuthich = chuthich;
 }
}
