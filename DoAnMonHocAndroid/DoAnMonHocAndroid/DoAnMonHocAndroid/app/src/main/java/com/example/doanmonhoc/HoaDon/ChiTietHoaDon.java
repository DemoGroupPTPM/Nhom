package com.example.doanmonhoc.HoaDon;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import com.example.doanmonhoc.KhachHnag.KhachHang;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.ChiTiet_SP;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangSuaSanPham;
import com.example.doanmonhoc.SanPham.sanpham;

import java.util.ArrayList;

public class ChiTietHoaDon extends AppCompatActivity {
    TextView mahd,donvitinh,dongia,thanhtien,soluong,ngaylap;
    TextView masp,makh;
    ArrayList<sanpham> mangSP= new ArrayList<>();
    ArrayAdapter<SanPham_Adapter> customadapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chitiet_hoadon);

        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Chi Tiết Hóa Đơn");

        mahd= (TextView) findViewById(R.id.CTHD_mahd);
       masp = (TextView) findViewById(R.id.CTHD_MASP);
        makh =(TextView) findViewById(R.id.CTHD_MALOAI);
        dongia = (TextView) findViewById(R.id.cthd_dongia);
        soluong = (TextView) findViewById(R.id.cthd_sl);
        donvitinh = (TextView) findViewById(R.id.dvtCTHD);
        thanhtien = (TextView) findViewById(R.id.CTHD_thanhtien);

//        Intent intent = getIntent();
//        HoaDon sp = (HoaDon) intent.getSerializableExtra("hoadon");
//        String mahhd= sp.getMahd();
//        String massp = sp.getMasp();
//        String makkh = sp.getMakh();
//        String gia = String.valueOf(sp.getDongia());
//        String sl = String.valueOf(sp.getMasp());
//        String dvt = sp.getDonvitinh();
//        String tt = String.valueOf(sp.getThanhtien());




        Bundle sp = getIntent().getBundleExtra("hoadon");

        String mahhd= sp.getString("mahd");
        String massp = sp.getString("masp");
        String makkh = sp.getString("makhachhang");
        String gia =sp.getString("dongia");
        String sl = sp.getString("soluong");
        String dvt = sp.getString("donvitinh");
        String tt = sp.getString("thanhtien");

        mahd.setText(mahhd);
        makh.setText(makkh);
        masp.setText(massp);
        dongia.setText(gia);
        soluong.setText(sl);
        donvitinh.setText(dvt);
        thanhtien.setText(tt);
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.nut_sua,menu);
        return true;
    }
    //này để tạo nút back ngay actionbar
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home: {
                onBackPressed();
                return true;
            }
            case R.id.nutsuasp: {
                Intent i = new Intent(ChiTietHoaDon.this, TrangSuaHD.class);
                startActivity(i);
                break;
            }
            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }
}
