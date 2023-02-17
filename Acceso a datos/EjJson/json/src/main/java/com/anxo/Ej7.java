package com.anxo;

import java.io.IOException;

public class Ej7 {
    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.DatosCiudad("vigo"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
