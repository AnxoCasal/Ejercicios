package com.anxo;

import java.io.IOException;

public class Ej10 {

    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.ticketMaster("music","ES"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
