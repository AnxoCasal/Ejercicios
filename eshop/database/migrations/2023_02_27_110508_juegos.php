<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('juegos', function (Blueprint $table) {
            $table->id();
            $table->string("nombre");
            $table->bigInteger("estudio_id")->unsigned();
            $table->bigInteger("genero_id")->unsigned();
            $table->timestamps();
            $table->foreign("estudio_id")->references("id")->on("estudios")->onDelete("cascade");
            $table->foreign("genero_id")->references("id")->on("generos")->onDelete("cascade");
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('juegos');
    }
};
