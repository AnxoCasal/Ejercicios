package EjDOM;

import java.io.FileNotFoundException;

import javax.lang.model.element.Element;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;

public class Ejer10 {

    public static void AñadirDirector(Document doc, String peliculaOjetivo, String nombre, String apellido) {
        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();

        for (int i = 0; i < peliculas.getLength(); i++) {
            Node pelicula = peliculas.item(i);
            NodeList datosPelicula = pelicula.getChildNodes();
            for (int j = 0; j < datosPelicula.getLength(); j++) {
                Node dato = datosPelicula.item(j);
                if (dato.getNodeName().equals("titulo")) {
                    if (dato.getFirstChild().getNodeValue().equals(peliculaOjetivo)) {

                        Node directorNode = doc.createElement("director");
                        Node nombreNode = doc.createElement("nombre");
                        Node apellidoNode = doc.createElement("apellido");
                        Text textNodeNombre = doc.createTextNode(nombre);
                        Text textNodeApellido = doc.createTextNode(apellido);
                        nombreNode.appendChild(textNodeNombre);
                        apellidoNode.appendChild(textNodeApellido);
                        directorNode.appendChild(nombreNode);
                        directorNode.appendChild(apellidoNode);
                        pelicula.appendChild(directorNode);
                    }
                }
            }

        }
    }

    public static void main(String[] args) {
        String path = "C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml";
        Document doc = lib.crearArbol(path);
        AñadirDirector(doc, "Dune", "Alfredo", "Landa");

        try {
            lib.guardar(doc, path);
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | FileNotFoundException e) {
            System.out.println("ERROR GUARDANDO EL FICHERO");
            e.printStackTrace();
        }

    }
}
