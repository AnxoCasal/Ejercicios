package com.anxo;

import java.io.IOException;

public class Ej9 {

    public static void main(String[] args) {
        Jsonn j = new Jsonn();
        try {
            System.out.println(j.Trivia());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
