package com.example.componentes;


import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.RadioButton;
import android.widget.RatingBar;
import android.widget.SeekBar;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

public class MainActivity extends AppCompatActivity {

    int cont = 0;

    Button Reinicio;
    Button Contador;
    ToggleButton OnOffTextBox;
    CheckBox checkBoxOnOff;
    CheckBox checkBox2 ;
    CheckBox checkBox3 ;
    RadioButton radioButton1;
    RadioButton radioButton2;
    SeekBar seekBar ;
    TextView contText ;
    TextView seekBarNum;
    TextView switchText;
    Switch switchBoton ;
    RatingBar ratingBar;
    TextView bottomText;
    Button hideAB;


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater=getMenuInflater();
        menuInflater.inflate(R.menu.menus,menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()){
            case R.id.Nuevo:
                Intent intent = new Intent(MainActivity.this, secundaria.class);
                intent.putExtra("chechbox1", checkBoxOnOff.isChecked());
                intent.putExtra("chechbox2", checkBox2.isChecked());
                intent.putExtra("chechbox3", checkBox3.isChecked());
                return  true;
            case R.id.Borrar:
                cont = 0;
                contText.setText("0");
                seekBarNum.setText("");
                bottomText.setText("");
                switchText.setText("");
                seekBar.setProgress(0);
                return  true;
            case R.id.Editar:
                bottomText.setText("");
                return  true;
            case R.id.Opc1:
                Toast test = Toast.makeText(getApplicationContext(),
                        "OPC1", Toast.LENGTH_SHORT);
                test.show();
                return  true;
            case R.id.Opc2:
                Toast test2 = Toast.makeText(getApplicationContext(),
                        "OPC2", Toast.LENGTH_SHORT);
                test2.show();
                return  true;
            default:
                return  super.onOptionsItemSelected(item);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Reinicio = (Button) findViewById(R.id.BotonBasico);
        Contador = (Button) findViewById(R.id.BotonCopiar);
        OnOffTextBox = (ToggleButton) findViewById(R.id.ToggleButton);
        checkBoxOnOff = (CheckBox) findViewById(R.id.checkBox1);
        checkBox2 = (CheckBox) findViewById(R.id.checkBox2);
        checkBox3 = (CheckBox) findViewById(R.id.checkBox3);
        radioButton1 = (RadioButton) findViewById(R.id.radioButton3);
        radioButton2 = (RadioButton) findViewById(R.id.radioButton4);
        seekBar = (SeekBar) findViewById(R.id.seekBar);
        contText = (TextView) findViewById(R.id.textView2);
        seekBarNum = (TextView) findViewById(R.id.textView4);
        switchText = (TextView) findViewById(R.id.textView5);
        switchBoton = (Switch) findViewById(R.id.switch1);
        ratingBar = (RatingBar) findViewById(R.id.ratingBar2);
        bottomText = (TextView) findViewById(R.id.editTextTextPersonName);
        hideAB = (Button) findViewById(R.id.hideButton);
        ActionBar actionBar = getSupportActionBar();
        actionBar.setSubtitle("0");

        OnOffTextBox.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(OnOffTextBox.isChecked()){
                    checkBoxOnOff.setEnabled(false);
                } else if (!OnOffTextBox.isChecked()){
                    checkBoxOnOff.setEnabled(true);
                }
            }
        });

        seekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                seekBarNum.setText(i+"");
                actionBar.setSubtitle(i+"");
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}
            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        switchBoton.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(switchBoton.isChecked()){
                    switchText.setText("Encendido");
                } else if (!switchBoton.isChecked()){{
                    switchText.setText("Apagado");
                }
            }
            }
        });

        Reinicio.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                checkBoxOnOff.setChecked(false);
                checkBox2.setChecked(false);
                checkBox3.setChecked(false);
                radioButton1.setChecked(false);
                radioButton2.setChecked(false);
                seekBar.setProgress(0);
                OnOffTextBox.setChecked(false);
                switchBoton.setChecked(false);
                ratingBar.setRating(0);
                bottomText.setText("");
            }
        });

        Contador.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(checkBox2.isChecked()){
                    cont--;
                } else {
                    cont++;
                }
                contText.setText(cont+"");
            }
        });

        Toast toast1 = Toast.makeText(getApplicationContext(),"RADIO BUTTON Nº1",Toast.LENGTH_LONG);
        Toast toast2 = Toast.makeText(getApplicationContext(),"RADIO BUTTON Nº2",Toast.LENGTH_LONG);

        radioButton1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                toast1.show();
            }
        });

        radioButton2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                toast2.show();
            }
        });

        hideAB.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (actionBar.isShowing()){
                    actionBar.hide();
                } else {
                    actionBar.show();
                }
            }
        });

    }
}