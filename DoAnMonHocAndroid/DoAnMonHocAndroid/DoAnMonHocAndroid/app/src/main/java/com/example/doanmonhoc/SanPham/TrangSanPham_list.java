package com.example.doanmonhoc.SanPham;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.AppCompatSpinner;
import androidx.appcompat.widget.SearchView;
import androidx.core.view.GravityCompat;
import androidx.viewpager.widget.ViewPager;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.LoaiHang.LoaiHang;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.TrangChuActivity;
import com.example.doanmonhoc.TrangThongBao;
import com.google.android.material.tabs.TabLayout;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class TrangSanPham_list extends AppCompatActivity {
    SanPham_Adapter sanPham_adapter;
    TabLayout tabLayout;
    ViewPager viewPagerHome;
    TextView tensp, masanpham,baohanh;
    SearchView searchView;
    private AppCompatSpinner spLoaihang;
    String url ="http://10.160.90.109:5000/api/Sanphams";
    ListView lv;
    ArrayList<sanpham> mangSP;
    SanPham_Adapter customApdater;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trang_san_pham_list);

        anhXa();
        //spinner
        spLoaihang= findViewById(R.id.spLoaiHang);
        ArrayList<LoaiHang> loaiHangArrayList = new ArrayList<>();


        mangSP =new ArrayList<>();
        getSanPham();

        customApdater = new SanPham_Adapter(TrangSanPham_list.this,mangSP,R.layout.custom_sanpham);
        lv.setAdapter(customApdater);
        //menu contexxt
        registerForContextMenu(lv);
       
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Sản Phẩm");


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
                Intent i = new Intent(TrangSanPham_list.this,TrangSuaSanPham.class);
                i.putExtra("sanpham",mangSP.get(info.position));
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
        MenuItem menuItem = menu.findItem(R.id.thongbao);
        SearchView searchView = (SearchView) menuItem.getActionView();
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                ArrayList<sanpham> hi = new ArrayList<>();
                for (sanpham x : mangSP)
                {
                    if (x.tenhang.contains(newText))
                        hi.add(x);
                }
                ((SanPham_Adapter) lv.getAdapter()).update(hi);
                return false;
            }
        });
        return true;
       // return super.onCreateOptionsMenu(menu);
    }



    //này dùng để bắt sự kiện cho cái nút mũi tên quay lại
    //nút mũi tên đó có mặc định là R.id.home
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
                    Intent  i = new Intent(TrangSanPham_list.this,TrangThemSP_SanPham.class);
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
    private void anhXa() {
        lv=(ListView) findViewById(R.id.List_sanpham);
       tensp = (TextView) findViewById(R.id.txtTenSP);
        baohanh = (TextView) findViewById(R.id.txtBH);
        masanpham = (TextView) findViewById(R.id.txtMaSP);

    }

    public void getSanPham()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSanPham_list.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangSP.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);
                        String masp = object.getString("masp");
                        String maloai = object.getString("maloai");
                        String tenhang = object.getString("tenhang");
                        String hinhanh = object.getString("hinhanh");
                        String baohanh = object.getString("baohanh");
                        String mancc = object.getString("mancc");
                        double dongia = object.getDouble("dongia");
                        int soluong = object.getInt("soluong");

                       // mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc, dongia,soluong));
                        mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc,dongia,soluong));
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

        String url ="http://10.160.90.109:5000/api/Sanphams/"+ma+"";

        StringRequest deleteRequest = new StringRequest(Request.Method.DELETE, url,
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response on Success
                        Log.d("Response", response);
                        getSanPham();
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