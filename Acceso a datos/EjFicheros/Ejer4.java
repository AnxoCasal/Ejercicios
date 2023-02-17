import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;

public class Ejer4 {
    public static void f1(File file) {

        ArrayList<Character> listaCaracteres = new ArrayList<Character>();
        ArrayList<Integer> contadorCaracteres = new ArrayList<Integer>();

        try (FileReader fr = new FileReader(file)) {

            int i;
            while ((i = fr.read()) != -1) {
                if (!listaCaracteres.contains((char) i)) {
                    listaCaracteres.add((char) i);
                    contadorCaracteres.add(1);
                } else {
                    contadorCaracteres.set(listaCaracteres.indexOf((char) i),
                            contadorCaracteres.get(listaCaracteres.indexOf((char) i)) + 1);
                }
            }

            int max = 0;
            max = Collections.max(contadorCaracteres);
            for (Integer integer : contadorCaracteres) {
                if (integer > max) {
                    max = integer;
                }
            }

            System.out.println(
                    "\"" + listaCaracteres.get(contadorCaracteres.indexOf(max)) + "\"\tEs el carter mas usado");

        } catch (IOException e) {
            System.out.println("ERROR DE ARCHIVO");
        }

    }

    public static void main(String[] args) {
        File file = new File("C:\\Anxo\\Acceso a datos\\Archivos\\aaa.txt");
        f1(file);
    }
}
