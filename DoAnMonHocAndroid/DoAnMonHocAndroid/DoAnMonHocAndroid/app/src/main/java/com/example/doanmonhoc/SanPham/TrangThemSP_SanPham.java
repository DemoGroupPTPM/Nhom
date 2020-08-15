package com.example.doanmonhoc.SanPham;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.AppCompatSpinner;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
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
import com.example.doanmonhoc.LoaiHang.LoaiHang_Adapter;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.TrangChuActivity;
import com.example.doanmonhoc.TrangDangNhap;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class TrangThemSP_SanPham extends AppCompatActivity {
    String url ="http://10.160.90.109:5000/api/Sanphams";
    EditText masp, tensp, giaban, soluong, baohanh;
    ListView lv,listView ;
    Button btnluu;
    ArrayList<sanpham> mangSP= new  ArrayList<>();
    ArrayList<LoaiHang> mangLH = new  ArrayList<>();

    SanPham_Adapter customApdater;
    LoaiHang_Adapter loaiHang_adapter ;
    private AppCompatSpinner spLoaihang;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trang_them_s_p__san_pham);

        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Thêm Sản Phẩm");


        masp = (EditText) findViewById(R.id.edit_mahang) ;
        tensp = (EditText) findViewById(R.id.edit_tenhang);

        giaban =(EditText) findViewById(R.id.edit_them_gia) ;
        soluong = (EditText) findViewById( R.id.edit_them_soluong);
        baohanh = (EditText) findViewById(R.id.edit_them_baohanh) ;
        lv = findViewById(R.id.List_sanpham);
        spLoaihang= findViewById(R.id.spLoaiHang);
        ArrayAdapter  a = new ArrayAdapter<>(this, R.layout.support_simple_spinner_dropdown_item,mangSP);
        spLoaihang.setAdapter(a);
//        loaiHang_adapter = new LoaiHang_Adapter(TrangThemSP_SanPham.this,mangLH,R.layout.custom_loaihang);
//        spLoaihang.setAdapter(loaiHang_adapter);
//        MySpinnerSP_Adapter mySpinnerSP_adapter = new MySpinnerSP_Adapter(TrangThemSP_SanPham.this,loaiHangArrayList);
//        spLoaihang.setAdapter(mySpinnerSP_adapter);
//        spLoaihang.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
//        @Override
//        public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
//            LoaiHang loaiHang = loaiHangArrayList.get(i);
//            Toast.makeText(TrangThemSP_SanPham.this,loaiHang.getMaloai(),Toast.LENGTH_LONG).show();
//        }
//
//            @Override
//            public void onNothingSelected(AdapterView<?> adapterView) {
//
//            }
//        });

       // btnluu = (Button) findViewById( R.id.btnThemSP);
//        btnluu.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                AlertDialog.Builder builder = new AlertDialog.Builder(TrangThemSP_SanPham.this);
//                builder.setTitle("Thông báo");
//                builder.setMessage("Bạn có chắc chắn muốn thêm sản phẩm ?");
//                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
//                    @Override
//                    public void onClick(DialogInterface dialog, int which) {
//                       // insertSP();
//                        insertSP();
//                        //chuyển về list sp để xem sp
//                        Intent intent = new Intent(TrangThemSP_SanPham.this, TrangSanPham_list.class);
//                        startActivity(intent);
//                    }
//                });
//                builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
//                    @Override
//                    public void onClick(DialogInterface dialog, int which) {
//                        finish();
//                    }
//                });
//                builder.show();
//            }
//        });

    }
//tạo nút lưu trên actionbar
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

                AlertDialog.Builder builder = new AlertDialog.Builder(TrangThemSP_SanPham.this);
                builder.setTitle("Thông báo");
                builder.setMessage("Bạn có chắc chắn muốn thêm sản phẩm ?");
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // insertSP();
                        insertSP();
                        //chuyển về list sp để xem sp
                        Intent intent = new Intent(TrangThemSP_SanPham.this, TrangSanPham_list.class);
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

    public void getSanPham()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangThemSP_SanPham.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
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

    public void insertSP() {
        ArrayList<LoaiHang> loaiHangArrayList = new ArrayList<>();
        final ProgressDialog loading = new ProgressDialog(TrangThemSP_SanPham.this);
        loading.setMessage("vui lòng đợi ...");
        loading.setCanceledOnTouchOutside(false);
        loading.show();
        String url2 ="http://10.160.90.109:5000/api/Sanphams";
        JSONObject object = new JSONObject();
        try {
            String maspt = masp.getText().toString();

         //   String maloais = (spLoaihang.getSelectedItem().toString());

            String tenhangt= tensp.getText().toString();

            //String hinhanht = object.getString("hinhanh");
            String baohanht = baohanh.getText().toString();
            //String mancct = object.getString("mancc");
            String dongiat =  giaban.getText().toString();
            String soluongt = soluong.getText().toString();

            object.put("masp",maspt);
           // object.put("maloai",maloais);
            object.put("tenhang",tenhangt);
            object.put("baohanh",baohanht);
            object.put("dongia",dongiat);
            object.put("soluong",soluongt);

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
                        getSanPham();
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
                Toast.makeText(TrangThemSP_SanPham.this,"loi roi", Toast.LENGTH_LONG).show();

            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        requestQueue.add(jsonObjectRequest);
    }
}