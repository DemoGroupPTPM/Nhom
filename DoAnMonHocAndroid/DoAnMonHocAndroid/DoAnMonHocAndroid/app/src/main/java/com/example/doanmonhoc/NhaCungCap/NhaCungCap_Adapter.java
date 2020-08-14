package com.example.doanmonhoc.NhaCungCap;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
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
import com.example.doanmonhoc.SanPham.ChiTiet_SP;
import com.example.doanmonhoc.SanPham.SanPham_Adapter;
import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.doanmonhoc.SanPham.TrangSuaSanPham;
import com.example.doanmonhoc.SanPham.sanpham;

import java.util.ArrayList;
import java.util.List;

public class NhaCungCap_Adapter extends ArrayAdapter {
    NhaCungCap_List context;

    ArrayList<NhaCungCap> arrayList;
   // TextView tensp, masp, baohanh, dongia;
    int layout;
    public NhaCungCap_Adapter(@NonNull NhaCungCap_List context, int resource, ArrayList<NhaCungCap> arrayList) {
        super(context, resource, arrayList);
        this.context = context;
        this.arrayList = arrayList;
        this.layout = resource;
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

    public void update(ArrayList<NhaCungCap> kh) {
        arrayList= new ArrayList<>();
        arrayList.addAll(kh);
        notifyDataSetChanged();
    }

    public class ViewHolder {
        TextView mancc,tenncc,diachi,sdt,chuthich;
        ImageView btnXoa, btnSuancc;

    }

    @NonNull
    @Override
    public View getView( final int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        final NhaCungCap_Adapter.ViewHolder holder;
        if (convertView == null) {
            holder = new NhaCungCap_Adapter.ViewHolder();
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.custom_nhacungcap, null);

            holder.mancc = convertView.findViewById(R.id.txtMaNCC);
            holder.tenncc = convertView.findViewById(R.id.txtTenNCC);
            holder.diachi = convertView.findViewById(R.id.txtDC);
            holder.sdt = convertView.findViewById(R.id.txtSDT);
            holder.chuthich = convertView.findViewById(R.id.txtCT);
            holder.btnSuancc = convertView.findViewById(R.id.btnSuaNCC);
            holder.btnXoa = convertView.findViewById(R.id.btnXoaNCC);

            convertView.setTag(holder);
        } else {
            holder = (NhaCungCap_Adapter.ViewHolder) convertView.getTag();
        }

        final NhaCungCap sanp = arrayList.get(position);
        holder.mancc.setText(sanp.getMancc());
        holder.tenncc.setText(sanp.getTenncc());
        holder.diachi.setText(sanp.getDiachi());
        holder.sdt.setText(sanp.getDienthoai());
        holder.chuthich.setText(sanp.getChuthich());
        //holder.mancc.setText(sanp.getMancc());
        //holder.maloai.setText(sanp.getMaloai());
        holder.btnXoa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                deleteDialog(sanp.getMancc());
            }
        });

        holder.btnSuancc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(context, TrangSuaNhaCungCap.class);
                i.putExtra("nhacungcap", arrayList.get(position));
                ((Activity)context).startActivity(i);
            }
        });




//        convertView.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                String mancc= holder.mancc.getText().toString();
//                String tenncc= holder.tenncc.getText().toString();
//                String diachi = holder.diachi.getText().toString();
//                String sdt = holder.sdt.getText().toString();
//                 String ct = holder.chuthich.getText().toString();
//
//
////                Intent in=new Intent(view.getContext(), ChiTiet_SP.class);
////                Bundle bundle= new Bundle();
////                bundle.putString("Masp",masp);
////                bundle.putString("Tensp",tensp);
////                bundle.putString("Baohanh",baohanh);
////                //bundle.putString("Mancc",mancc);
////                // bundle.putString("Maloai",maloai);
////                bundle.putString("dongia",dongia);
////                bundle.putString("soluong",soluong);
////
////                in.putExtra("data",bundle);
//                //context.startActivity(in);
//            }
//        });

        return convertView;
    }
    public void deleteDialog(final String ma)
    {
        //Khởi tạo Đối tượng
        androidx.appcompat.app.AlertDialog.Builder b = new androidx.appcompat.app.AlertDialog.Builder(getContext());
        //Thiết Lập Title
        b.setTitle("Xác Nhận");
        b.setMessage("bạn có muon xoa " + ma + " nhà cung cấp này không?");
        //Tạo nút Đồng ý
        b.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int id) {
                //xử lý sự kiện
                context.deleteSP(ma);
                Toast.makeText(getContext(),"xóa thành công mã " + ma + " Nhà cung cấp",Toast.LENGTH_LONG).show();

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
