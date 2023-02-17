package com.example.ejer6;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class Adapter extends RecyclerView.Adapter<Adapter.MyViewHolder> {

    ArrayList<Pelicula> peliculas;
    TextView selectedTitle;

    public Adapter(ArrayList<Pelicula> peliculas, TextView selectedTitle) {
        this.peliculas = peliculas;
        this.selectedTitle = selectedTitle;
    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View elemento = LayoutInflater.from(parent.getContext()).inflate(R.layout.celda, parent, false);
        MyViewHolder mvh = new MyViewHolder(elemento);
        return mvh;
    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder, int position) {
        Pelicula pelicula = this.peliculas.get(position);
        holder.getTitulo().setText(pelicula.getTitulo());
        holder.getDirector().setText(pelicula.getDirector());
        holder.getPortada().setImageResource(pelicula.getPortada());
        holder.getClasi().setImageResource(pelicula.getClasi());
    }

    @Override
    public int getItemCount() {
        return this.peliculas.size();
    }

    int selectedPos = RecyclerView.NO_POSITION;

    public int getSelectedPos() {
        return selectedPos;
    }

    public void setSelectedPos(int nuevaPos) {
        if (nuevaPos == this.selectedPos) {
            this.selectedPos = RecyclerView.NO_POSITION;
            notifyItemChanged(nuevaPos);
        } else {
            if (this.selectedPos >= 0) {
                notifyItemChanged(this.selectedPos);
            }
            this.selectedPos = nuevaPos;
            notifyItemChanged(nuevaPos);
        }
    }

    public class MyViewHolder extends RecyclerView.ViewHolder {

        private TextView titulo;
        private TextView director;
        private TextView sala;
        private TextView sinopsis;
        private TextView duracion;
        private ImageView portada;
        private ImageView clasi;

        public MyViewHolder(View viewElemento) {
            super(viewElemento);
            this.titulo = viewElemento.findViewById(R.id.titulo);
            this.director = viewElemento.findViewById(R.id.director);
            this.portada = viewElemento.findViewById(R.id.portada);
            this.clasi = viewElemento.findViewById(R.id.clasi);

            viewElemento.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                        selectedTitle.setText(titulo.getText());
                }
            });

        }

        public TextView getTitulo() {
            return titulo;
        }

        public TextView getDirector() {
            return director;
        }

        public ImageView getPortada() {
            return portada;
        }

        public ImageView getClasi() {
            return clasi;
        }



    }

}
