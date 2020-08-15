package com.example.doanmonhoc.KhachHnag;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.Spinner;
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
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.doanmonhoc.SanPham.TrangSuaSanPham;
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;
import com.example.doanmonhoc.SanPham.sanpham;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class TrangSuaKhachHang extends AppCompatActivity {
    ArrayList<KhachHang> mangKH;
    EditText makh,tenkh,diachi,dienthoai,email;

    String url2="http://10.160.90.109:5000/api/KhachHangs" ;
    //   String ma;
    SanPham_Adapter customApdater;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sua_khachhang);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Sửa Khách hàng");
        Intent intent = getIntent();
        KhachHang sp = (KhachHang) intent.getSerializableExtra("khachhang");
        makh = (EditText) findViewById(R.id.edit_Sua_maKH) ;
        tenkh = (EditText) findViewById(R.id.edit_Sua_tenKH);
        diachi =(EditText) findViewById(R.id.edit_Sua_diachiKH) ;
        dienthoai = (EditText) findViewById( R.id.edit_Sua_SDTKH);
        email = (EditText) findViewById(R.id.edit_Sua_EmailKH) ;


       String makht= sp.getMakh();
       String tenkhh = sp.getTenkh();
       String dc = sp.getDiachi();
       String dt = sp.getDienthoai();
       String em = sp.getEmail();

       makh.setText(makht);
       tenkh.setText(tenkhh);
       diachi.setText(dc);
       dienthoai.setText(dt);
       email.setText(em);


//        Bundle bundle = getIntent().getBundleExtra("khachhang");
//        String id=bundle.getString("makhachhang");
//        String ten=bundle.getString("tenkhachhang");
//        String dc = bundle.getString("diachi");
//        String dt=bundle.getString("dienthoai");
//        String em=bundle.getString("email");


//      makh.setText(id);
//      tenkh.setText(ten);
//      diachi.setText(dc);
//      dienthoai.setText(dt);
//      email.setText(em);
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
//
//                AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaKhachHang.this);
//                builder.setTitle("Thông báo");
//                builder.setMessage("Bạn có chắc chắn muốn thêm sản phẩm ?");
//                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
//                    @Override
//                    public void onClick(DialogInterface dialog, int which) {
                        // insertSP();
                        //  putData(url2);
                    //  confirmEdit(makh.getId());
               confirmEdit(tenkh.getText().toString(), makh.getText().toString());
                        //chuyển về list sp để xem sp
//                        Intent intent = new Intent(TrangSuaKhachHang.this, KhachHang_List.class);
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
              return  true;
            }
            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }
    public void getKhachHang()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaKhachHang.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url2, null, new Response.Listener<JSONArray>() {
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
    private void confirmEdit( String t , final String id)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaKhachHang.this);
        builder.setTitle("Cảnh báo");
        builder.setMessage("Bạn có thật sự muốn sửa: "+ t +" ?");
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
              // editStudent(id);
                insertSP(id);
                Intent intent = new Intent(TrangSuaKhachHang.this, KhachHang_List.class);
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
    }
//    public  void editStudent(final String id)
//    {
//        String url2="http://192.168.1.108:5000/api/KhachHangs/"+id+"";
//        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaKhachHang.this);
//        StringRequest insertRequest = new StringRequest(Request.Method.PUT, url2, new Response.Listener<String>() {
//            @Override
//            public void onResponse(String response) {
//                if(response.equals("true"))
//                    Toast.makeText(TrangSuaKhachHang.this,response+ " Sua thanh cong",Toast.LENGTH_LONG).show();
//                Log.e("response_det", response);
//
//            }
//        }, new Response.ErrorListener() {
//            @Override
//            public void onErrorResponse(VolleyError error) {
//                Log.e("response_det", "" + error.getMessage() + "," + error.toString());
//            }
//        }) {
//            @Override
//            protected Map<String, String> getParams() throws AbstractMethodError {
//                Map<String, String> params = new HashMap<String, String>();
//                // String maloait = object.getString("maloai");
//                String ID = makh.getText().toString();
//                String tenhangt= tenkh.getText().toString();
//                //String hinhanht = object.getString("hinhanh");
//                String baohanht = diachi.getText().toString();
//                //String mancct = object.getString("mancc");
//                String dongiat =  dienthoai.getText().toString();
//                String soluongt = email.getText().toString();
//
//                params.put("makhachhang",ID);
//                params.put("tenkhachhang",tenhangt);
//                params.put("diachi",baohanht);
//                params.put("dienthoai",dongiat);
//                params.put("email",soluongt);
//
//                return params;
//
//            }
//
//        };
//        requestQueue.add(insertRequest);
//    }
    public void insertSP(final String id) {
        final ProgressDialog loading = new ProgressDialog(TrangSuaKhachHang.this);
        loading.setMessage("vui lòng đợi ...");
        loading.setCanceledOnTouchOutside(false);
        loading.show();
        String url2="http://10.160.90.109:5000/api/KhachHangs/"+id+"";
        JSONObject object = new JSONObject();
        try {
            String ID = makh.getText().toString();
            String tenhangt= tenkh.getText().toString();
            //String hinhanht = object.getString("hinhanh");
            String baohanht = diachi.getText().toString();
            //String mancct = object.getString("mancc");
            String dongiat =  dienthoai.getText().toString();
            String soluongt = email.getText().toString();

            object.put("makhachhang",ID);
            object.put("tenkhachhang",tenhangt);
            object.put("diachi",baohanht);
            object.put("dienthoai",dongiat);
            object.put("email",soluongt);

        } catch (JSONException e) {
            e.printStackTrace();
        }

        final JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.PUT, url2, object, new Response.Listener<JSONObject>() {
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
                Toast.makeText(TrangSuaKhachHang.this,"loi roi", Toast.LENGTH_LONG).show();

            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        requestQueue.add(jsonObjectRequest);
    }
}
