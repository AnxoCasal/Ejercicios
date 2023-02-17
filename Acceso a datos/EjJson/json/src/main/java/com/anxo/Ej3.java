package com.anxo;

import java.io.IOException;

public class Ej3 {
    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.getTiempoCoordCercanas(24.2422, 51.1522, 2));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
