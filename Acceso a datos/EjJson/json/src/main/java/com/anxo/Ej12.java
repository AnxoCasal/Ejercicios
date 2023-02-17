package com.anxo;

import java.io.IOException;

public class Ej12 {

    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.ticketMasterTiempoLocal("music","ES"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
