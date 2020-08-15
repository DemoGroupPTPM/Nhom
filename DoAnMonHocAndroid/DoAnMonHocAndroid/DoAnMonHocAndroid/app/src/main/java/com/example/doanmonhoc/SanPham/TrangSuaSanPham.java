package com.example.doanmonhoc.SanPham;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

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

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class TrangSuaSanPham extends AppCompatActivity {
    ArrayList<sanpham> mangSP;
    EditText masp, tensp, giaban, soluong, baohanh;
    Spinner txtmaloai,txtncc;
    String url2="http://10.160.90.109:5000/api/Sanphams/" ;
//   String ma;
    SanPham_Adapter customApdater;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trang_sua_san_pham);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Sửa Sản Phẩm");
        Intent intent = getIntent();
        sanpham sp = (sanpham) intent.getSerializableExtra("sanpham");
        masp = (EditText) findViewById(R.id.edit_mahang) ;
        tensp = (EditText) findViewById(R.id.edit_tenhang);
        giaban =(EditText) findViewById(R.id.edit_them_gia) ;
        soluong = (EditText) findViewById( R.id.edit_them_soluong);
        baohanh = (EditText) findViewById(R.id.edit_them_baohanh) ;
        txtmaloai = findViewById(R.id.spLoaiHang);
        txtncc= findViewById(R.id.spNhaCC);


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
                        //confirmEdit(Integer.parseInt(masp.getText().toString());
                        //chuyển về list sp để xem sp
                        Intent intent = new Intent(TrangSuaSanPham.this, TrangSanPham_list.class);
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
    public void getSanPham()
    {    String url ="http://10.160.90.109:5000/api/SanPhams";
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaSanPham.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
              //  mangSP.clear();
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

//    }
    private void confirmEdit( final int id)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaSanPham.this);
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

            }
        });
        builder.show();
    }
    public  void editStudent(final int id)
    {
        String url2="http://10.160.90.109:5000/api/Sanphams/"+id+"";
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaSanPham.this);
        StringRequest insertRequest = new StringRequest(Request.Method.PUT, url2, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                if(response.equals("true"))
                    Toast.makeText(TrangSuaSanPham.this,response+ " Sua thanh cong",Toast.LENGTH_LONG).show();
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
                String ID = masp.getText().toString();
                String tenhangt= tensp.getText().toString();
                //String hinhanht = object.getString("hinhanh");
                String baohanht = baohanh.getText().toString();
                //String mancct = object.getString("mancc");
                String dongiat =  giaban.getText().toString();
                String soluongt = soluong.getText().toString();

                params.put("masp",ID);
                params.put("tenhang",tenhangt);
                params.put("baohanh",baohanht);
                params.put("dongia",dongiat);
                params.put("soluong",soluongt);

                return params;

            }

        };
        requestQueue.add(insertRequest);
    }
}
