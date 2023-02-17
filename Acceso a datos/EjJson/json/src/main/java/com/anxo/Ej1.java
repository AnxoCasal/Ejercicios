package com.anxo;

import java.io.IOException;

public class Ej1 {

    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.getTiempoCiudad("madrid"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
