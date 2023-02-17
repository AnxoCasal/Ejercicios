import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Ejer7 {
    public static void f1(File file,File out, int opt) throws IOException {

        Scanner sc = new Scanner(file);

        out.delete();
        PrintWriter pw = new PrintWriter(new FileWriter(out, true));

        switch (opt) {
            case 1:
                try {
                    int cont = 0;
                    while (sc.hasNext()) {
                        sc.next();
                        cont++;
                    }
                    System.out.println("Tiene " + cont + " palabras");

                    cont = 0;

                    sc = new Scanner(file);
                    while (sc.hasNextLine()) {
                        sc.nextLine();
                        cont++;
                    }
                    System.out.println("Tiene " + cont + " lineas");
                } finally {
                    if (sc != null) {
                        sc.close();
                    }
                }

                break;

            case 2, 3, 4, 5:

                ArrayList<String> listaLineas = new ArrayList<String>();

                do {
                    listaLineas.add(sc.nextLine());
                } while (sc.hasNext());

                if (opt == 2) {
                    Collections.sort(listaLineas);
                } else if (opt == 3) {
                    Collections.sort(listaLineas, Collections.reverseOrder());
                } else if (opt == 4) {
                    Collections.sort(listaLineas, String.CASE_INSENSITIVE_ORDER);
                } else {
                    Collections.sort(listaLineas, String.CASE_INSENSITIVE_ORDER);
                    Collections.reverse(listaLineas);
                }

                try {
                    for (String string : listaLineas) {
                        pw.println(string);
                    }
                } finally {
                    if(sc != null){
                        sc.close();
                    }
                    if(pw != null){
                        pw.close();
                    }
                }


                break;

            default:
                System.out.println("NO ES UNA OPCION");
                break;
        }

    }

    public static void main(String[] args) {

        File file = new File("C:\\Anxo\\Acceso a datos\\Archivos\\OrdenAlfa.txt");
        File out = new File("C:\\Anxo\\Acceso a datos\\Archivos\\OrdenAlfa2.txt");

        try {
            f1(file,out, 5);
        } catch (IOException e) {
            System.out.println("A");
        }

    }
}