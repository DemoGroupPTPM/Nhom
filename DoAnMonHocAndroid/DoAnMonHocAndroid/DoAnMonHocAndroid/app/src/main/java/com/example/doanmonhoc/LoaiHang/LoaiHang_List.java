package com.example.doanmonhoc.LoaiHang;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
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
import com.example.doanmonhoc.NhaCungCap.NhaCungCap;
import com.example.doanmonhoc.NhaCungCap.NhaCungCap_Adapter;
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

public class LoaiHang_List extends AppCompatActivity {

    TabLayout tabLayout;
    ViewPager viewPagerHome;

    TextView maloai, tenloai; ;
    String url ="http://10.160.90.109:5000/api/LoaiHangs";
    ListView lv;
    ArrayList<LoaiHang> mangLH;
    LoaiHang_Adapter customApdater;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_loaihang_list);
        lv=(ListView) findViewById(R.id.List_loaihang);
        maloai = (TextView) findViewById(R.id.txtMaLoai);
        tenloai = (TextView) findViewById(R.id.txtTenLoai);


        mangLH =new ArrayList<>();
      getLoaiHang();

        customApdater = new LoaiHang_Adapter(LoaiHang_List.this, R.layout.custom_loaihang, mangLH);
        lv.setAdapter(customApdater);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Loại Hàng");
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
                ArrayList<LoaiHang> kh = new ArrayList<>();
                for (LoaiHang x : mangLH)
                {
                    if (x.tenloai.contains(newText))
                        kh.add(x);
                }
                ((LoaiHang_Adapter) lv.getAdapter()).update(kh);
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
                Intent i = new Intent(LoaiHang_List.this, TrangThemLoaiHang.class);
                startActivity(i);
                break;
            }
            case R.id.thongbao:
            {

                break;
            }
        }
        return super.onOptionsItemSelected(item);
    }

    public void getLoaiHang()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(LoaiHang_List.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangLH.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);

                        String maloait = object.getString("maloai");
                        String tenloait = object.getString("tenloai");

                       mangLH.add(new LoaiHang(maloait,tenloait));

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
    public void deleteLH(final String ma)
    {

        String url ="http://10.160.90.109:5000/api/LoaiHangs/"+ma+"";

        StringRequest deleteRequest = new StringRequest(Request.Method.DELETE, url,
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response on Success
                        Log.d("Response", response);
                        getLoaiHang();
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
