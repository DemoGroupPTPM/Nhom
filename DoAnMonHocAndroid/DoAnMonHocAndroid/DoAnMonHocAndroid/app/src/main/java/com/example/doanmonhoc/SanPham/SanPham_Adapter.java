package com.example.doanmonhoc.SanPham;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.icu.text.Transliterator;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.doanmonhoc.R;
import com.squareup.picasso.Picasso;

import java.io.Serializable;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

public class SanPham_Adapter extends ArrayAdapter {

    TrangSanPham_list context;
    sanpham sp;
    ListView lsvSp;
    ArrayList<sanpham> arrayList;
    TextView tensp, masp, baohanh, dongia;
    int layout;

    public SanPham_Adapter(TrangSanPham_list context, ArrayList<sanpham> arrayList, int layout) {
        super(context,layout,arrayList);
        this.context = context;
        this.arrayList = arrayList;
        this.layout = layout;

    }
public  void  update(ArrayList<sanpham> hi)
{
    arrayList= new ArrayList<>();
    arrayList.addAll(hi);
    notifyDataSetChanged();
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

    public class ViewHolder {
        TextView tensp, masp, baohanh, dongia,soluong,mancc,maloai;
        ImageView btnXoa;
        ImageView imgHinh;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        final ViewHolder holder;
        if (convertView == null) {
            holder = new ViewHolder();
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.custom_sanpham, null);

            holder.tensp = convertView.findViewById(R.id.txtTenSP);
            holder.masp = convertView.findViewById(R.id.txtMaSP);
            holder.baohanh = convertView.findViewById(R.id.txtBH);
            holder.dongia = convertView.findViewById(R.id.txtdonGia);
            holder.soluong = convertView.findViewById(R.id.txtSL);
            holder.btnXoa = convertView.findViewById(R.id.btnXoaSP);
            holder.mancc = convertView.findViewById(R.id.txtMaLoai);
            holder.imgHinh = convertView.findViewById(R.id.imgHinhanhSP);


//            holder.btnXoa = convertView.findViewById(R.id.btnXoa);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        final sanpham sanp = arrayList.get(position);
        holder.tensp.setText(sanp.getTenhang());
        holder.masp.setText(sanp.getMasp());
        holder.baohanh.setText(sanp.getBaohanh());
        holder.dongia.setText(String.valueOf(sanp.getDongia()));
        holder.soluong.setText( String.valueOf( sanp.getSoluong()));
        Picasso.with(getContext()).load(sanp.getHinhanh()).into(holder.imgHinh);
//        holder.mancc.setText(sanp.getMaloai());
     //   holder.maloai.setText(sanp.getMaloai());
        holder.btnXoa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                deleteDialog(sanp.getMasp());
            }
        });



        convertView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String masp= holder.masp.getText().toString();
                String tensp= holder.tensp.getText().toString();
                String baohanh = holder.baohanh.getText().toString();
                //String mancc = holder.mancc.getText().toString();
             //  String mancc = holder.maloai.getText().toString();
                String dongia = String.valueOf(holder.dongia.getText().toString());
                String soluong = String.valueOf(holder.soluong.getText().toString());

                Intent in=new Intent(view.getContext(),ChiTiet_SP.class);
                Bundle bundle= new Bundle();
                bundle.putString("Masp",masp);
                bundle.putString("Tensp",tensp);
                bundle.putString("Baohanh",baohanh);
                //bundle.putString("Mancc",mancc);
             //   bundle.putString("Maloai",mancc);
                bundle.putString("dongia",dongia);
                bundle.putString("soluong",soluong);
                //String hinhanhchitiet= holder.imgHinh.getTag().toString();
               // Picasso.with(getContext()).load(String.valueOf( hinhanhchitiet)).into(holder.imgHinh);

                in.putExtra("data",bundle);
                context.startActivity(in);
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
