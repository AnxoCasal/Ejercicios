<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class admin_seeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('users')->insert([
            "name"=>"root",
            "email"=>"anxocasal2002@gmail.com",
            "password"=>"$2y$10\$RgB4S.nTIxYg1Tc.l.RlZeC4JijIsv8ghlYUpaAz2jr34KConW646"
        ]);
    }
}
