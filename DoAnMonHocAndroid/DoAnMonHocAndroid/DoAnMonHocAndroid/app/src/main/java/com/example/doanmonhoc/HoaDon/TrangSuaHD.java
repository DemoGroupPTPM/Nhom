package com.example.doanmonhoc.HoaDon;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

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
import com.example.doanmonhoc.SanPham.sanpham;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class TrangSuaHD extends AppCompatActivity {
    ArrayList<HoaDon> mangHD;
    TextView mahd,donvitinh,dongia,thanhtien,soluong,ngaylap;
    TextView masp,makh;
    String url2="http://10.160.90.109:5000/api/ChiTietHoaDons" ;
    //   String ma;
    HoaDon_Adapter customApdater;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trang_sua_san_pham);
        mahd = findViewById(R.id.them_mahd);
        // masp = findViewById(R.id.them_spMaSP_HD);
        makh = findViewById(R.id.them_spKH_HD);
        dongia = findViewById(R.id.them_dongia_HD);
        soluong = findViewById(R.id.them_sl_HD);
        donvitinh = findViewById(R.id.themDVTHD);
        thanhtien = findViewById(R.id.themThanhTien_HD);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Sửa Hóa Đơn");
        Intent intent = getIntent();
        HoaDon sp = (HoaDon) intent.getSerializableExtra("hoadon");


        String mahhd= sp.getMahd();
     //   String massp = sp.getMasp();
         String makkh = sp.getMakh();
        String gia = String.valueOf(sp.getDongia());
        String sl = String.valueOf(sp.getMasp());
        String dvt = sp.getDonvitinh();
        String tt = String.valueOf(sp.getThanhtien());


        mahd.setText(mahhd);
        makh.setText(makkh);
    //    masp.setText(massp);
        dongia.setText(gia+"");
        soluong.setText(sl+ "");
        donvitinh.setText(dvt);
        thanhtien.setText(tt+"");

    }
    //tạo nút lưu
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.nut_luu,menu);
        return true;
    }
    //xử lsy sự kiện nè , nút lưu và thoát xử lý ở đây nhé
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home: {
                onBackPressed();
                return true;
            }
            case R.id.luusp: {

//                AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaSanPham.this);
//                builder.setTitle("Thông báo");
//                builder.setMessage("Bạn có chắc chắn muốn thêm sản phẩm ?");
//                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
//                    @Override
//                    public void onClick(DialogInterface dialog, int which) {
//                        // insertSP();
                //  putData(url2);
                confirmEdit((mahd.getText().toString()));
                //chuyển về list sp để xem sp
                Intent intent = new Intent(TrangSuaHD.this, HoaDon_List.class);
                startActivity(intent);
//                    }
//                });
//                builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
//                    @Override
//                    public void onClick(DialogInterface dialog, int which) {
//                        finish();
//                    }
//                });
//                builder.show();
                return  true;
            }
            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }
    public void getHD()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaHD.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url2, null, new Response.Listener<JSONArray>() {
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
    private void confirmEdit( final String id)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaHD.this);
        builder.setTitle("Cảnh báo");
        builder.setMessage("Bạn có thật sự muốn sửa: "+id +" ?");
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                editStudent(id);
            }
        });
        builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                editStudent(id);
            }
        });
        builder.show();
    }
    public  void editStudent(final String id)
    {
        String url2="http://10.160.90.109:5000/api/ChiTietHoaDons/"+id+"";
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaHD.this);
        StringRequest insertRequest = new StringRequest(Request.Method.PUT, url2, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                if(response.equals("true"))
                    getHD();
                    Toast.makeText(TrangSuaHD.this,response+ " Sua thanh cong",Toast.LENGTH_LONG).show();
                Log.e("response_det", response);

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("response_det", "" + error.getMessage() + "," + error.toString());
            }
        }) {
            @Override
            protected Map<String, String> getParams() throws AbstractMethodError {
                Map<String, String> params = new HashMap<String, String>();
                // String maloait = object.getString("maloai");
                String mahdd= mahd.getText().toString();
//            String maspp= masp.getSelectedItem().toString();
                // String makhh = makh.getSelectedItem().toString();
                // String maloait = object.getString("maloai");
                //String hinhanht = object.getString("hinhanh");
                String dong = dongia.getText().toString();
                //String mancct = object.getString("mancc");
                String sl =  soluong.getText().toString();
                String dvt = donvitinh.getText().toString();
                String tt = thanhtien.getText().toString();

                params.put("mahd",mahdd);
                //    object.put("masp",maspp);
                //   object.put("makhachhang",makhh);
                params.put("dongia",dong);
                params.put("soluong",sl);
                params.put("donvitinh",dvt);
                params.put("thanhtien",tt);


                return params;

            }

        };
        requestQueue.add(insertRequest);
    }
}
