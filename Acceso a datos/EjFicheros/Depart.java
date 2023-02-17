import java.io.Serializable;

public class Depart implements Serializable {
    private int Codigo;

    public void setCodigo(int value) {
        Codigo = value;
    }

    public int getCodigo() {
        return Codigo;
    }

    private String Funcion;

    public void setFuncion(String value) {
        Funcion = value;
    }

    public String getFuncion() {
        return Funcion;
    }

    private int Empleados;

    public void setEmpleados(int value) {
        Empleados = value;
    }

    public int getEmpleados() {
        return Empleados;
    }

    public Depart(int codigo, String funcion, int empleados){
        this.Codigo = codigo;
        this.Funcion = funcion;
        this.Empleados = empleados;
    }

    @Override
    public String toString() {
        return Codigo + " " + Funcion + " " + Empleados;
    }
}
