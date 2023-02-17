package com.example.Tema3;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.RatingBar;

public class Second extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);

        Intent intent = getIntent();

        ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayHomeAsUpEnabled(true);
        RatingBar ratingBar2 = (RatingBar) findViewById(R.id.ratingBar2);
        Button botonVoler = (Button) findViewById(R.id.volver);

        actionBar.setTitle(intent.getStringExtra("TITULO"));
        ratingBar2.setRating(intent.getFloatExtra("RATING", 0f));

        botonVoler.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intentSec = new Intent();
                intentSec.putExtra("numEstrellas", ratingBar2.getRating());
                setResult(RESULT_OK,intentSec);
                finish();
            }
        });

    }
        @Override
        public void onBackPressed() {
            RatingBar ratingBar2 = (RatingBar) findViewById(R.id.ratingBar2);
            Intent intentSec = new Intent();
            intentSec.putExtra("numEstrellas", ratingBar2.getRating());
            setResult(RESULT_OK,intentSec);
            finish();
        }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                onBackPressed();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }
}