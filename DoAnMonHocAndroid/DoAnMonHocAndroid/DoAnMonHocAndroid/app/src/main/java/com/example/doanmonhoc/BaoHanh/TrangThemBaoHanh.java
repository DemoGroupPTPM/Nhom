package com.example.doanmonhoc.BaoHanh;

import android.app.DatePickerDialog;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.example.doanmonhoc.R;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

public class TrangThemBaoHanh extends AppCompatActivity {
    EditText mabh,makh,masp,yeucau,tinhtrang;
    TextView ngaynhanbh,ngaytrabh;
    Button btnNgayLap,btnNgayTra;
    //Khai báo Datasource lưu trữ danh sách công việc
    ArrayList<BaoHanh> baoHanhArrayList=new ArrayList<BaoHanh>();
    //Khai báo ArrayAdapter cho ListView
    ArrayAdapter<BaoHanh> adapter=null;
    ListView lvCv;
    Calendar cal;
    Date ngaynhan,ngaytra;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_khachhang_list);
//        getFormWidgets();
//        getDefaultInfor();
//        addEventFormWidgets();
    }
//    public void getFormWidgets()
//    {
//        ngaynhanbh = findViewById(R.id.txtNgayLapBH);
//        ngaytrabh = findViewById(R.id.txtNgayTraBH);
//        mabh =findViewById(R.id.txtMaBH);
//        makh =findViewById(R.id.txtMaKH_BH);
//        masp = findViewById(R.id.txtMasp_bh);
//        //   yeucau =findViewById( R.id.txtyeucaubh);
//        //Gán DataSource vào ArrayAdapter
//        adapter=new ArrayAdapter<BaoHanh>(this,
//                        android.R.layout.simple_list_item_1,
//                        baoHanhArrayList);
//        //gán Adapter vào ListView
//        lvCv.setAdapter(adapter);
//    }
    /**
     * Hàm lấy các thông số mặc định khi lần đầu tiền chạy ứng dụng
     */
    public void getDefaultInfor()
    {
        //lấy ngày hiện tại của hệ thống
        cal=Calendar.getInstance();
        SimpleDateFormat dft=null;
        //Định dạng ngày / tháng /năm
        dft=new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
        String strDate=dft.format(cal.getTime());
        //hiển thị lên giao diện
        ngaynhanbh.setText(strDate);
        dft=new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
        String strngaytra=dft.format(cal.getTime());
        //đưa lên giao diện
        ngaytrabh.setText(strngaytra);


        mabh.requestFocus();
        //gán cal.getTime() cho ngày hoàn thành và giờ hoàn thành
        ngaynhan=cal.getTime();
        ngaytra=cal.getTime();
    }
    /**
     * Hàm gán các sự kiện cho các control
     */
//    public void addEventFormWidgets()
//    {
//        btnNgayLap.setOnClickListener(new MyButtonEvent());
//        btnNgayTra.setOnClickListener(new MyButtonEvent());
//       // btnAdd.setOnClickListener(new MyButtonEvent());
////        lvCv.setOnItemClickListener(new MyListViewEvent());
////        lvCv.setOnItemLongClickListener(new MyListViewEvent());
//    }
    /**
     * Class sự kiện của các Button
     * @author drthanh
     *
     */
//    private class MyButtonEvent implements View.OnClickListener
//    {
//        @Override
////        public void onClick(View v) {
////            switch(v.getId())
////            {
////                case R.id.btnNgayLap:
////                    showDatePickerDialog();
////                    break;
////                case R.id.btnNgayTra:
////                    showDatePickerDialog();
////                    break;
//////
////            }
////        }
//
//    }
    /**
     * Class sự kiện của ListView
     * @author drthanh
     *
     */
//    private class MyListViewEvent implements
//            AdapterView.OnItemClickListener,
//            AdapterView.OnItemLongClickListener
//    {
//
////        @Override
////        public boolean onItemLongClick(AdapterView<?> arg0, View arg1,
////                                       int arg2, long arg3) {
////            //Xóa vị trí thứ arg2
////            baoHanhArrayList.remove(arg2);
////            adapter.notifyDataSetChanged();
////            return false;
////        }
////
////        @Override
////        public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,
////                                long arg3) {
////            //Hiển thị nội dung công việc tại vị trí thứ arg2
////            Toast.makeText(TrangThemBaoHanh.this, baoHanhArrayList.get(arg2).getDesciption(),
////                    Toast.LENGTH_LONG).show();
////        }
//
//    }
    /**
     * Hàm hiển thị DatePicker dialog
     */
    public void showDatePickerDialog()
    {
        DatePickerDialog.OnDateSetListener callback=new DatePickerDialog.OnDateSetListener() {
            public void onDateSet(DatePicker view, int year,
                                  int monthOfYear,
                                  int dayOfMonth) {
                //Mỗi lần thay đổi ngày tháng năm thì cập nhật lại TextView Date
                ngaynhanbh.setText(
                        (dayOfMonth) +"/"+(monthOfYear+1)+"/"+year);
                ngaytrabh.setText(
                        (dayOfMonth) +"/"+(monthOfYear+1)+"/"+year);
                //Lưu vết lại biến ngày hoàn thành
                cal.set(year, monthOfYear, dayOfMonth);
                ngaynhan=cal.getTime();
                ngaytra=cal.getTime();
            }
        };
        //các lệnh dưới này xử lý ngày giờ trong DatePickerDialog
        //sẽ giống với trên TextView khi mở nó lên
        String s=ngaynhanbh.getText()+"";

        String strArrtmp[]=s.split("/");
        int ngay=Integer.parseInt(strArrtmp[0]);
        int thang=Integer.parseInt(strArrtmp[1])-1;
        int nam=Integer.parseInt(strArrtmp[2]);
        DatePickerDialog pic=new DatePickerDialog(
                TrangThemBaoHanh.this,
                callback, nam, thang, ngay);
        pic.setTitle("Chọn ngày hoàn thành");
        pic.show();

        String t=ngaytrabh.getText()+"";
        String strArrtm[]=s.split("/");
        int ngayt=Integer.parseInt(strArrtmp[0]);
        int thangt=Integer.parseInt(strArrtmp[1])-1;
        int namt=Integer.parseInt(strArrtmp[2]);
        DatePickerDialog pi=new DatePickerDialog(
                TrangThemBaoHanh.this,
                callback, namt, thangt, ngayt);
        pi.setTitle("Chọn ngày hoàn thành");
        pi.show();
    }

    /**
     * Hàm xử lý đưa công việc vào ListView khi nhấn nút Thêm Công việc
     */
//    public void processAddJob()
//    {
//        String title=editCv.getText()+"";
//        String description=editNd.getText()+"";
//        JobInWeek job=new JobInWeek(title, description, dateFinish, hourFinish);
//        arrJob.add(job);
//        adapter.notifyDataSetChanged();
//        //sau khi cập nhật thì reset dữ liệu và cho focus tới editCV
//        editCv.setText("");
//        editNd.setText("");
//        editCv.requestFocus();
//    }
}
