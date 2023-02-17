import java.io.Serializable;

public class Persona implements Serializable {
    private int DNI;

    public void setDNI(int value) {
        DNI = value;
    }

    public int getDNI() {
        return DNI;
    }

    private String Nombre;

    public void setNombre(String value) {
        Nombre = value;
    }

    public String getNombre() {
        return Nombre;
    }

    private int Edad;

    public void setEdad(int value) {
        Edad = value;
    }

    public int getEdad() {
        return Edad;
    }

    public Persona(int dni, String nombre, int edad) {
        this.DNI = dni;
        this.Nombre = nombre;
        this.Edad = edad;
    }

    @Override
    public String toString() {
        return DNI + " " + Nombre + " " + Edad;
    }
}
