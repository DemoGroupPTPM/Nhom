package com.example.doanmonhoc.KhachHnag;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
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
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;
import com.example.doanmonhoc.SanPham.sanpham;
import com.example.doanmonhoc.TrangThongBao;
import com.google.android.material.tabs.TabLayout;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class KhachHang_List extends AppCompatActivity {
    KhachHang_Adapter khachHang_adapter;
    TabLayout tabLayout;
    ViewPager viewPagerHome;
    TextView  makh,tenkh,diachi,dienthoai,email;
    String url ="http://10.160.90.109:5000/api/KhachHangs";
    ListView lv;
    ArrayList<KhachHang> mangKH;
    KhachHang_Adapter customApdater;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_khachhang_list);
        mangKH =new ArrayList<>();
        lv=(ListView) findViewById(R.id.List_Khachhang);
        makh = (TextView) findViewById(R.id.txtMaKH);
        tenkh = (TextView) findViewById(R.id.txtTenKH);
        diachi = (TextView) findViewById(R.id.txtDCKH);
        dienthoai = (TextView) findViewById(R.id.txtSDTKH);
        email = (TextView) findViewById(R.id.txtemailKH);
        getKhachHang();

        customApdater = new KhachHang_Adapter(KhachHang_List.this, R.layout.custom_khachhang, mangKH);
        lv.setAdapter(customApdater);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Khách Hàng");
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.option_sanpham,menu);
        MenuItem menuItem = menu.findItem(R.id.thongbao);
        SearchView searchView = (SearchView) menuItem.getActionView();
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                ArrayList<KhachHang> kh = new ArrayList<>();
                for (KhachHang x : mangKH)
                {
                    if (x.tenkh.contains(newText))
                        kh.add(x);
                }
                ((KhachHang_Adapter) lv.getAdapter()).update(kh);
                return false;
            }
        });
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
                Intent i = new Intent(KhachHang_List.this, TrangThemKhachHang.class);
                startActivity(i);
                break;
            }
            case R.id.thongbao:
            {
                Intent  i = new Intent(KhachHang_List.this, TrangThongBao.class);
                startActivity(i);
                break;
            }
        }


        return super.onOptionsItemSelected(item);
    }

    public void getKhachHang()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(KhachHang_List.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangKH.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);
                        String makht = object.getString("makhachhang");
                        String tenkht = object.getString("tenkhachhang");
                        String diachit = object.getString("diachi");
                        String dienthoait = object.getString("dienthoai");
                        String emailt = object.getString("email");


                        // mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc, dongia,soluong));
                        mangKH.add(new KhachHang(makht,tenkht,diachit,dienthoait,emailt));
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
    public void deleteSP(final String ma)
    {

        String url ="http://10.160.90.109:5000/api/KhachHangs/"+ma+"";

        StringRequest deleteRequest = new StringRequest(Request.Method.DELETE, url,
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response on Success
                        Log.d("Response", response);
                        getKhachHang();
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
}
