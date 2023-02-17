import java.io.File;

public class Ejer2 {
    
    public static void f1(File file) {
        
        File[] lista = file.listFiles();

        for (File file2 : lista) {
            System.out.println(file2.getAbsolutePath());
            if (file2.isDirectory()) {
                f1(file2);
            }
        }

    }

    public static void main(String[] args) {
        
        File file = new File("C:\\Users\\AnxoC\\Downloads");
        System.out.println(file.exists());
        Ejer2.f1(file);
    }
    
}