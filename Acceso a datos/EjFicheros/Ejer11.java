import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class Ejer11 {

    public static void main(String[] args) throws IOException {
        WithBuffer(100);
        noBuffer();
    }

    public static void WithBuffer(int size) throws IOException {
        FileOutputStream out = null;
        FileInputStream in = null;
        BufferedInputStream bufferIn = null;
        BufferedOutputStream bufferOut = null;

        try {
            in = new FileInputStream("C:\\Anxo\\Acceso a datos\\Archivos\\text.txt");
            bufferIn = new BufferedInputStream(in, size);
            out = new FileOutputStream("C:\\Anxo\\Acceso a datos\\Archivos\\text2.txt");
            bufferOut = new BufferedOutputStream(out, size);

            int c;
            long a = System.currentTimeMillis();
            while ((c = bufferIn.read()) != -1) {
                bufferOut.write(c);
            }
            System.out.println(System.currentTimeMillis() - a);
        } finally {
            if (bufferIn != null)
                bufferIn.close();
            if (bufferOut != null)
                bufferOut.close();
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
            in = new FileInputStream("C:\\Anxo\\Acceso a datos\\Archivos\\text.txt");
            out = new FileOutputStream("C:\\Anxo\\Acceso a datos\\Archivos\\text2.txt");

            int c;
            long a = System.currentTimeMillis();
            while ((c = in.read()) != -1) {
                out.write(c);
            }
            System.out.println(System.currentTimeMillis() - a);
        } finally {
            if (in != null)
                in.close();
            if (out != null)
                out.close();
        }

    }
}
