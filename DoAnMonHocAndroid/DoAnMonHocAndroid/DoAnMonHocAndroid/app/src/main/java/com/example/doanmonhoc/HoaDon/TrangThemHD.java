package com.example.doanmonhoc.HoaDon;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.viewpager.widget.ViewPager;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.KhachHnag.KhachHang;
import com.example.doanmonhoc.KhachHnag.KhachHang_List;
import com.example.doanmonhoc.KhachHnag.TrangThemKhachHang;
import com.example.doanmonhoc.R;
import com.google.android.material.tabs.TabLayout;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class TrangThemHD extends AppCompatActivity {

    HoaDon_Adapter hoaDon_adapter;
    TabLayout tabLayout;
    ViewPager viewPagerHome;
    TextView mahd,donvitinh,dongia,thanhtien,soluong,ngaylap;
    TextView masp,makh;
    String url ="http://10.160.90.109:5000/api/ChiTietHoaDons";
    ListView lv;
    ArrayList<HoaDon> mangHD;
    HoaDon_Adapter customApdater;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_them_hoadon);

        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Thêm Hóa Đơn");

//        masp = (EditText) findViewById(R.id.edit_mahang) ;
//        tensp = (EditText) findViewById(R.id.edit_tenhang);
//        giaban =(EditText) findViewById(R.id.edit_them_gia) ;
//        soluong = (EditText) findViewById( R.id.edit_them_soluong);
//        baohanh = (EditText) findViewById(R.id.edit_them_baohanh) ;
        mahd = findViewById(R.id.them_mahd);
        masp = findViewById(R.id.them_spMaSP_HD);
        makh = findViewById(R.id.them_spKH_HD);
       dongia = findViewById(R.id.them_dongia_HD);
       soluong = findViewById(R.id.them_sl_HD);
       donvitinh = findViewById(R.id.themDVTHD);
       thanhtien = findViewById(R.id.themThanhTien_HD);

    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.nut_luu,menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home: {
                onBackPressed();
                return true;

            }
            case R.id.luusp: {

                AlertDialog.Builder builder = new AlertDialog.Builder(TrangThemHD.this);
                builder.setTitle("Thông báo");
                builder.setMessage("Bạn có chắc chắn muốn thêm hóa đơn ?");
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // insertSP();
                        insertKH();
                        //chuyển về list sp để xem sp
                        Intent intent = new Intent(TrangThemHD.this, HoaDon_List.class);
                        startActivity(intent);
                    }
                });
                builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        finish();
                    }
                });
                builder.show();
                return  true;
            }
            default:
                break;

        }
        return super.onOptionsItemSelected(item);
    }
    public void getHD()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangThemHD.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangHD.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);
                        String mahdd = object.getString("mahd");
                        String maspp = object.getString("masp");
                        String makhh = object.getString("makhachhang");
                        double dongia = object.getDouble("dongia");
                        int soluong = object.getInt("soluong");
                        String dvt = object.getString("donvitinh");
                        double tt = object.getDouble("thanhtien");


                        mangHD.add(new HoaDon(mahdd,maspp,makhh,dongia,soluong,dvt,tt));
                        //    mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc,dongia,soluong));
                        //Toast.makeText(TrangSanPham_list.this,"hello"+response,Toast.LENGTH_LONG).show();
                        Log.d("AAA",""+response);
                        customApdater.notifyDataSetChanged();


                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("AAA",""+error);
            }
        });
        requestQueue.add(jsonArrayRequest);
    }
    public void insertKH() {
        final ProgressDialog loading = new ProgressDialog(TrangThemHD.this);
        loading.setMessage("vui lòng đợi ...");
        loading.setCanceledOnTouchOutside(false);
        loading.show();
        String url2 ="http://10.160.90.109:5000/api/ChiTietHoaDons";
        JSONObject object = new JSONObject();
        try {
            String mahdd= mahd.getText().toString();
            String maspp= masp.getText().toString();
            String makhh = makh.getText().toString();
            String dong = dongia.getText().toString();
            String sl =  soluong.getText().toString();
            String dvt = donvitinh.getText().toString();
            String tt = thanhtien.getText().toString();

            object.put("mahd",mahdd);
            object.put("masp",maspp);
            object.put("makhachhang",makhh);
            object.put("dongia",dong);
            object.put("soluong",sl);
            object.put("donvitinh",dvt);
            object.put("thanhtien",tt);

        } catch (JSONException e) {
            e.printStackTrace();
        }

        final JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.POST, url2, object, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                try {

                    Log.d("Json", String.valueOf(response));
                    loading.dismiss();
                    String Error = response.getString("httpStatus");
                    if (Error.equals("") || Error.equals("null")) {
                        getHD();
                    } else if (Error.equals("OK")) {
                        JSONObject body = response.getJSONObject("body");
                    } else {

                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    loading.dismiss();
                }
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                loading.dismiss();
                VolleyLog.d("Error","Error: " +  error.getMessage());
                Toast.makeText(TrangThemHD.this,"loi roi", Toast.LENGTH_LONG).show();

            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        requestQueue.add(jsonObjectRequest);
    }
}
