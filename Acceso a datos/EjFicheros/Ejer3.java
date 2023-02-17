import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class Ejer3 {

    public static int f1(File fichero, char caracter) throws IOException {
        FileReader fichIn = null;
        try {
            fichIn = new FileReader(fichero);
            int i;
            int cont = 0;
            while ((i = fichIn.read()) != -1) {
                if((char)i==caracter){
                    cont++;
                }
            }
            System.out.println("\n\n"+cont+" apariciones de "+caracter);
return cont;
        } finally {
            if (fichIn != null) {
                fichIn.close();
            }
        }
    }

    public static void main(String[] args) {

        File file = new File("C:\\Anxo\\Acceso a datos\\Archivos\\text.txt");
        char letra = 'a';
        
        try {

            Ejer3.f1(file,letra);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
