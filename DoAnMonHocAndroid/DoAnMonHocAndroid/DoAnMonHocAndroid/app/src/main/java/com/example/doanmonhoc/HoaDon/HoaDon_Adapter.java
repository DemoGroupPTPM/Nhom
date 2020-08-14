package com.example.doanmonhoc.HoaDon;

import android.content.Context;
import android.content.DialogInterface;
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
import androidx.appcompat.app.AppCompatActivity;

import com.example.doanmonhoc.R;

import java.util.ArrayList;
import java.util.List;

public class HoaDon_Adapter extends ArrayAdapter {
    ListView lsvHD;
    ArrayList<HoaDon> arrayList;
    HoaDon_List context;
    int layout;

    public HoaDon_Adapter(@NonNull HoaDon_List context, int resource, @NonNull ArrayList<HoaDon> arrayList) {
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

    public class ViewHolder {
        TextView mahd,makh,masp,donvitinh,dongia,thanhtien,soluong,ngaylap;
        ImageView btnXoa, btnSua;

    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        final HoaDon_Adapter.ViewHolder holder;
        if (convertView == null) {
            holder = new HoaDon_Adapter.ViewHolder();
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.custom_hoadon,null);

            holder.mahd = convertView.findViewById(R.id.HD_MaHD);

            holder.makh = convertView.findViewById(R.id.HD_tenKH);
            holder.thanhtien = convertView.findViewById(R.id.HD_TongTien);
            convertView.setTag(holder);
        }
        else {
            holder = (HoaDon_Adapter.ViewHolder) convertView.getTag();
              }

        final HoaDon sanp = arrayList.get(position);
        holder.mahd.setText(sanp.getMahd());
        holder.makh.setText(sanp.getMakh());
        holder.thanhtien.setText(String.valueOf(sanp.getDongia()));
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
                context.deleteHD(ma);
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
