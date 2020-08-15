package com.example.doanmonhoc.LoaiHang;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.KhachHnag.TrangSuaKhachHang;
import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;
import com.example.doanmonhoc.SanPham.sanpham;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class LoaiHang_Adapter extends ArrayAdapter {
LoaiHang_List context;
    LoaiHang loaiHang;
    ListView lsvSp;
    ArrayList<LoaiHang> arrayList;
    TextView  maloai,manhom,tenloai;
    int layout;
    public LoaiHang_Adapter(@NonNull LoaiHang_List context, int resource, @NonNull ArrayList<LoaiHang> objects) {
        super(context, resource, objects);
        this.arrayList=objects;
        this.context=context;
        this.layout=resource;
    }



    @Override
    public int getCount() {
        return arrayList.size();
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    public void update(ArrayList<LoaiHang> kh) {
        arrayList= new ArrayList<>();
        arrayList.addAll(kh);
        notifyDataSetChanged();
    }

    public class ViewHolder {
        TextView  maloai,manhom,tenloai;
        ImageView btnXoa, btnSua;
        ImageView imgHinh;
    }

    @NonNull
    @Override
    public View getView( final int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        final LoaiHang_Adapter.ViewHolder holder;
        if (convertView == null) {
            holder = new LoaiHang_Adapter.ViewHolder();
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.custom_loaihang, null);

            holder.maloai = convertView.findViewById(R.id.txtMaLoai);
            holder.tenloai = convertView.findViewById(R.id.txtTenLoai);


            holder.btnSua = convertView.findViewById(R.id.btnSuaLoaiHang);
            holder.btnXoa = convertView.findViewById(R.id.btnXoaLoaiHang);

            convertView.setTag(holder);
        } else {
            holder = (LoaiHang_Adapter.ViewHolder) convertView.getTag();
        }

        final LoaiHang sanp = arrayList.get(position);
        holder.maloai.setText(sanp.getMaloai());
        holder.tenloai.setText(sanp.getTenloai());

        holder.btnXoa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                deleteDialog(sanp.getMaloai());
            }
        });
        holder.btnSua.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(context, TrangSuaLoaiHang.class);
                i.putExtra("loaihang", arrayList.get(position));
                ((Activity)context).startActivity(i);
            }
        });

        return convertView;
    }
    public void deleteDialog(final String ma)
    {
        //Khởi tạo Đối tượng
        androidx.appcompat.app.AlertDialog.Builder b = new androidx.appcompat.app.AlertDialog.Builder(getContext());
        //Thiết Lập Title
        b.setTitle("Xác Nhận");
        b.setMessage("bạn có muon xoa " + ma + " này không?");
        //Tạo nút Đồng ý
        b.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int id) {
                //xử lý sự kiện
                context.deleteLH(ma);
                Toast.makeText(getContext(),"xóa thành công mã " + ma,Toast.LENGTH_LONG).show();

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
