package com.example.doanmonhoc.SanPham;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.R;
import com.squareup.picasso.Picasso;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class ChiTiet_SP extends AppCompatActivity {
    TextView masp;
    TextView maloai;
    TextView tenhang;
    ImageView hinhanh;
    TextView dongia;
    TextView soluong;
    TextView baohanh;
    TextView mancc;
    Button btnXoa;
    ArrayList<sanpham> mangSP= new ArrayList<>();
    ArrayAdapter<SanPham_Adapter> customadapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chi_tiet__s_p);

        //dòng này để cái actionBar hiện nút mũi tên quay lại trang ban đầu
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //dòng này đê đặt tiêu đề cho actionbar
        ActionBar actionBar= getSupportActionBar();
        actionBar.setTitle("Chi Tiết Sản Phẩm");

        hinhanh = (ImageView) findViewById(R.id.CTSP_img);
        masp = (TextView) findViewById(R.id.masp);
        maloai =(TextView) findViewById(R.id.loaihang);
        tenhang = (TextView) findViewById(R.id.CTSP_tensp);
        dongia = (TextView) findViewById(R.id.gia);
        soluong = (TextView) findViewById(R.id.CTSP_soluong);
        baohanh = (TextView) findViewById(R.id.CTSP_baohanh);
        mancc = (TextView) findViewById(R.id.CTSP_NCC);
        btnXoa = findViewById(R.id.btnXoa_CTSP);
        btnXoa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                deleteDialog(masp.getText().toString());
               // finish();
            }
        });




        Bundle bundle = getIntent().getBundleExtra("data");
        String masph = bundle.getString("masp");
        String tensph = bundle.getString("tensp");
        String hinh = bundle.getString("hinhanh");
      //  String maloaisp = bundle.getString("maloai");
        String dongiasp = bundle.getString("dongia");
        String soluongsp = bundle.getString("soluong");
        String baohanhsp = bundle.getString("baohanh");
       // String manccsp = bundle.getString("mancc");



        masp.setText(masph);
        tenhang.setText(tensph);
     //   maloai.setText(maloaisp);
        dongia.setText(dongiasp);
        soluong.setText(soluongsp);
        baohanh.setText(baohanhsp);
    //    mancc.setText(manccsp);
        hinhanh.setImageURI(Uri.parse(hinh));
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.nut_sua,menu);
        return true;
    }
//này để tạo nút back ngay actionbar
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home: {
                onBackPressed();
                return true;
            }
            case R.id.nutsuasp: {
                Intent i = new Intent(ChiTiet_SP.this,TrangSuaSanPham.class);
                startActivity(i);
                break;
            }
            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }
    public void getSanPham()
    {
        String url ="http://192.168.1.108:5000/api/Sanphams";
        RequestQueue requestQueue = Volley.newRequestQueue(ChiTiet_SP.this);
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                mangSP.clear();
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
                        customadapter.notifyDataSetChanged();


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
    public void deleteSP(final String ma)
    {

        String url ="http://192.168.1.108:5000/api/Sanphams/"+ma+"";

        StringRequest deleteRequest = new StringRequest(Request.Method.DELETE, url,
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response on Success
                        Log.d("Response", response);
                        getSanPham();
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
    public void deleteDialog(final String ma)
    {
        //Khởi tạo Đối tượng
        androidx.appcompat.app.AlertDialog.Builder b = new androidx.appcompat.app.AlertDialog.Builder(ChiTiet_SP.this);
        //Thiết Lập Title
        b.setTitle("Xác Nhận");
        b.setMessage("bạn có muon xoa " + ma + " này không?");
        //Tạo nút Đồng ý
        b.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int id) {
                //xử lý sự kiện
                deleteSP(ma);
                Toast.makeText(ChiTiet_SP.this,"xóa thành công mã " + ma,Toast.LENGTH_LONG).show();

            }
        });
        b.setNegativeButton("cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                // xử lý sự kiện
                dialog.dismiss();
            }
        });



        //Tạo dialog
        androidx.appcompat.app.AlertDialog alertDialog= b.create();
        //Hiển Thị
        alertDialog.show();

    }


}