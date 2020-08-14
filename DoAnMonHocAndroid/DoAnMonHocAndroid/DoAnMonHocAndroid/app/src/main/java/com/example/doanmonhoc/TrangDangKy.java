package com.example.doanmonhoc;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import java.util.ArrayList;

public class TrangDangKy extends AppCompatActivity {
    Button btnDangKy;
    EditText username;
    EditText password;
    EditText confrimpass;
    EditText email;
    ArrayList<NhanVien> arrr;
    String url ="http://kimhung.somee.com/api/NhanVien";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trang_dang_ky);
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Đăng Ký");

        btnDangKy = (Button) findViewById(R.id.btnDangKy_dangky);
        username = (EditText) findViewById(R.id.edtUserName_dangky);
        password = (EditText) findViewById(R.id.edtPass_dangky);
        confrimpass =(EditText) findViewById(R.id.edtRePass_dangky);
        email = (EditText) findViewById(R.id.edtEmail_dangky);

        btnDangKy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

            }
        });
    }

//    ArrayList<NhanVien> lstNv = new ArrayList<>();
//    private  void  getStudentData()
//    {
//         arrr = new ArrayList<>();
//
//        RequestQueue requestQueue = Volley.newRequestQueue(TrangDangKy.this);
//        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
//            @Override
//            public void onResponse(JSONArray response) {
//                for(int i = 0;i<response.length();i++){
//                    try {
//                        JSONObject object = response.getJSONObject(i);
//
//                        String manv = object.getString("manv");
//                        String matkhau =object.getString("matkhau");
//                        //String tennv =object.getString("tennv");
//                        String dienthoai =object.getString("dienthoai");
//
//                        arrr.add(new NhanVien(manv,matkhau,dienthoai));
//
//
//                    } catch (JSONException e) {
//                        e.printStackTrace();
//                        CusTomAdapter_NhanVien.notifyDataSetChanged();
//                    }
//                }
//            }
//        },
//                new Response.ErrorListener() {
//                    @Override
//                    public void onErrorResponse(VolleyError error) {
//
//                    }
//                });
//
//        requestQueue.add(jsonArrayRequest);
//    }

}