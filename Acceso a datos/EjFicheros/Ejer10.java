import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class Ejer10 {
    public static void main(String[] args) {

        Persona persona1 = new Persona(48954012, "Paco", 23);

        Depart depart1 = new Depart(2, "dineros", 2);

        File file = new File("C:\\Anxo\\Acceso a datos\\Archivos\\empresa.txt");
        try {
            file.createNewFile();
            nuevo(persona1, file);
            nuevo(depart1, file);
            System.out.println(mostrar(file));
            borrarPersona(file, 48954012);
            System.out.println(mostrar(file));

        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    public static void nuevo(Object nuevo, File file) throws IOException {
        FileOutputStream fos = null;
        ObjectOutputStream out = null;
        try {

            fos = new FileOutputStream(file, true);
            if (file.length() == 0)
                out = new ObjectOutputStream(fos);
            else
                out = new AppendingObjectOutputStream(fos);

            out.writeObject(nuevo);

        } finally {
            if (out != null)
                out.close();
            if (fos != null)
                fos.close();
        }
    }

    public static String mostrar(File file) throws ClassNotFoundException, IOException {

        Object object;
        String result = "";
        try (
                FileInputStream fis = new FileInputStream(file);
                ObjectInputStream oit = new ObjectInputStream(fis);) {

            while (true) {
                if ((object = oit.readObject()).getClass() == Persona.class) {
                    Persona p = (Persona) object;
                    result += "PERSONA- DNI: " + p.getDNI() +
                            "\tNombre: " + p.getNombre() + "\tEdad: "
                            + p.getEdad() + "\n";
                } else {
                    Depart d = (Depart) object;
                    result += "DEPARTAMENTO- Codigo: " + d.getCodigo() +
                            "\tFuncion: " + d.getFuncion() + "\tEmpleados: "
                            + d.getEmpleados() + "\n";
                }
            }

        } catch (EOFException ex) {
            return result;
        }
    }

    public static void borrarPersona(File file, int DNI) {

        File fileTEMP = new File(file.getParent() + "\\temp.txt");

        try (FileInputStream fin = new FileInputStream(file);
                ObjectInputStream in = new ObjectInputStream(fin);
                FileOutputStream fos = new FileOutputStream(fileTEMP);
                ObjectOutputStream out = new ObjectOutputStream(fos);) {

            Object object;

            while (true) {
                if ((object = in.readObject()).getClass() == Persona.class) {
                    if ((((Persona) object).getDNI()) != DNI) {
                        out.writeObject(object);
                    }
                } else {
                    out.writeObject(object);
                }
            }

        } catch (EOFException e) {

        } catch (Exception e) {
            e.printStackTrace();
        }
        File carpeta = new File(file.getParent());

        File nuevo = new File(carpeta + "\\empresa2.txt");
        fileTEMP.renameTo(nuevo);

        File eliminar = new File(carpeta + "\\temp.txt");
        file.renameTo(eliminar);

        File nuevo2 = new File(carpeta + "\\empresa.txt");
        nuevo.renameTo(nuevo2);

        eliminar.delete();
    }
}
