import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class Ejer9 {
    public static void nuevo(File file, int cod, String nombre, Double altura) throws IOException {

        try (
                FileOutputStream FO = new FileOutputStream(file, true);
                DataOutputStream DO = new DataOutputStream(FO);) {
            Scanner sc = new Scanner(System.in);

            DO.writeInt(cod);
            DO.writeUTF(nombre);
            DO.writeDouble(altura);
        }

    }

    public static void nuevo2(File file) throws IOException {
        FileOutputStream FO = null;
        DataOutputStream DO = null;
        try {
            Scanner sc = new Scanner(System.in);
            FO = new FileOutputStream(file);
            DO = new DataOutputStream(FO);

            DO.writeInt(1);
            DO.writeUTF("Anxo");
            DO.writeDouble(190);

            DO.writeInt(2);
            DO.writeUTF("Paco");
            DO.writeDouble(155);

            DO.writeInt(3);
            DO.writeUTF("Lucas");
            DO.writeDouble(195);
        } finally {
            try {
                if (DO != null)
                    DO.close();
                if (FO != null)
                    FO.close();
            } catch (IOException e) {
                System.out.println("ERROR DE FICHEROS2");
            }
        }

    }

    public static void mostrar(File file) throws IOException {
        System.out.print("\033[H\033[2J");

        try (FileInputStream FI = new FileInputStream(file);
                DataInputStream DI = new DataInputStream(FI);) {
            try {
                while (true) {
                    System.out.println(DI.readInt() + "\t" + DI.readUTF() + "\t" + DI.readDouble());
                }
            } catch (EOFException e) {
                System.out.println("Fin de fichero");
            }
        }

    }

    public static void mod(File file, int cod) throws IOException {

        try (FileInputStream FI = new FileInputStream(file);
                DataInputStream DI = new DataInputStream(FI);
                FileOutputStream FO = new FileOutputStream(file);
                DataOutputStream DO = new DataOutputStream(FO);) {
            Scanner sc = new Scanner(System.in);
            int codigos;
            ArrayList<Integer> codigosList = new ArrayList<Integer>();
            ArrayList<String> nombresList = new ArrayList<String>();
            ArrayList<Double> alturasList = new ArrayList<Double>();

            try {
                while (true) {
                    if ((codigos = DI.readInt()) == cod) {
                        System.out.println("Añade los nuevos valores para el alumno con codigo: " + codigos
                                + DI.readUTF() + DI.readDouble() + "\r");

                        System.out.println("Codigo");
                        codigosList.add(sc.nextInt());
                        sc.nextLine();
                        System.out.println("Nombre");
                        nombresList.add(sc.nextLine());
                        System.out.println("Altura");
                        alturasList.add(sc.nextDouble());
                    } else {
                        codigosList.add(codigos);
                        nombresList.add(DI.readUTF());
                        alturasList.add(DI.readDouble());
                    }
                }
            } catch (EOFException e) {
                System.out.println("Fin de fichero");
            }

            for (int i = 0; i < codigosList.size(); i++) {
                DO.writeInt(codigosList.get(i));
                DO.writeUTF(nombresList.get(i));
                DO.writeDouble(alturasList.get(i));
            }

        }
    }

    public static void eliminar(File file, int cod) throws IOException {

        try (FileInputStream FI = new FileInputStream(file);
                DataInputStream DI = new DataInputStream(FI);
                FileOutputStream FO = new FileOutputStream(file);
                DataOutputStream DO = new DataOutputStream(FO);) {

            int codigos;
            ArrayList<Integer> codigosList = new ArrayList<Integer>();
            ArrayList<String> nombresList = new ArrayList<String>();
            ArrayList<Double> alturasList = new ArrayList<Double>();

            try {
                while (true) {
                    if ((codigos = DI.readInt()) == cod) {
                        System.out.println("Se ah eliminado el alumno con codigo: " + codigos
                                + DI.readUTF() + DI.readDouble() + "\r");
                    } else {
                        codigosList.add(codigos);
                        nombresList.add(DI.readUTF());
                        alturasList.add(DI.readDouble());
                    }
                }
            } catch (EOFException e) {
                System.out.println("Fin de fichero");
            }

            for (int i = 0; i < codigosList.size(); i++) {
                DO.writeInt(codigosList.get(i));
                DO.writeUTF(nombresList.get(i));
                DO.writeDouble(alturasList.get(i));
            }

        }
    }

    public static void main(String[] args) {

        try {

            File file = new File("C:\\Anxo\\Acceso a datos\\Archivos\\alumnos.dat");
            Scanner sc = new Scanner(System.in);
            if (!file.exists()) {
                file.createNewFile();
            }

            // nuevo2(file); // FORMATEA EL FICHERO Y AÑADE VALORES PREDETERMINADOS
            mostrar(file);

            //System.out.println("Codigo");
            //int cod = sc.nextInt();
            //sc.nextLine();
            //System.out.println("Nombre");
            //String nombre = sc.nextLine();
            //System.out.println("Altura");
            //Double altura = sc.nextDouble();
            //nuevo(file, cod, nombre, altura);

            mostrar(file);
            // mod(file, 1);
            // eliminar(file, 3);
            // mostrar(file);


        } catch (IOException ex) {
            System.out.println("ERROR DE ARCHIVOS");
            System.out.println(ex.getMessage());
        }
    }
}
