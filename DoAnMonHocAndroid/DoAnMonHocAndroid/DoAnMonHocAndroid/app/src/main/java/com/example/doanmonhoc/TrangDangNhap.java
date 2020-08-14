package com.example.doanmonhoc;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.example.doanmonhoc.SanPham.TrangSanPham_list;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;


public class TrangDangNhap extends AppCompatActivity {
    TextView txtViewForgotPass;
    //ConnectionDB connectionDB;
    EditText txtUser;
    EditText txtPass;
    Button btnLogin;
    ImageButton btnDangKy;
    CheckBox chkghinho;
    public boolean checkghinhodn ;
    SharedPreferences share;
    ArrayList<NhanVien> listNV;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_trang_dang_nhap);
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Đăng Nhập");

        btnDangKy = (ImageButton) findViewById(R.id.btnDangKy_dangnhap) ;
        txtUser = (EditText) findViewById(R.id.edtUserName_dangnhap);
        txtPass = (EditText) findViewById(R.id.edtPass_dangnhap);
        btnLogin = (Button) findViewById(R.id.btnDangNhap_dangnhap);
        chkghinho = (CheckBox) findViewById(R.id.checkGhiNho);

        share = getSharedPreferences("data", MODE_PRIVATE);

        txtUser.setText(share.getString("taikhoan", ""));
        txtPass.setText(share.getString("matkhau", ""));
        chkghinho.setChecked(share.getBoolean("check", false));


        String tendn;
        String matkhau;
        String str_json= null;
        try {
            //đọc file lấy dữ liệu từ file Assets
            InputStream is= getAssets().open("file.json");
            //kiểm tra các luồng dl có kích thước bao nhiêu
            int size = is.available();
            //khai báo bộ nhớ đệm có kt
            byte[] buffer= new  byte[size];
            //đọc dữ liệu
            is.read(buffer);
            //đóng
            is.close();
            //chuyển buffer về string
            str_json= new String(buffer,"UTF-8");
            //Toast.makeText(this,str_json,Toast.LENGTH_SHORT).show();

        }catch (IOException e)
        {
            e.printStackTrace();
        }
        listNV= new ArrayList<NhanVien>();
        try {
            JSONObject jsonObject= new JSONObject(str_json);
            JSONArray jsonArray= jsonObject.getJSONArray("NVs");

            for (int i=0; i<jsonArray.length();i++)
            {
                JSONObject obj= jsonArray.getJSONObject(i);
                 tendn = obj.getString("TenDn");
                matkhau = obj.getString("MatKhau");
               NhanVien nv= new NhanVien(tendn, matkhau);
                listNV.add(nv);
            }
        }catch ( JSONException e)
        {
            e.printStackTrace();
        }
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String user= txtUser.getText().toString();
                String pas= txtPass.getText().toString();

                for(int i =0; i < listNV.size(); i++){
                    if (listNV.get(i).getManv().equals(user) && listNV.get(i).getMatkhau().equals(pas))
                    {
                        Toast.makeText(TrangDangNhap.this,"đăng nhập thành công", Toast.LENGTH_LONG).show();
                        Intent intent = new Intent(TrangDangNhap.this, TrangChuActivity.class);
                        startActivity(intent);
                        SharedPreferences.Editor editor = share.edit();
                        if (chkghinho.isChecked()) {//nếu có check == true
                            //lưu vào file có tên là data

                            editor.putString("taikhoan", user);//nhận 2 giá trị, 1.tên, 2 giá trị
                            editor.putString("matkhau", pas);
                            editor.putBoolean("check", true);
                            editor.commit();// xác nhận
                        } else {

                            editor.remove("taikhoan");
                            editor.remove("matkhau");
                            editor.remove("check");
                            editor.commit();
                        }


                    }
                    else {
                        Toast.makeText(TrangDangNhap.this,"sai tài khoản hoặc mật khẩu", Toast.LENGTH_LONG).show();
                    }
                }
            }
        });

        btnDangKy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(TrangDangNhap.this, TrangDangKy.class);
                startActivity(intent);
            }
        });

        ktdangnhap();
    }

    private void ktdangnhap() {
        boolean kt = share.getBoolean("check", false);
        String tk = share.getString("taikhoan", "");
        String chuyen = getString(R.string.welcome);
        if (kt == true) {
            Toast.makeText(TrangDangNhap.this, chuyen + " " + tk, Toast.LENGTH_LONG).show();
            Intent intent = new Intent(TrangDangNhap.this, TrangChuActivity.class);
            startActivity(intent);
        }
        else {
            Toast.makeText(TrangDangNhap.this, "Mời bạn đăng nhập lại", Toast.LENGTH_SHORT).show();
        }
    }

}