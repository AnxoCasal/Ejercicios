import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.sql.Timestamp;

public class Ejer8 {
    static int buffersize = 100;

    public static void bigBuffer() throws IOException {

        FileOutputStream out = null;
        FileInputStream in = null;

        try {
            in = new FileInputStream("C:\\Anxo\\Acceso a datos\\Archivos\\Dividir.txt");
            out = new FileOutputStream("C:\\Anxo\\Acceso a datos\\Archivos\\ejem.txt");
            byte[] buffer = new byte[buffersize];

            int c;
            while ((c = in.read(buffer)) != -1) {
                out.write(buffer, 0, c);
            }
        } finally {
            if (in != null)
                in.close();
            if (out != null)
                out.close();
        }
    }

    public static void smallBuffer() throws IOException {

        FileOutputStream out = null;
        FileInputStream in = null;

        try {
            in = new FileInputStream("C:\\Anxo\\Acceso a datos\\Archivos\\Dividir.txt");
            out = new FileOutputStream("C:\\Anxo\\Acceso a datos\\Archivos\\ejem.txt");
            byte[] buffer = new byte[10];

            int c;
            while ((c = in.read(buffer)) != -1) {
                out.write(buffer, 0, c);
            }
        } finally {
            if (in != null)
                in.close();
            if (out != null)
                out.close();
        }
    }

    public static void noBuffer() throws IOException {

        FileOutputStream out = null;
        FileInputStream in = null;

        try {
            in = new FileInputStream("C:\\Anxo\\Acceso a datos\\Archivos\\Dividir.txt");
            out = new FileOutputStream("C:\\Anxo\\Acceso a datos\\Archivos\\ejem.txt");

            int c;
            while ((c = in.read()) != -1) {
                out.write(c);
            }
        } finally {
            if (in != null)
                in.close();
            if (out != null)
                out.close();
        }
    }

    public static void main(String[] args) {
        try {
            long a = System.currentTimeMillis();
            bigBuffer();
            System.out.println(System.currentTimeMillis() - a);

            a = System.currentTimeMillis();
            smallBuffer();
            System.out.println(System.currentTimeMillis() - a);

            a = System.currentTimeMillis();
            noBuffer();
            System.out.println(System.currentTimeMillis() - a);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
