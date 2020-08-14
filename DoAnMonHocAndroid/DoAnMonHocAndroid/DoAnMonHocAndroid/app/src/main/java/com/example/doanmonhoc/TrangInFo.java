package com.example.doanmonhoc;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.example.doanmonhoc.SanPham.TrangSanPham_list;
import com.example.doanmonhoc.SanPham.TrangThemSP_SanPham;

public class TrangInFo extends AppCompatActivity {
    EditText edtName, edtEmail, edtPass, edtUsername;
    Button btnDangXuat;
    RadioGroup rdbGender;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_info);
        //Male=findViewById(R.id.radiobutton1);
        //Female=findViewById(R.id.radiobutton2);
        edtName = findViewById(R.id.editText4);
        edtEmail = findViewById(R.id.editText);
        edtUsername = findViewById(R.id.editText2);
        edtPass = findViewById(R.id.editText3);
        btnDangXuat= findViewById(R.id.btnDangXuat);
        getSupportActionBar().setTitle("Account Info");
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        Intent intent = getIntent();
        edtUsername.setText(intent.getStringExtra("TenDn"));
        edtEmail.setText(intent.getStringExtra("email"));
        edtPass.setText(intent.getStringExtra("MatKhau"));
        edtName.setText(intent.getStringExtra("name"));
        btnDangXuat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SharedPreferences preInfo = getSharedPreferences("login",MODE_PRIVATE);
                SharedPreferences.Editor editInfo=preInfo.edit();
                editInfo.clear();
                editInfo.apply();
                Intent startMain = new Intent(TrangInFo.this, TrangDangNhap.class);
                startActivity(startMain);
            }
        });

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.nut_luu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {

        switch (item.getItemId())
        {
            case android.R.id.home:
            {
                onBackPressed();
                return true;
            }
            default:break;
            case R.id.luusp:
            {
                finish();
                break;
            }

        }
        return super.onOptionsItemSelected(item);

    }
}
