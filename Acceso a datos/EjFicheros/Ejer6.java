import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;

public class Ejer6 {
    public static void DividirCaracteres(int n, File fileIn, File directorio) throws IOException {

        PrintWriter pw = null;
        FileReader fr = null;
        int cont = 1;

        try {

            File fileOut = new File(directorio.getAbsolutePath() + "\\CopiaCaracteres" + cont + ".txt");
            fileOut.createNewFile();
            fr = new FileReader(fileIn);
            pw = new PrintWriter(fileOut);
            String fragmento = "";
            boolean end = false;

            do {
                fragmento = "";
                for (int i = 0; i < n; i++) {
                    fragmento = fragmento + (char) fr.read();
                }
                pw = new PrintWriter(fileOut);
                pw.println(fragmento);
                pw.close();

                if (fr.read() != -1) {
                    cont++;
                    fileOut = new File(directorio.getAbsolutePath() + "\\CopiaCaracteres" + cont + ".txt");
                    fileOut.createNewFile();
                } else {
                    end = !end;
                }

            } while (!end);

        } finally {
            if (pw != null) {
                pw.close();
            }
            if (fr != null) {
                fr.close();
            }
        }

    }

    public static void DividirLineas(int l, File fileIn, File directorio) throws IOException {

        PrintWriter pw = null;
        Scanner sc = null;

        try {
            int cont = 1;
            boolean end = false;

            File fileOut = new File(directorio.getAbsolutePath() + "\\CopiaLineas" + cont + ".txt");
            fileOut.createNewFile();
            String fragmento = "";

            cont = 1;
            end = false;
            sc = new Scanner(fileIn);
            pw = new PrintWriter(fileOut);

            do {
                fragmento = "";
                for (int i = 0; i < l; i++) {
                    if (sc.hasNextLine()) {

                        fragmento += sc.nextLine() + "\r";
                    }
                }
                pw = new PrintWriter(fileOut);
                pw.println(fragmento);
                pw.close();

                if (sc.hasNext()) {
                    cont++;
                    fileOut = new File(directorio.getAbsolutePath() + "\\CopiaLineas" + cont + ".txt");
                    fileOut.createNewFile();
                } else {
                    end = true;
                }
            } while (!end);

        } finally {
            if (pw != null) {
                pw.close();
            }
            if (sc != null) {
                sc.close();
            }
        }

    }

    public static void UnirFicheros(File[] ficheros, File newFile) throws IOException {

        Scanner sc = null;
        PrintWriter pr = null;

        try {
            String union = "";

            for (File file : ficheros) {
                sc = new Scanner(file);
                while (sc.hasNext()) {
                    union = union + sc.nextLine() + "\n";
                }
            }

            pr = new PrintWriter(newFile);
            pr.println(union);

        } finally {
            if (sc != null) {
                sc.close();
            }
            if (pr != null) {
                pr.close();
            }
        }
    }

    public static void main(String[] args) throws IOException {
        File fileIn = new File("C:\\Anxo\\Acceso a datos\\Archivos\\Dividir.txt");
        File directorio = new File("C:\\Anxo\\Acceso a datos\\Archivos");

        try {
            DividirCaracteres(200, fileIn, directorio);
        } catch (IOException ex) {
            System.out.println("ERROR EN LA FUNCION DIVIDIR CARACTERES");
            System.out.println(ex.getMessage());
        }

        try {
            DividirLineas(2, fileIn, directorio);
        } catch (IOException ex) {
            System.out.println("ERROR EN LA FUNCION DIVIDIR LINEAS");
            System.out.println(ex.getMessage());
        }

        //////////////////////////////////////

        File[] listaFiles = new File[4];
        listaFiles[0] = new File("C:\\Anxo\\Acceso a datos\\Archivos\\CopiaLineas1.txt");
        listaFiles[1] = new File("C:\\Anxo\\Acceso a datos\\Archivos\\CopiaLineas2.txt");
        listaFiles[2] = new File("C:\\Anxo\\Acceso a datos\\Archivos\\CopiaLineas3.txt");
        listaFiles[3] = new File("C:\\Anxo\\Acceso a datos\\Archivos\\CopiaLineas4.txt");

        File newFile = new File("C:\\Anxo\\Acceso a datos\\Archivos\\Nuevo.txt");
        newFile.createNewFile();

        try {
            UnirFicheros(listaFiles, newFile);
        } catch (IOException ex) {
            System.out.println("ERROR EN LA FUNCION UNIR FICHEROS");
            System.out.println(ex.getMessage());
        }
    }
}
