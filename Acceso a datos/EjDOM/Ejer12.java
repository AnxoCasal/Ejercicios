package EjDOM;

import java.io.FileNotFoundException;

import javax.lang.model.element.Element;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Document;
import org.w3c.dom.Node;

public class Ejer12 {

    public static Document crearArbolEmpresa() throws ParserConfigurationException {

        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory.newDocumentBuilder();

        Document doc2 = builder.newDocument();

        Node compañia = doc2.createElement("compañia");
        Node empleadNode = doc2.createElement("empleado");
        Node nombreNode = doc2.createElement("nombre");
        Node apellidoNode = doc2.createElement("apellido");
        Node apodoNode = doc2.createElement("apodo");
        Node salarioNode = doc2.createElement("salario");

        ((DocumentBuilderFactory) empleadNode).setAttribute("ID", "1");

        nombreNode.appendChild(doc2.createTextNode("Juan"));
        empleadNode.appendChild(nombreNode);

        apellidoNode.appendChild(doc2.createTextNode("López Perez"));
        empleadNode.appendChild(apellidoNode);

        apodoNode.appendChild(doc2.createTextNode("Juanin"));
        empleadNode.appendChild(apodoNode);

        salarioNode.appendChild(doc2.createTextNode("1000"));
        empleadNode.appendChild(salarioNode);

        compañia.appendChild(empleadNode);
        doc2.appendChild(compañia);
        return doc2;

    }

    public static void main(String[] args) {

        String path = "C:\\Anxo\\Acceso a datos\\EjDOM\\compañia.xml";
        try {

            lib.guardar(crearArbolEmpresa(), path);
        } catch (ParserConfigurationException | ClassNotFoundException | InstantiationException | IllegalAccessException
                | FileNotFoundException e1) {
            e1.printStackTrace();
        }

    }
}
