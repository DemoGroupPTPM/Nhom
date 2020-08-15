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
import com.example.doanmonhoc.KhachHnag.KhachHang;
import com.example.doanmonhoc.KhachHnag.KhachHang_List;
import com.example.doanmonhoc.KhachHnag.TrangSuaKhachHang;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.doanmonhoc.SanPham.TrangSuaSanPham;
import com.example.doanmonhoc.SanPham.sanpham;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class TrangSuaNhaCungCap extends AppCompatActivity {

    EditText mancc,tenncc,diachi,sdt,chuthich;
    String url ="http://10.160.90.109:5000/api/NhaCungCaps";
    Button btnluu;
    ArrayList<NhaCungCap> mangncc;
    NhaCungCap_Adapter customApdater;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sua_ncc);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Sửa Nhà Cung Cấp");
        Intent intent = getIntent();
        NhaCungCap sp = (NhaCungCap) intent.getSerializableExtra("nhacungcap");
        mancc = findViewById(R.id.edit_sua_maNCC);
        tenncc=findViewById(R.id.edit_sua_tenNCC);
        diachi=findViewById(R.id.edit_sua_diachiNCC);
        sdt=findViewById(R.id.edit_sua_SDTNCC);
        chuthich=findViewById(R.id.edit_sua_chuthichNCC);

        String mancct= sp.getMancc();
        String ten = sp.getTenncc();
        String dc = sp.getDiachi();
        String dt = sp.getDienthoai();
        String chuthichh = sp.getChuthich();

        mancc.setText(mancct);
        tenncc.setText(ten);
        diachi.setText(dc);
        sdt.setText(dt);
        chuthich.setText(chuthichh);
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

                AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaNhaCungCap.this);
                builder.setTitle("Thông báo");
                builder.setMessage("Bạn có chắc chắn muốn thêm sản phẩm ?");
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // insertSP();
                       // putData();
                        //chuyển về list sp để xem sp
                        Intent intent = new Intent(TrangSuaNhaCungCap.this, TrangSanPham_list.class);
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
    private void confirmEdit( String t , final String id)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(TrangSuaNhaCungCap.this);
        builder.setTitle("Cảnh báo");
        builder.setMessage("Bạn có thật sự muốn sửa: "+ t +" ?");
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                // editStudent(id);
                insertSP(id);
                Intent intent = new Intent(TrangSuaNhaCungCap.this, KhachHang_List.class);
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
    public void getNCC()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(TrangSuaNhaCungCap.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangncc.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);
                        String makht = object.getString("mancc");
                        String tenkht = object.getString("tenncc");
                        String diachit = object.getString("diachi");
                        String dienthoait = object.getString("dienthoai");
                        String emailt = object.getString("chuthich");


                        // mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc, dongia,soluong));
                        mangncc.add(new NhaCungCap(makht,tenkht,diachit,dienthoait,emailt));
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
    public void insertSP(final String id) {
        final ProgressDialog loading = new ProgressDialog(TrangSuaNhaCungCap.this);
        loading.setMessage("vui lòng đợi ...");
        loading.setCanceledOnTouchOutside(false);
        loading.show();
        String url2="http://192.168.1.108:5000/api/KhachHangs/"+id+"";
        JSONObject object = new JSONObject();
        try {
            String ID = mancc.getText().toString();
            String tent= tenncc.getText().toString();
            //String hinhanht = object.getString("hinhanh");
            String dcc = diachi.getText().toString();
            //String mancct = object.getString("mancc");
            String dt =  sdt.getText().toString();
            String ct = chuthich.getText().toString();

            object.put("mancc",ID);
            object.put("tenncc",tent);
            object.put("diachi",dcc);
            object.put("dienthoai",dt);
            object.put("chuthich",ct);

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
                Toast.makeText(TrangSuaNhaCungCap.this,"loi roi", Toast.LENGTH_LONG).show();

            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        requestQueue.add(jsonObjectRequest);
    }
}
