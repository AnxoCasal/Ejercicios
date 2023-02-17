package EjDOM;

import java.io.FileNotFoundException;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class Ejer7 {

    public static void añadirAtributo(Document doc, String peliculaNombre, String newAtributo, String valor) {

        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();
        boolean exists = false;

        for (int i = 0; i < peliculas.getLength(); i++) {

            Node pelicula = peliculas.item(i);

            if (pelicula.getNodeName().equals("pelicula")) {

                NodeList titulos = ((Element) pelicula).getElementsByTagName("titulo");
                if (peliculaNombre.equals(titulos.item(0).getFirstChild().getNodeValue())) {

                    if (pelicula.hasAttributes()) {
                        NamedNodeMap atributos = pelicula.getAttributes();
                        for (int j = 0; j < atributos.getLength(); j++) {
                            Node atributo = atributos.item(j);
                            if (atributo.getNodeName().equals(newAtributo)) {
                                exists = true;
                            }
                        }
                    }

                    if (!exists) {
                        ((Element) pelicula).setAttribute(newAtributo, valor);
                    }

                }
            }
        }

    }

    public static void eliminarAtributo(Document doc, String peliculaNombre, String atributoObjetivo) {
        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();

        for (int i = 0; i < peliculas.getLength(); i++) {

            Node pelicula = peliculas.item(i);

            if (pelicula.getNodeName().equals("pelicula")) {

                NodeList titulos = ((Element) pelicula).getElementsByTagName("titulo");
                if (peliculaNombre.equals(titulos.item(0).getFirstChild().getNodeValue())) {

                    if (pelicula.hasAttributes()) {
                        NamedNodeMap atributos = pelicula.getAttributes();
                        for (int j = 0; j < atributos.getLength(); j++) {
                            Node atributo = atributos.item(j);
                            if (atributo.getNodeName().equals(atributoObjetivo)) {
                                ((Element) pelicula).removeAttribute(atributoObjetivo);
                            }
                        }
                    }

                }
            }
        }
    }


    public static void main(String[] args) {

        String path = "C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml";
        Document doc = lib.crearArbol(path);
        eliminarAtributo(doc, "Matrix", "genero");
        añadirAtributo(doc, "Matrix", "genero", "Comunismo");
        try {
            lib.guardar(doc, path);
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | FileNotFoundException e) {
            System.out.println("ERROR GUARDANDO EL FICHERO");
            e.printStackTrace();
        }

    }
}
