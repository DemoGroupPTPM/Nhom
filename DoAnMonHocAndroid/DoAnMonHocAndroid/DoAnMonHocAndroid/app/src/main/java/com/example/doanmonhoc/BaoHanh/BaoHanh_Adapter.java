package com.example.doanmonhoc.BaoHanh;

import android.content.Context;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;

import net.sourceforge.jtds.jdbc.DateTime;

import java.util.ArrayList;
import java.util.List;

public class BaoHanh_Adapter extends ArrayAdapter {
    BaoHanh_List context;
    ArrayList<BaoHanh> arrayList ;
    int layout;
    public BaoHanh_Adapter(@NonNull BaoHanh_List context, int resource, @NonNull ArrayList<BaoHanh> objects) {
        super(context, resource, objects);
        this.context=context;
        this.layout=resource;
        this.arrayList=objects;
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
        EditText mabh,makh,masp,yeucau,tinhtrang;
        TextView  ngaynhan,ngaytra;
        ImageView btnXoa, btnSua;
    }
}
