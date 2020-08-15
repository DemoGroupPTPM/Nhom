package com.example.doanmonhoc.HoaDon;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.viewpager.widget.ViewPager;


import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.doanmonhoc.SanPham.TrangSuaSanPham;
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;
import com.example.doanmonhoc.SanPham.sanpham;
import com.example.doanmonhoc.TrangThongBao;
import com.google.android.material.tabs.TabLayout;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Date;

public class HoaDon_List extends AppCompatActivity {
    HoaDon_Adapter hoaDon_adapter;
    TabLayout tabLayout;
    ViewPager viewPagerHome;
    TextView mahd,makh,masp,ngaylap,thanhtien;
    String url ="http://10.160.90.109:5000/api/ChiTietHoaDons";
    ListView lv;
    ArrayList<HoaDon> mangHD;
    HoaDon_Adapter customApdater;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hoadon_list);

        anhXa();
        mangHD =new ArrayList<>();
        getHD();
      //  mahd = findViewById(R.i)

        customApdater = new HoaDon_Adapter(HoaDon_List.this,R.layout.custom_hoadon, mangHD);
        lv.setAdapter(customApdater);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Hóa Đơn");
        registerForContextMenu(lv);
    }
    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater= getMenuInflater();
        inflater.inflate(R.menu.context_menu,menu);
    }

    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        AdapterView.AdapterContextMenuInfo info= (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();

        switch (item.getItemId())
        {
            case R.id.edit:
            {
                Intent i = new Intent(HoaDon_List.this, TrangSuaHD.class);
                i.putExtra("hoadon",mangHD.get(info.position));
                startActivity(i);

                break;
            }

//            case R.id.delete:
//            {
//
//                break;
//            }

        }
        return super.onContextItemSelected(item);
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.option_sanpham,menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId())
        {
            case android.R.id.home:
            {
                onBackPressed();
                return true;
            }
            default:break;
            case R.id.themsp:
            {
                Intent i = new Intent(HoaDon_List.this, TrangThemHD.class);
                startActivity(i);
                break;
            }
            case R.id.thongbao:
            {
                Intent  i = new Intent(HoaDon_List.this, TrangSuaHD.class);
                startActivity(i);
                break;
            }
        }

        return super.onOptionsItemSelected(item);
    }
    public void getHD()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(HoaDon_List.this);
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


                         mangHD.add(new HoaDon(mahdd,maspp,makhh,dongia,soluong,dvt, tt));
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
    public void deleteHD(final String ma)
    {

        String url ="http://10.160.90.109:5000/api/ChiTietHoaDons/"+ma+"";

        StringRequest deleteRequest = new StringRequest(Request.Method.DELETE, url,
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response on Success
                        Log.d("Response", response);
                        getHD();
                    }
                },
                new Response.ErrorListener()
                {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // error
                        // Log.d("Error.Response", error.getMessage());
                        Log.e("response_det", "" + error.getMessage() + "," + error.toString());
                    }
                }
        );
        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        queue.add(deleteRequest);
        //getStudentData();
    }
    private void anhXa() {
        lv=(ListView) findViewById(R.id.List_HD);
        mahd = (TextView) findViewById(R.id.HD_MaHD);
        makh = (TextView) findViewById(R.id.HD_tenKH);
        thanhtien = (TextView) findViewById(R.id.HD_TongTien);

    }
}
