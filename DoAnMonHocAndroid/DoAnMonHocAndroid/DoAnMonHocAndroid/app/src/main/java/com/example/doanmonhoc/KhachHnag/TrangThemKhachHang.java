package com.example.doanmonhoc.KhachHnag;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;
import com.example.doanmonhoc.SanPham.sanpham;


import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class TrangThemKhachHang extends AppCompatActivity {


    EditText makh,tenkh,diachi,dienthoai,email;
    String url ="http://10.160.90.109:5000/api/KhachHangs";
    Button btnluu;
    ArrayList<KhachHang> mangKH;
    KhachHang_Adapter customApdater;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_them_khachhang);

        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Thêm Khách Hàng");
        //ÁNH XẠ
        makh = (EditText) findViewById(R.id.edit_them_maKH);
        tenkh =  (EditText)findViewById(R.id.edit_them_tenKH);
        diachi = (EditText)findViewById(R.id.edit_them_diachiKH);
        dienthoai = (EditText) findViewById(R.id.edit_them_SDTKH);
        email = (EditText) findViewById(R.id.edit_them_EmailKH);
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

                AlertDialog.Builder builder = new AlertDialog.Builder(TrangThemKhachHang.this);
                builder.setTitle("Thông báo");
                builder.setMessage("Bạn có chắc chắn muốn thêm sản phẩm ?");
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // insertSP();
                        insertKH();
                        //chuyển về list sp để xem sp
                        Intent intent = new Intent(TrangThemKhachHang.this, KhachHang_List.class);
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
    public void getKhachHang()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangThemKhachHang.this);
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
    public void insertKH() {
        final ProgressDialog loading = new ProgressDialog(TrangThemKhachHang.this);
        loading.setMessage("vui lòng đợi ...");
        loading.setCanceledOnTouchOutside(false);
        loading.show();
        String url2 ="http://10.160.90.109:5000/api/KhachHangs";
        JSONObject object = new JSONObject();
        try {
            String makhh = makh.getText().toString();
            // String maloait = object.getString("maloai");
            String tenkhh= tenkh.getText().toString();
            //String hinhanht = object.getString("hinhanh");
            String diachikh = diachi.getText().toString();
            //String mancct = object.getString("mancc");
            String sdt =  dienthoai.getText().toString();
            String emailkh = email.getText().toString();

            object.put("makhachhang",makhh);
            object.put("tenkhachhang",tenkhh);
            object.put("diachi",diachikh);
            object.put("dienthoai",sdt);
            object.put("email",emailkh);

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
                        getKhachHang();
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
                Toast.makeText(TrangThemKhachHang.this,"loi roi", Toast.LENGTH_LONG).show();

            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        requestQueue.add(jsonObjectRequest);
    }
}
