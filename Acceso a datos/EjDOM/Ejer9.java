package EjDOM;

import java.io.FileNotFoundException;

import javax.lang.model.element.Element;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;

public class Ejer9 {

    public static void cambiarNombreDire(Document doc, String nombre_viejo, String nombre_nuevo) {
        Node filmoteca = doc.getFirstChild();
        NodeList peliculas = filmoteca.getChildNodes();

        for (int i = 0; i <peliculas.getLength(); i++){
            Node pelicula = peliculas.item(i);
            NodeList hijos_pelicula = pelicula.getChildNodes();
            for (int j = 0; j < hijos_pelicula.getLength(); j++) {
                Node node = hijos_pelicula.item(j);
                if(node.getNodeName().equals("director")){
                    NodeList datosDirector = node.getChildNodes();
                    for (int k = 0; k < datosDirector.getLength(); k++) {
                        Node datoDirector = datosDirector.item(k);
                        if(datoDirector.getNodeName().equals("nombre") && datoDirector.getFirstChild().getNodeValue().equals(nombre_viejo)){
                            datoDirector.removeChild(datoDirector.getFirstChild());
                            Text textNodeNombre = doc.createTextNode(nombre_nuevo);
                            datoDirector.appendChild(textNodeNombre);
                        }
                    }
                }
            }
        }
    }


    public static void main(String[] args) {
        String path = "C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml";
        Document doc = lib.crearArbol(path);
        cambiarNombreDire(doc, "Larry", "Lana");

        try {
            lib.guardar(doc, path);
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | FileNotFoundException e) {
            System.out.println("ERROR GUARDANDO EL FICHERO");
            e.printStackTrace();
        }

    }
}
