package EjDOM;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.bootstrap.DOMImplementationRegistry;
import org.w3c.dom.ls.DOMImplementationLS;
import org.w3c.dom.ls.LSOutput;
import org.w3c.dom.ls.LSSerializer;

public class lib {

    public static Document crearArbol(String ruta) {

        Document doc = null;

        try {

            DocumentBuilderFactory factoria = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factoria.newDocumentBuilder();
            return builder.parse(ruta);

        } catch (Exception e) {
            return doc;
        }

    }

    public static void guardar(Document document, String ficheroSalida)
            throws ClassNotFoundException, InstantiationException,
            IllegalAccessException, FileNotFoundException {
        DOMImplementationRegistry registry = DOMImplementationRegistry.newInstance();
        DOMImplementationLS ls = (DOMImplementationLS) registry.getDOMImplementation("XML 3.0 LS 3.0");

        LSOutput output = ls.createLSOutput();
        output.setEncoding("UTF-8");

        output.setByteStream(new FileOutputStream(ficheroSalida));

        LSSerializer serializer = ls.createLSSerializer();

        serializer.setNewLine("\r\n");
        ;
        serializer.getDomConfig().setParameter("format-pretty-print", true);

        serializer.write(document, output);

    }

}
