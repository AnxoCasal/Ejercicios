<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use App\Models\Genero;
use App\Models\Estudio;

/**
 * Class Juego
 *
 * @property $id
 * @property $nombre
 * @property $estudio_id
 * @property $genero_id
 * @property $created_at
 * @property $updated_at
 *
 * @property Estudio $estudio
 * @property Genero $genero
 * @package App
 * @mixin \Illuminate\Database\Eloquent\Builder
 */
class Juego extends Model
{

    static $rules = [
		'nombre' => 'required',
		'estudio_id' => 'required',
		'genero_id' => 'required',
    ];

    protected $perPage = 20;

    /**
     * Attributes that should be mass-assignable.
     *
     * @var array
     */
    protected $fillable = ['nombre','estudio_id','genero_id'];


    /**
     * @return \Illuminate\Database\Eloquent\Relations\HasOne
     */
    public function estudio()
    {
        return $this->hasOne('App\Models\Estudio', 'id', 'estudio_id');
    }

    /**
     * @return \Illuminate\Database\Eloquent\Relations\HasOne
     */
    public function genero()
    {
        return $this->hasOne('App\Models\Genero', 'id', 'genero_id');
    }


}
