package com.example.doanmonhoc.NhaCungCap;

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


import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class TrangThemNhaCungCap extends AppCompatActivity {
    EditText mancc,tenncc,diachi,sdt,chuthich;
    String url ="http://192.168.1.108:5000/api/NhaCungCaps";

    ArrayList<NhaCungCap> mangncc;
    NhaCungCap_Adapter customApdater;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_them_ncc);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Thêm Nhà Cung Cấp");
        mancc = findViewById(R.id.edit_them_maNCC);
        tenncc=findViewById(R.id.edit_them_tenNCC);
        diachi=findViewById(R.id.edit_them_diachiNCC);
        sdt=findViewById(R.id.edit_them_SDTNCC);
        chuthich=findViewById(R.id.edit_them_chuthichNCC);
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

                AlertDialog.Builder builder = new AlertDialog.Builder(TrangThemNhaCungCap.this);
                builder.setTitle("Thông báo");
                builder.setMessage("Bạn có chắc chắn muốn thêm sản phẩm ?");
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // insertSP();
                        insertNCC();
                        //chuyển về list sp để xem sp
                        Intent intent = new Intent(TrangThemNhaCungCap.this, NhaCungCap_List.class);
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
    public void getNCC()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangThemNhaCungCap.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangncc.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);
                        String mancc = object.getString("mancc");
                        String tenncc = object.getString("tenncc");
                        String diachi = object.getString("diachi");
                        String sdt = object.getString("dienthoai");
                        String chuthich = object.getString("chuthich");


                        // mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc, dongia,soluong));
                        mangncc.add(new NhaCungCap(mancc,tenncc,diachi,sdt,chuthich));
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
    public void insertNCC() {
        final ProgressDialog loading = new ProgressDialog(TrangThemNhaCungCap.this);
        loading.setMessage("vui lòng đợi ...");
        loading.setCanceledOnTouchOutside(false);
        loading.show();
        String url2 ="http://10.160.90.109:5000/api/NhaCungCaps";
        JSONObject object = new JSONObject();
        try {
            String mancct = mancc.getText().toString();
            // String maloait = object.getString("maloai");
            String tenncct= tenncc.getText().toString();
            //String hinhanht = object.getString("hinhanh");
            String diachit = diachi.getText().toString();
            //String mancct = object.getString("mancc");
            String sdtt =  sdt.getText().toString();
            String chuthicht = chuthich.getText().toString();

            object.put("mancc",mancct);
            object.put("tenncc",tenncct);
            object.put("diachi",diachit);
            object.put("dienthoai",sdtt);
            object.put("chuthich",chuthicht);

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
                        getNCC();
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
                Toast.makeText(TrangThemNhaCungCap.this,"loi roi", Toast.LENGTH_LONG).show();

            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        requestQueue.add(jsonObjectRequest);
    }
}
