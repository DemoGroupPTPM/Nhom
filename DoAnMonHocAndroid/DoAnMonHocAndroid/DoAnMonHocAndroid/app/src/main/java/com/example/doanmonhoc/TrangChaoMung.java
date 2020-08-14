package com.example.doanmonhoc;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class TrangChaoMung extends AppCompatActivity {
    private static int SPLASH_TIME_OUT = 2000;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trang_chao_mung);
        chaySPLASH();
    }

    void chaySPLASH() {
        // chạy trang splash
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                Intent chaysplash = new Intent(TrangChaoMung.this, TrangDangNhap.class);
                startActivity(chaysplash);
                finish();
            }
        }, SPLASH_TIME_OUT);
    }
}