package com.example.doanmonhoc.SanPham;

import android.content.Context;
import android.database.DataSetObserver;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.SpinnerAdapter;
import android.widget.TextView;

import com.example.doanmonhoc.LoaiHang.LoaiHang;
import com.example.doanmonhoc.R;

import java.util.ArrayList;

public class MySpinnerSP_Adapter implements SpinnerAdapter {
    private ArrayList<LoaiHang> loaiHangs;
private Context context;
    public MySpinnerSP_Adapter(Context context, ArrayList<LoaiHang> loaiHangs) {
        this.loaiHangs = loaiHangs;
    }

    @Override
    public View getDropDownView(int i, View view, ViewGroup viewGroup) {
        view= LayoutInflater.from(context).inflate(R.layout.dropdown_loaihang,viewGroup,false);
        TextView tvloaihang= view.findViewById(R.id.tvLoaiHang);
        tvloaihang.setText(loaiHangs.get(i).getMaloai());
        return view;
    }
    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        view= LayoutInflater.from(context).inflate(R.layout.selected_loaihang,viewGroup,false);
        TextView tvloaihang= view.findViewById(R.id.tvLoaiHang);
        tvloaihang.setText(loaiHangs.get(i).getMaloai());
        return view;
    }

    @Override
    public int getCount() {
        return loaiHangs.size();
    }

    @Override
    public LoaiHang getItem(int i) {
        return loaiHangs.get(i);
    }
    //cái giao diện hiển thị
    @Override
    public int getViewTypeCount() {
        return 1;
    }
    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public void registerDataSetObserver(DataSetObserver dataSetObserver) {

    }

    @Override
    public void unregisterDataSetObserver(DataSetObserver dataSetObserver) {

    }


    @Override
    public boolean hasStableIds() {
        return false;
    }


    @Override
    public int getItemViewType(int i) {
        return 0;
    }



    @Override
    public boolean isEmpty() {
        return false;
    }
}
