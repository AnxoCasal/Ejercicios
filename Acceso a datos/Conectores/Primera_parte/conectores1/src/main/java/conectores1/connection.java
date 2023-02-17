package conectores1;

import java.security.Timestamp;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import org.checkerframework.checker.units.qual.A;

public class connection {

    private Connection conexion;
    private PreparedStatement ps = null;

    public void abrirConexion(String bd, String servidor, String usuario,
            String password) {
        try {
            String url = String.format("jdbc:mariadb://%s:3306/%s?useServerPrepStmts=true", servidor, bd);
            // Establecemos la conexión con la BD
            this.conexion = DriverManager.getConnection(url, usuario, password);
            if (this.conexion != null) {
                System.out.println("Conectado a " + bd + " en " + servidor);
            } else {
                System.out.println("No conectado a " + bd + " en " + servidor);
            }
        } catch (SQLException e) {
            System.out.println("SQLException: " + e.getLocalizedMessage());
            System.out.println("SQLState: " + e.getSQLState());
            System.out.println("Código error: " + e.getErrorCode());
        }
    }

    public void cerrarConexion() {
        try {
            this.conexion.close();
        } catch (SQLException e) {
            System.out.println("Error al cerrar la conexión: " + e.getLocalizedMessage());
        }
    }

    public void consultaAlumnos(String bd) {
        abrirConexion("add", "localhost", "root", "");
        // El Statement se cierra solo al salir de catch
        try (Statement stmt = this.conexion.createStatement()) {
            // Consulta a ejecutar
            String query = "select * from aulas";
            // Se ejecuta la consulta
            ResultSet rs = stmt.executeQuery(query);
            // Mientras queden filas en rs (el método next devuelve true) recorremos las
            // filas
            while (rs.next()) {
                // Se obtiene datos en función del número de columna o de su nombre
                System.out.println(rs.getInt(1) + "\t" +
                        rs.getString("nombreAula") + "\t" + rs.getInt("puestos")); //
            }
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion(); // Se cierra la conexión
        }
    }

    public void insertarFila() {
        try (Statement sta = this.conexion.createStatement()) {
            String query = "INSERT INTO aulas VALUES (5, 'Física', 23), (6, 'Química',34)";
            // Se ejecuta la sentencia de inserción mediante executeUpdate
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas insertadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        }
    }

