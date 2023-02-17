package EjDOM;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class Ejer5 {

    public static void contarDires(Document doc, int num) {

        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();


        for (int i = 0; i < peliculas.getLength(); i++) {

            Node pelicula = peliculas.item(i);

            if (pelicula.getNodeName().equals("pelicula")) {
                int contDire = 0;

                NodeList titulos = ((Element) pelicula).getElementsByTagName("titulo");

                NodeList directores = ((Element) pelicula).getElementsByTagName("director");
                for (int j = 0; j < directores.getLength(); j++) {
                    contDire++;
                }

                if(contDire>=num){
                    System.out.println("---------------------");
                    System.out.println(titulos.item(0).getFirstChild().getNodeValue());
                    System.out.println("---------------------");
                }

            }
        }
    }

    public static void main(String[] args) {
        Document doc = lib.crearArbol("C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml");
        contarDires(doc, 0);
    }
}
