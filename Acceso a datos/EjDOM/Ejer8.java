package EjDOM;

import java.io.FileNotFoundException;

import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.Text;

public class Ejer8 {

    

    public static boolean añadirPelicula(Document doc, String titulo, String director,
            String estreno, String genero) {
        try {
            
            Element nodoPelicula = doc.createElement("Pelicula");
            
            nodoPelicula.setAttribute("genero", genero);
            
            nodoPelicula.appendChild(doc.createTextNode("\n"));
            
            Element nodoTitulo = doc.createElement("Título");
            Text textNodoTitulo = doc.createTextNode(titulo);
            nodoTitulo.appendChild(textNodoTitulo);
            nodoPelicula.appendChild(nodoTitulo);
            
            nodoPelicula.appendChild(doc.createTextNode("\n"));
            
            Element nodoDirector = doc.createElement("Director");
            Text textNodoDirector = doc.createTextNode(director);
            nodoDirector.appendChild(textNodoDirector);
            nodoPelicula.appendChild(nodoDirector);
            
            nodoPelicula.appendChild(doc.createTextNode("\n"));
            
            Element nodoEstreno = doc.createElement("Estreno");
            Text textNodoEstreno = doc.createTextNode(estreno);
            nodoEstreno.appendChild(textNodoEstreno);
            nodoPelicula.appendChild(nodoEstreno);
            
            Node raiz = doc.getFirstChild();
            raiz.appendChild(nodoPelicula);
            return true;
        } catch (DOMException e) {
            return false;
        }
    }

    

    public static void main(String[] args) {

        String path = "C:\\Anxo\\Acceso a datos\\EjDOM\\peliculas.xml";
        Document doc = lib.crearArbol(path);
        añadirPelicula(doc, "Depredador", "John Tiernan", "1987", "Accion");
        

        try {
            lib.guardar(doc, path);
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | FileNotFoundException e) {
            System.out.println("ERROR GUARDANDO EL FICHERO");
            e.printStackTrace();
        }

    }
}
