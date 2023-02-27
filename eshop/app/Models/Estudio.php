<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

/**
 * Class Estudio
 *
 * @property $id
 * @property $nombre
 * @property $origen
 * @property $año
 * @property $created_at
 * @property $updated_at
 *
 * @property Juego[] $juegos
 * @package App
 * @mixin \Illuminate\Database\Eloquent\Builder
 */
class Estudio extends Model
{
    
    static $rules = [
		'nombre' => 'required',
		'origen' => 'required',
		'año' => 'required',
    ];

    protected $perPage = 20;

    /**
     * Attributes that should be mass-assignable.
     *
     * @var array
     */
    protected $fillable = ['nombre','origen','año'];


    /**
     * @return \Illuminate\Database\Eloquent\Relations\HasMany
     */
    public function juegos()
    {
        return $this->hasMany('App\Models\Juego', 'estudio_id', 'id');
    }
    

}
