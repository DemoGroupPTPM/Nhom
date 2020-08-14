package com.example.doanmonhoc.KhachHnag;
import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
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


import com.example.doanmonhoc.R;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangSuaSanPham;
import com.example.doanmonhoc.SanPham.sanpham;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import static java.util.Objects.*;

public class KhachHang_Adapter extends ArrayAdapter {
  // KhachHang_List context;
    int layout;
    ArrayList<KhachHang> arrayList;
    KhachHang_List context;

    int layoutID;

    public KhachHang_Adapter(@NonNull KhachHang_List context, int resource, ArrayList<KhachHang> dls) {
        super(context,resource,dls);
        this.context = context;
        layoutID=resource;
        arrayList= dls;
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

    public void update(ArrayList<KhachHang> kh) {
        arrayList= new ArrayList<>();
        arrayList.addAll(kh);
        notifyDataSetChanged();
    }

    public class ViewHolder {
        TextView  makh,tenkh,diachi,dienthoai,email;
        ImageView btnXoa, btnSua;

    }

    @NonNull
    @Override
    public View getView(final int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        final KhachHang_Adapter.ViewHolder holder;
        if (convertView == null) {
            holder = new KhachHang_Adapter.ViewHolder();
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.custom_khachhang, null);

            holder.makh = convertView.findViewById(R.id.txtMaKH);
            holder.tenkh = convertView.findViewById(R.id.txtTenKH);
            holder.diachi = convertView.findViewById(R.id.txtDCKH);
            holder.dienthoai = convertView.findViewById(R.id.txtSDTKH);
            holder.email = convertView.findViewById(R.id.txtemailKH);
            holder.btnSua = convertView.findViewById(R.id.btnSuaKH);
            holder.btnXoa = convertView.findViewById(R.id.btnXoaKH);

            convertView.setTag(holder);
        } else {
            holder = (KhachHang_Adapter.ViewHolder) convertView.getTag();
        }

        final KhachHang sanp = arrayList.get(position);
        holder.makh.setText(sanp.getMakh());
        holder.tenkh.setText(sanp.getTenkh());
        holder.diachi.setText(sanp.getDiachi());
        holder.dienthoai.setText(sanp.getDienthoai());
        holder.email.setText(sanp.getEmail());

        holder.btnXoa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                deleteDialog(sanp.getMakh());
            }
        });
        holder.btnSua.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(context, TrangSuaKhachHang.class);
                i.putExtra("khachhang", arrayList.get(position));
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
                context.deleteSP(ma);
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

