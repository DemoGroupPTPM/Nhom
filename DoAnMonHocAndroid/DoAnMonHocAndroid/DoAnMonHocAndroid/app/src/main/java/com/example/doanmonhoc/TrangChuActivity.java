package com.example.doanmonhoc;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.ActionBarDrawerToggle;
import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;


import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.Toolbar;

import com.example.doanmonhoc.HoaDon.HoaDon_List;
import com.example.doanmonhoc.KhachHnag.KhachHang_List;
import com.example.doanmonhoc.LoaiHang.LoaiHang_List;
import com.example.doanmonhoc.NhaCungCap.NhaCungCap_List;
import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.hoadon.TrangHoaDon_List;
import com.google.android.material.navigation.NavigationView;

public class TrangChuActivity extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener,View.OnClickListener {
    private DrawerLayout mDrawerLayout;
    NavigationView navigationView;
    private ActionBarDrawerToggle mActionBarDrawerToggle;

    private CardView hoadonCard,SPCard,NCCCard,BAOHANHCard,ThongtinCard,ThongBaoCard;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trang_chu);

        mDrawerLayout = findViewById(R.id.main_acti);
        navigationView = findViewById(R.id.nav_view);

        //toolbar
        navigationView.bringToFront();
        // ẩn hoặc hiện item
//        Menu menu= navigationView.getMenu();
//        menu.findItem(R.id.dangxuat).setVisible(false);

        mActionBarDrawerToggle = new ActionBarDrawerToggle(this, mDrawerLayout, R.string.open, R.string.close);
        mDrawerLayout.addDrawerListener(mActionBarDrawerToggle);
        mActionBarDrawerToggle.syncState();
        hoadonCard = findViewById(R.id.hoadon_card);
        SPCard = findViewById(R.id.sanpham_card);
        NCCCard =findViewById(R.id.ncc_card);
        ThongBaoCard=findViewById(R.id.thongbao_card);
        ThongtinCard=findViewById(R.id.thongtin_card);
        BAOHANHCard =findViewById(R.id.baohanh_card);
        //add sự kiệ
        hoadonCard.setOnClickListener(this);
        SPCard.setOnClickListener(this);
        NCCCard.setOnClickListener(this);
        ThongBaoCard.setOnClickListener(this);
        ThongtinCard.setOnClickListener(this);
        BAOHANHCard.setOnClickListener(this);
//toolbar
        //    toolbar = findViewById(R.id.toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        //naviga
        navigationView.setNavigationItemSelectedListener( this);
        navigationView.setCheckedItem(R.id.trangchu);
//dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Trang Chủ");
    }
    @Override
    public void onBackPressed() {
        if (mDrawerLayout.isDrawerOpen(GravityCompat.START))
        {
            mDrawerLayout.closeDrawer(GravityCompat.START);
        }
        else
        {
            super.onBackPressed();
        }

    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {

        mDrawerLayout.openDrawer(GravityCompat.START);
        if (mActionBarDrawerToggle.onOptionsItemSelected(item)) {
            return true;
        }

        // return super.onOptionsItemSelected(item);
        return  true;
    }
    //xử lsy sự kiện khi nhấn vào các thành phần trong thanh menu đứng
    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem item) {
        Intent intent;
        switch (item.getItemId())
        {
            case R.id.trangchu:
                intent= new Intent(this,TrangChuActivity.class);
                startActivity(intent);
                break;
            case R.id.sanpham:
            intent= new Intent(this,TrangSanPham_list.class);
            startActivity(intent);
            break;
            case R.id.khachhang:
                intent= new Intent(this, KhachHang_List.class);
                startActivity(intent);
                break;
            case R.id.ncc:
                intent= new Intent(this, NhaCungCap_List.class);
                startActivity(intent);
                break;
            case R.id.dathang:
                intent= new Intent(this, HoaDon_List.class);
                startActivity(intent);
                break;
            case R.id.dangxuat:
                AlertDialog.Builder builder = new AlertDialog.Builder(TrangChuActivity.this);
                builder.setTitle("Thông báo");
                builder.setMessage("Bạn có chắc chắn muốn thoát ?");
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                        Intent startMain = new Intent(TrangChuActivity.this, TrangDangNhap.class);
                        startActivity(startMain);
                        SharedPreferences preInfo = getSharedPreferences("data", MODE_PRIVATE);
                        SharedPreferences.Editor editInfo = preInfo.edit();
                        editInfo.putBoolean("check", false);
                        editInfo.clear();
                        //editInfo.apply();
                        editInfo.commit();

                        finish();
                    }
                });
                builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                    }
                });
                builder.show();
                break;
        }
        mDrawerLayout.closeDrawer(GravityCompat.START);
        return true;
    }


    @Override
    public void onClick(View view) {
        Intent i;
        switch (view.getId())
        {
            case R.id.hoadon_card : {
                i = new Intent(this, HoaDon_List.class);
                startActivity(i);
                break;
            }

            case R.id.sanpham_card : {
                i = new Intent(this, TrangSanPham_list.class);
                startActivity(i);
                break;
            }
            case R.id.ncc_card : {
                i = new Intent(this, NhaCungCap_List.class);
                startActivity(i);
                break;
            }
            case R.id.baohanh_card : {
                i = new Intent(this, LoaiHang_List.class);
                startActivity(i);
                break;
            }
            case R.id.thongbao_card : {
                i = new Intent(this, KhachHang_List.class);
                startActivity(i);
                break;
            }

            case R.id.thongtin_card : {
                i = new Intent(this, TrangInFo.class);
                startActivity(i);
                break;
            }
            default: break;
        }
    }
}