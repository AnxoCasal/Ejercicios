package com.anxo;

import java.io.IOException;

public class Ej6 {
    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.getCoordCiudad("vigo"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
