package com.anxo;

import java.io.IOException;

public class Ej11 {

    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.ticketMasterLugarCompleto("music","ES"));
            System.out.println(j.ticketMasterEventoCompleto("music","ES"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