    public void addColumna() {
        Statement sta = null;
        try {
            sta = this.conexion.createStatement();
            String query = "ALTER TABLE aulas MODIFY nombreAula VARCHAR(25) DEFAULT NULL";
            // Se ejecuta la modificación de la tabla
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas afectadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            if (sta != null) {
                try {
                    sta.close(); // Se cierra el Statement
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    // Ejer1

    public void nombreAlumnoContains(String cadena) {
        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "select * from alumnos where nombre like '%" + cadena + "%'";
            ResultSet rs = stmt.executeQuery(query);
            int cont = 0;
            while (rs.next()) {
                cont++;
                System.out
                        .println(rs.getInt("codigo") + " " + rs.getString("nombre") + " " + rs.getString("apellidos"));
            }
            System.out.println("Numero de resultados obtenidos: " + cont);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    // EJER 2

    public void nuevoAlumno(String nombre, String apellido, int altura, int aula) {

        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "Insert into alumnos (nombre,apellidos,altura,aula) VALUES ('" + nombre + "','" + apellido
                    + "'," + altura + "," + aula + ")";
            int filasAfectadas = stmt.executeUpdate(query);
            System.out.println("Filas insertadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    public void nuevaAsignatura(int numero, String nombre, int puestos) {

        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "Insert into aulas (numero,nombreAula,puestos) VALUES (" + numero + ",'" + nombre + "',"
                    + puestos + ")";
            int filasAfectadas = stmt.executeUpdate(query);
            System.out.println("Filas insertadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    // EJER 3

    public void eliminarAlumno(int codigo) {
        abrirConexion("add", "localhost", "root", "");
        try (Statement sta = this.conexion.createStatement()) {
            String query = "Delete from alumnos where codigo LIKE " + codigo;
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas eliminadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    public void eliminarAula(int codigo) {
        abrirConexion("add", "localhost", "root", "");
        try (Statement sta = this.conexion.createStatement()) {
            String query = "Delete from aulas where numero LIKE " + codigo;
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas eliminadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    // EJER 4

    public void modAlumno(int codigo, String nombre, String apellido, int altura, int aula) {

        abrirConexion("add", "localhost", "root", "");
        try (Statement sta = this.conexion.createStatement()) {
            String query = "UPDATE alumnos set nombre = '" + nombre + "', apellidos = '" + apellido + "', altura = "
                    + altura + ",aula = " + aula + " where codigo LIKE " + codigo;
            System.out.println("*** " + query);
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas modificadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    public void modAsignatura(int numero, String nombre, int puestos) {

        abrirConexion("add", "localhost", "root", "");
        try (Statement sta = this.conexion.createStatement()) {
            String query = "UPDATE aulas set nombreAula = '" + nombre + "', puestos = "
                    + puestos + " where numero LIKE " + numero;
            System.out.println("*** " + query);
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas modificadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    // EJER 5

    public void aulasConAlumnos() {

        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "select distinct aulas.nombreAula from aulas right join alumnos on aulas.numero = alumnos.aula";
            ResultSet rs = stmt.executeQuery(query);
            while (rs.next()) {
                System.out.println(rs.getString("nombreAula"));
            }
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    public void alumnosAprobados() {

        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "Select alumnos.nombre, asignaturas.NOMBRE, notas.nota from notas INNER join alumnos ON notas.alumno = alumnos.codigo INNER JOIN asignaturas ON notas.asignatura = asignaturas.COD WHERE notas.NOTA>=5;";
            ResultSet rs = stmt.executeQuery(query);
            while (rs.next()) {
                System.out.println(rs.getString(1) + " " + rs.getString(2) + " " + rs.getInt(3));
            }
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    public void asignaturasVacias() {

        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "SELECT DISTINCT asignaturas.NOMBRE FROM asignaturas LEFT JOIN notas ON asignaturas.COD = notas.asignatura WHERE notas.asignatura is null";
            ResultSet rs = stmt.executeQuery(query);
            while (rs.next()) {
                System.out.println(rs.getString(1));
            }
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    // EJER 6

    public void alumnosPorAltura(String cadena, int altura) {

        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "SELECT * FROM alumnos where nombre like '%" + cadena + "%' && altura > " + altura;
            ResultSet rs = stmt.executeQuery(query);
            while (rs.next()) {
                System.out.println(rs.getString(2) + " " + rs.getString(3) + " " + rs.getInt(4));
            }
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    public void alumnosPorAlturaPreparada(String cadena, int altura) {

        abrirConexion("add", "localhost", "root", "");
        try (Statement stmt = this.conexion.createStatement()) {
            String query = "SELECT * FROM alumnos where nombre like ? && altura > ?";

            if (this.ps == null)
                this.ps = this.conexion.prepareStatement(query);
            ps.setString(1, "%" + cadena + "%");
            ps.setInt(2, altura);

            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                System.out.println(rs.getString(2) + " " + rs.getString(3) + " " + rs.getInt(4));
            }
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion();
        }
    }

    // Ejer 7

    public void pruebaDeRendimiento(int veces) {

        long start1 = System.nanoTime();
        for (int i = 0; i < veces; i++) {
            alumnosPorAltura("a", 170);
        }
        long end1 = System.nanoTime();

        long start2 = System.nanoTime();
        for (int i = 0; i < veces; i++) {
            alumnosPorAlturaPreparada("a", 170);
        }
        long end2 = System.nanoTime();

        System.out.println("-----------------------------------------");
        System.out.println((end1 - start1) / 1000000000 + "segundos para termianr las consultas basicas");
        System.out.println((end2 - start2) / 1000000000 + "segundos para termianr las consultas preparadas");

    }

    // EJer 8

    public void nuevaColumna(String tabla, String nombre, String tipoDato, String propiedades) {
//////////////MEDIO HACER
        Statement sta = null;
        try {
            sta = this.conexion.createStatement();
            String query = "ALTER TABLE "+tabla+" add "+nombre+"";
            // Se ejecuta la modificación de la tabla
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas afectadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            if (sta != null) {
                try {
                    sta.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
        }
    }

}
