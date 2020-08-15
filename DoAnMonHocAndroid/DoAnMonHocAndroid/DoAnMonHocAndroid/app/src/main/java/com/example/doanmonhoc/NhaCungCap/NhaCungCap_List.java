package com.example.doanmonhoc.NhaCungCap;

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
import com.example.doanmonhoc.KhachHnag.KhachHang;
import com.example.doanmonhoc.KhachHnag.KhachHang_Adapter;
import com.example.doanmonhoc.KhachHnag.KhachHang_List;
import com.example.doanmonhoc.R;


import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;
import com.example.doanmonhoc.TrangThongBao;
import com.google.android.material.tabs.TabLayout;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class NhaCungCap_List extends AppCompatActivity {

    TabLayout tabLayout;
    ViewPager viewPagerHome;
    TextView mancc,tenncc,diachi,sdt,chuthich;
    String url ="http://10.160.90.109:5000/api/NhaCungCaps";
    ListView lv;
    ArrayList<NhaCungCap> mangNCC;
    NhaCungCap_Adapter customApdater;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_ncc_list);
        mangNCC =new ArrayList<>();
        lv=(ListView) findViewById(R.id.List_ncc);

        mancc = (TextView)findViewById(R.id.txtMaNCC);
        tenncc=(TextView)findViewById(R.id.txtTenNCC);
        diachi=(TextView)findViewById(R.id.txtDC);
        sdt=(TextView)findViewById(R.id.txtSDT);
        chuthich=(TextView)findViewById(R.id.txtCT);

       getNCC();
       customApdater = new NhaCungCap_Adapter(NhaCungCap_List.this,R.layout.custom_nhacungcap,mangNCC);
        lv.setAdapter(customApdater);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Nhà Cung Cấp");
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
                ArrayList<NhaCungCap> kh = new ArrayList<>();
                for (NhaCungCap x : mangNCC)
                {
                    if (x.tenncc.contains(newText))
                        kh.add(x);
                }
                ((NhaCungCap_Adapter) lv.getAdapter()).update(kh);
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

            case R.id.themsp:
            {
                Intent i = new Intent(NhaCungCap_List.this, TrangThemNhaCungCap.class);
                startActivity(i);
                break;
            }
            case R.id.thongbao:
            {
                Intent  i = new Intent(NhaCungCap_List.this, TrangThongBao.class);
                startActivity(i);
                break;
            }
            default:break;
        }

        return super.onOptionsItemSelected(item);
    }

    public void getNCC()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(NhaCungCap_List.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangNCC.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);
                        String makht = object.getString("mancc");
                        String tenkht = object.getString("tenncc");
                        String diachit = object.getString("diachi");
                        String dienthoait = object.getString("dienthoai");
                        String emailt = object.getString("chuthich");


                        // mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc, dongia,soluong));
                        mangNCC.add(new NhaCungCap(makht,tenkht,diachit,dienthoait,emailt));
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

        String url ="http://10.160.90.109:5000/api/NhaCungCaps/"+ma+"";

        StringRequest deleteRequest = new StringRequest(Request.Method.DELETE, url,
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response on Success
                        Log.d("Response", response);
                        getNCC();
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
