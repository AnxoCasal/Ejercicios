package com.anxo;

import java.io.IOException;

public class Ej2 {

    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.getTiempoCoord(10.4200, 42.42));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
