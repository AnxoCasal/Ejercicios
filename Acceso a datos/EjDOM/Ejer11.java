package EjDOM;

import java.io.FileNotFoundException;

import javax.lang.model.element.Element;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;

public class Ejer11 {

    public static void BorrarPelicula(Document doc, String peliculaOjetivo) {
        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();

        for (int i = 0; i < peliculas.getLength(); i++) {
            Node pelicula = peliculas.item(i);
            NodeList datosPelicula = pelicula.getChildNodes();
            for (int j = 0; j < datosPelicula.getLength(); j++) {
                Node dato = datosPelicula.item(j);
                if (dato.getNodeName().equals("titulo")) {
                    if (dato.getFirstChild().getNodeValue().equals(peliculaOjetivo)) {

                        filmoteca.removeChild(pelicula);
                    }
                }
            }

        }
    }

    public static void main(String[] args) {
        String path = "C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml";
        Document doc = lib.crearArbol(path);
        BorrarPelicula(doc, "Dune");

        try {
            lib.guardar(doc, path);
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | FileNotFoundException e) {
            System.out.println("ERROR GUARDANDO EL FICHERO");
            e.printStackTrace();
        }

    }
}
