package com.example.Tema3;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.provider.AlarmClock;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.RatingBar;

import java.net.URI;

public class MainActivity extends AppCompatActivity {
    private static final String TAG = "MainActivity";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button boton1 = (Button) findViewById(R.id.boton1);
        EditText editText = (EditText) findViewById(R.id.editText);
        RatingBar ratingBar = (RatingBar) findViewById(R.id.ratingBar);
        ImageButton llamada = (ImageButton) findViewById(R.id.Llamada);
        EditText teclado = (EditText) findViewById(R.id.editTextPhone);

        ActivityResultLauncher<Intent> launcher;

        launcher = registerForActivityResult(new ActivityResultContracts.StartActivityForResult(), new ActivityResultCallback<ActivityResult>() {
            @Override
            public void onActivityResult(ActivityResult result) {
                if(result.getResultCode()==RESULT_OK){
                    Intent estrellas = result.getData();
                    float numEstrallas = estrellas.getFloatExtra("numEstrellas", 0f);
                    Log.i(TAG, "Cantidad de estrellas: "+numEstrallas);
                    ratingBar.setRating(numEstrallas);
                }
            }
        });

        boton1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent(MainActivity.this, Second.class);
                intent.putExtra("TITULO", editText.getText().toString());
                intent.putExtra("RATING", ratingBar.getRating());
                launcher.launch(intent);
            }
        });

        llamada.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Uri num = Uri.parse(String.valueOf(teclado.getText()));
                Intent callIntent = new Intent(Intent.ACTION_DIAL,num);
                startActivity(callIntent);
            }
        });
    }
}