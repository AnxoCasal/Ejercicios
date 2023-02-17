package com.anxo;

import java.io.IOException;

public class Ej4 {
    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.getIdCiudad("vigo"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
