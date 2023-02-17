package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private static final String TAG = "HOLA";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.v(TAG, "metodo onCreate");
        Toast toast=Toast.makeText(getApplicationContext(), "Prueba de Toast111",
                Toast.LENGTH_LONG);
        toast.show();
        Toast toast2=Toast.makeText(getApplicationContext(), "Prueba de Toast222",
                Toast.LENGTH_LONG);
        toast2.show();
        Toast toast3=Toast.makeText(getApplicationContext(), "Prueba de Toast333",
                Toast.LENGTH_LONG);
        toast3.show();

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    @Override
    protected void onStart() {
        Log.d(TAG, "metodo onStart");
        super.onStart();
    }

    @Override
    protected void onResume() {
        Log.i(TAG, "metodo onResume");
        super.onResume();
    }

    @Override
    protected void onPause() {
        Log.e(TAG, "metodo onPause");
        super.onPause();
    }

    @Override
    protected void onStop() {
        Log.i(TAG, "metodo onStop");
        super.onStop();
    }

    @Override
    protected void onRestart() {
        Log.w(TAG, "metodo onRestart");
        super.onRestart();
    }

    @Override
    protected void onDestroy() {
        Log.v(TAG, "metodo onDestroy");
        super.onDestroy();
    }

}