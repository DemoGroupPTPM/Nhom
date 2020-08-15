package com.example.doanmonhoc.BaoHanh;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

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
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;
import com.example.doanmonhoc.SanPham.sanpham;
import com.example.doanmonhoc.TrangThongBao;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import net.sourceforge.jtds.jdbc.DateTime;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

public class BaoHanh_List extends AppCompatActivity {

    TextView mabh,makh,masp,yeucau,tinhtrang;
    TextView ngaynhan,ngaytra;
    Button btnNgayLap,btnNgayTra;
    //Khai báo Datasource lưu trữ danh sách công việc
    String url ="http://10.160.90.109:5000/api/BaoHanhs";


    ArrayList<BaoHanh> mangBH;
    BaoHanh_Adapter customApdater;
    ListView lvCv;
    Calendar cal;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_baohanh_list);


        mangBH =new ArrayList<>();
        lvCv=(ListView) findViewById(R.id.List_sanpham);
        mabh = (TextView) findViewById(R.id.txtMaBH);
        makh = (TextView) findViewById(R.id.txtMakh_bh);
        getBaoHanh();

        customApdater = new BaoHanh_Adapter(BaoHanh_List.this, R.layout.custom_baohanh, mangBH);
        lvCv.setAdapter(customApdater);
        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Bảo Hành");
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.option_sanpham,menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId())
        {
            case android.R.id.home:
            {
                onBackPressed();
                return true;
            }
            default:break;
            case R.id.themsp:
            {
                Intent i = new Intent(BaoHanh_List.this, TrangThemBaoHanh.class);
                startActivity(i);
                break;
            }
            case R.id.thongbao:
            {
                Intent  i = new Intent(BaoHanh_List.this, TrangThongBao.class);
                startActivity(i);
                break;
            }
        }
        return super.onOptionsItemSelected(item);
    }

    public void getBaoHanh()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(BaoHanh_List.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangBH.clear();
                for(int i = 0;i<response.length();i++){
                    try {
                        JSONObject object = response.getJSONObject(i);
                        String mabh = object.getString("mabaohanh");
                        String makh = object.getString("makhachhang");

                        String masp = object.getString("masp");
                        String manv = object.getString("manv");
                        String yeucau = object.getString("yeucaubaohanh");
                        String ngaynhan = object.getString("ngaynhan");
                        Date nn = new SimpleDateFormat("dd/MM/yyyy").parse(ngaynhan);
                        String ngaytra = object.getString("ngaytra");
                        Date nt = new SimpleDateFormat("dd/MM/yyyy").parse(ngaytra);

                        // mangSP.add(new sanpham(masp,maloai,tenhang,hinhanh,baohanh,mancc, dongia,soluong));
                        mangBH.add(new BaoHanh(mabh,makh,masp,manv,yeucau,nn,nt));
                        //Toast.makeText(TrangSanPham_list.this,"hello"+response,Toast.LENGTH_LONG).show();
                        Log.d("AAA",""+response);
                        customApdater.notifyDataSetChanged();


                    } catch (JSONException | ParseException e) {
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
    public void deleteSP(final String ma)
    {

        String url ="http://192.168.1.108:5000/api/BaoHanhs/"+ma+"";

        StringRequest deleteRequest = new StringRequest(Request.Method.DELETE, url,
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response on Success
                        Log.d("Response", response);
                        getBaoHanh();
                    }
                },
                new Response.ErrorListener()
                {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // error
                        // Log.d("Error.Response", error.getMessage());
                        Log.e("response_det", "" + error.getMessage() + "," + error.toString());
                    }
                }
        );
        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        queue.add(deleteRequest);
        //getStudentData();
    }
}
