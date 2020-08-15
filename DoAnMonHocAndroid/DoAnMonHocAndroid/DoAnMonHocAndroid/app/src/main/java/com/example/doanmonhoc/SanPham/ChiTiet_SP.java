package com.example.doanmonhoc.SanPham;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class ChiTiet_SP extends AppCompatActivity {
    TextView masp;
    TextView maloai;
    TextView tenhang;
    ImageView hinhanh;
    TextView dongia;
    TextView soluong;
    TextView baohanh;
    TextView mancc;
    Button btnXoa;
    ArrayList<sanpham> mangSP= new ArrayList<>();
    ArrayAdapter<SanPham_Adapter> customadapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chi_tiet__s_p);

        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Chi Tiết Sản Phẩm");

        hinhanh = (ImageView) findViewById(R.id.CTSP_img);

        masp = (TextView) findViewById(R.id.masp);
        maloai =(TextView) findViewById(R.id.loaihang);
        tenhang = (TextView) findViewById(R.id.CTSP_tensp);
        dongia = (TextView) findViewById(R.id.gia);
        soluong = (TextView) findViewById(R.id.CTSP_soluong);
        baohanh = (TextView) findViewById(R.id.CTSP_baohanh);
        mancc = (TextView) findViewById(R.id.CTSP_NCC);


//        bundle.putString("Masp",masp);
//        bundle.putString("Tensp",tensp);
//        bundle.putString("Baohanh",baohanh);
//        bundle.putString("Mancc",mancc);
//        bundle.putString("Maloai",maloai);
//        bundle.putString("dongia",dongia);
//        bundle.putString("soluong",soluong);
//
//        in.putExtra("data",bundle);

        Bundle bundle = getIntent().getBundleExtra("data");
        String masph = bundle.getString("Masp");
        String tensph = bundle.getString("Tensp");
        String baohanhsp = bundle.getString("Baohanh");
        String manccsp = bundle.getString("Mancc");
        String maloaisp = bundle.getString("Maloai");
        String dongiasp = bundle.getString("dongia");
        String soluongsp = bundle.getString("soluong");

        masp.setText(masph);
        tenhang.setText(tensph);
        maloai.setText(maloaisp);
        dongia.setText(dongiasp);
        soluong.setText(soluongsp);
        baohanh.setText(baohanhsp);
        mancc.setText(manccsp);
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
                Intent i = new Intent(ChiTiet_SP.this,TrangSuaSanPham.class);
                startActivity(i);
                break;
            }
            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }
    public void getSanPham()
    {
        String url ="http://192.168.1.108:5000/api/Sanphams";
        RequestQueue requestQueue = Volley.newRequestQueue(ChiTiet_SP.this);
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
                        customadapter.notifyDataSetChanged();


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


}