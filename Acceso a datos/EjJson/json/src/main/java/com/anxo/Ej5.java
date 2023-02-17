package com.anxo;

import java.io.IOException;

public class Ej5 {
    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.getNombreCiudad(3105976));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
