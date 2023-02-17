package EjDOM;

import java.util.ArrayList;

import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class Ejer6 {

    public static void mostrarGeneros(Document doc) {

        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();
        ArrayList<String> generos = new ArrayList<>();

        for (int i = 0; i < peliculas.getLength(); i++) {

            Node pelicula = peliculas.item(i);

            if (pelicula.getNodeName().equals("pelicula")) {

                if (pelicula.hasAttributes()) {
                    NamedNodeMap atributos = pelicula.getAttributes();

                    for (int j = 0; j < atributos.getLength(); j++) {
                        Node atributo = atributos.item(j);

                        if (atributo.getNodeName() == "genero") {
                            boolean exists = false;
                            for (String string : generos) {

                                if (string.equals(atributo.getNodeValue()) ) {
                                    exists = true;
                                }

                            }
                            if (!exists) {
                                generos.add(atributo.getNodeValue());
                            }
                        }
                    }
                }
            }
        }

        for (String string : generos) {
            System.out.println(string);
        }

    }

    public static void main(String[] args) {

        Document doc = lib.crearArbol("C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml");
        mostrarGeneros(doc);

    }
}
