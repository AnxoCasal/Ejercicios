package EjDOM;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class Ejer4 {


    public static void getDatos(Document doc) {

        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();

        System.out.println("---------------------");

        for (int i = 0; i < peliculas.getLength(); i++) {

            Node pelicula = peliculas.item(i);

            if (pelicula.getNodeName().equals("pelicula")) {

                NodeList titulos = ((Element) pelicula).getElementsByTagName("titulo");
                System.out.println(titulos.item(0).getFirstChild().getNodeValue());

                NodeList directores = ((Element) pelicula).getElementsByTagName("director");
                for (int j = 0; j < directores.getLength(); j++) {

                    NodeList DatosDirectores = directores.item(j).getChildNodes();

                    for (int l = 0; l < DatosDirectores.getLength(); l++) {
                        if (DatosDirectores.item(l).getNodeName().equals("nombre")) {
                            System.out.print(DatosDirectores.item(l).getFirstChild().getNodeValue()+" - ");
                        } else if (DatosDirectores.item(l).getNodeName().equals("apellido")) {
                            System.out.println(DatosDirectores.item(l).getFirstChild().getNodeValue());
                        }
                    }
                }

                if (pelicula.hasAttributes()) {
                    NamedNodeMap atributos = pelicula.getAttributes();
                    for (int j = 0; j < atributos.getLength(); j++) {
                        Node atributo = atributos.item(j);
                        if (atributo.getNodeName() == "idioma") {
                            System.out.printf("%s: %s%n",
                                    atributo.getNodeName().toUpperCase(), atributo.getNodeValue());
                        }
                        if (atributo.getNodeName() == "genero") {
                            System.out.printf("%s: %s%n",
                                    atributo.getNodeName().toUpperCase(), atributo.getNodeValue());
                        }
                        if (atributo.getNodeName() == "año") {
                            System.out.printf("%s: %s%n",
                                    atributo.getNodeName().toUpperCase(), atributo.getNodeValue());
                        }
                    }
                }

                System.out.println("---------------------");
            }
        }
    }

    public static void main(String[] args) {

        Document doc = lib.crearArbol("C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml");

        getDatos(doc);
    }

}
