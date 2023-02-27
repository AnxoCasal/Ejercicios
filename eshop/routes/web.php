<?php

use App\Http\Controllers\EstudioController;
use App\Http\Controllers\GeneroController;
use App\Http\Controllers\JuegoController;
use App\Models\Estudio;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Auth::routes();

Route::resource('juegos', JuegoController::class)->middleware("auth");
Route::resource('generos', GeneroController::class)->middleware("auth");
Route::resource('estudios', EstudioController::class)->middleware("auth");

Route::get('/home', [App\Http\Controllers\HomeController::class, 'index'])->name('home');
