package com.anxo;

import java.io.IOException;

public class Ej8 {
    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            j.DatosZona("vigo",4);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
