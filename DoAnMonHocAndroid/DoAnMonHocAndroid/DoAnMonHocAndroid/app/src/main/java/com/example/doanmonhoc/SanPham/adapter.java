package com.example.doanmonhoc.SanPham;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.doanmonhoc.LoaiHang.LoaiHang;
import com.example.doanmonhoc.R;

import java.util.List;

public class adapter extends BaseAdapter {
    Context context;
    int layout;
    List<LoaiHang> arraylist;

    public adapter(Context context, int layout, List<LoaiHang> arraylist) {
        this.context = context;
        this.layout = layout;
        this.arraylist = arraylist;
    }

    @Override
    public int getCount() {
        return arraylist.size();
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(int i, View convertview, ViewGroup viewGroup) {
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        convertview = inflater.inflate(layout, null);
        TextView txtloai= (TextView) convertview.findViewById(R.id.tvLoaiHang );
        txtloai.setText(arraylist.get(i).maloai);
        return convertview;
    }
}
