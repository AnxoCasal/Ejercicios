import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class Ejer5 {

    public static void f1(File file, String cadena) throws FileNotFoundException {

        Scanner sc = null;
        int cont = 0;
        String frase;
        try {
            sc = new Scanner(file);
            while (sc.hasNext()) {
                cont++;
                frase = sc.nextLine();
                if (frase.contains(cadena)) {
                    System.out.println(cont + "\t" +frase);
                }
            }
        } finally {
            if (sc != null) {
                sc.close();
            }
        }

    }

    public static void main(String[] args) {

        File file = new File("C:\\Anxo\\Acceso a datos\\Archivos\\text.txt");
        Scanner sc = new Scanner(System.in);
        String palabra = sc.nextLine();


        try {
            Ejer5.f1(file, palabra);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

    }
}
