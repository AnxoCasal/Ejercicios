import java.io.File;
import java.util.Scanner;

public class Ejer1 {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        File fichero = null;

        do {

            System.out.println("Ruta del directorio");

            fichero = new File(sc.nextLine());

            if (fichero.isDirectory()) {

                File[] lista = fichero.listFiles();

                System.out.println("--DIRECTORIOS--");

                for (File string : lista) {
                    if (string.isDirectory()) {
                        System.out.println(string);
                    }
                }

                System.out.println("\n--ARCHIVOS--");
                
                for (File string : lista) {
                    if (string.isFile()) {
                        System.out.println(string);
                    }
                }

            } else {
                System.out.println("Lo introducido no es un directorio");
            }

        } while (!fichero.isDirectory());

    }

}