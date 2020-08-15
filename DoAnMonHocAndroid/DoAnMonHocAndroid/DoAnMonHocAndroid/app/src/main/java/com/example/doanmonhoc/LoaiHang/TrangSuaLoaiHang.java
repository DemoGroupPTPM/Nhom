package com.example.doanmonhoc.LoaiHang;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
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
import com.example.doanmonhoc.KhachHnag.KhachHang;
import com.example.doanmonhoc.KhachHnag.KhachHang_List;
import com.example.doanmonhoc.KhachHnag.TrangSuaKhachHang;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class TrangSuaLoaiHang extends AppCompatActivity {
    ArrayList<LoaiHang> mangLH;
    EditText maloai,tenlaoi;

    String url2="http://10.160.90.109:5000/api/LoaiHangs" ;
    //   String ma;
    SanPham_Adapter customApdater;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sualoaihang);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Sửa Khách hàng");
        Intent intent = getIntent();
        LoaiHang sp = (LoaiHang) intent.getSerializableExtra("loaihang");
        maloai = (EditText) findViewById(R.id.edit_sua_MaLH) ;
        tenlaoi = (EditText) findViewById(R.id.edit_sua_tenLH);



        String mal= sp.getMaloai();
        String ten = sp.getTenloai();


        maloai.setText(mal);
        tenlaoi.setText(ten);

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
                confirmEdit(tenlaoi.getText().toString(), maloai.getText().toString());
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
    public void getLoaiHang()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaLoaiHang.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url2, null, new Response.Listener<JSONArray>() {
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
    private void confirmEdit( String t , final String id)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaLoaiHang.this);
        builder.setTitle("Cảnh báo");
        builder.setMessage("Bạn có thật sự muốn sửa: "+ t +" ?");
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                // editStudent(id);
                insertSP(id);
                Intent intent = new Intent(TrangSuaLoaiHang.this, KhachHang_List.class);
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
    public void insertSP(final String id) {
        final ProgressDialog loading = new ProgressDialog(TrangSuaLoaiHang.this);
        loading.setMessage("vui lòng đợi ...");
        loading.setCanceledOnTouchOutside(false);
        loading.show();
        String url2="http://10.160.90.109:5000/api/LoaiHangs/"+id+"";
        JSONObject object = new JSONObject();
        try {
            String ID = maloai.getText().toString();
            String tenhangt= tenlaoi.getText().toString();


            object.put("maloai",ID);
            object.put("tenloai",tenhangt);


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
                        getLoaiHang();
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
                Toast.makeText(TrangSuaLoaiHang.this,"loi roi", Toast.LENGTH_LONG).show();

            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        requestQueue.add(jsonObjectRequest);
    }
}
