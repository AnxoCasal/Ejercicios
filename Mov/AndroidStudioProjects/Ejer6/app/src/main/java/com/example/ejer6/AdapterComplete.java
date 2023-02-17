package com.example.ejer6;

import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;


import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class AdapterComplete extends RecyclerView.Adapter<AdapterComplete.MyViewHolder> {

    ArrayList<Pelicula> peliculas;
    TextView selectedTitle;

    public AdapterComplete(ArrayList<Pelicula> peliculas, TextView selectedTitle) {
        this.peliculas = peliculas;
        this.selectedTitle = selectedTitle;
    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View elemento = LayoutInflater.from(parent.getContext()).inflate(R.layout.celda_completa, parent, false);
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

        holder.getSalaCine().setText(pelicula.getSala());
        holder.getDuracion().setText(pelicula.getDuracion() + " mins");
        holder.getFechaEstreno().setText(pelicula.getFecha() + "");
        if (pelicula.getFavorita()) {
            holder.getFav().setImageResource(android.R.drawable.star_on);
        } else {
            holder.getFav().setImageResource(android.R.drawable.star_off);
        }

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
        private TextView salaCine;
        private TextView fechaEstreno;
        private TextView duracion;
        private ImageView portada;
        private ImageView clasi;
        private ImageView fav;

        public MyViewHolder(View viewElemento) {
            super(viewElemento);
            this.titulo = viewElemento.findViewById(R.id.titulo2);
            this.director = viewElemento.findViewById(R.id.director2);
            this.portada = viewElemento.findViewById(R.id.portada2);
            this.clasi = viewElemento.findViewById(R.id.clasi2);
            this.duracion = viewElemento.findViewById(R.id.duracion);
            this.salaCine = viewElemento.findViewById(R.id.salaCine);
            this.fechaEstreno = viewElemento.findViewById(R.id.fechaEstreno);
            this.fav = viewElemento.findViewById(R.id.imageFav);


            viewElemento.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    setSelectedPos(getAdapterPosition());
                    Intent intent = new Intent(((MainActivity)view.getContext()),Actividad2.class);
                    intent.putExtra("posicion",getSelectedPos());
                    ((MainActivity)view.getContext()).startActivity(intent);
                }
            });

        }

        public TextView getTitulo() {
            return titulo;
        }

        public TextView getDirector() {
            return director;
        }

        public TextView getSalaCine() {
            return salaCine;
        }

        public TextView getDuracion() {
            return duracion;
        }

        public TextView getFechaEstreno() {
            return fechaEstreno;
        }

        public ImageView getPortada() {
            return portada;
        }

        public ImageView getClasi() {
            return clasi;
        }

        public ImageView getFav() {
            return fav;
        }



    }

}
