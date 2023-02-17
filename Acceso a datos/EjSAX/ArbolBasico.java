package EjSAX;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class ArbolBasico extends DefaultHandler {

    boolean txt = false;
    boolean genero = false;
    String generoTxt;

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        switch (qName) {

            case "pelicula":
                for (int i = 0; i < attributes.getLength(); i++) {
                    if (attributes.getLocalName(i).equals("genero")) {
                        genero = true;
                        generoTxt = attributes.getValue(i);
                    }
                }
                break;

            case "titulo":
                System.out.print("\n\nTitulo: ");
                txt = true;
                break;
            case "director":
                System.out.print("\nDirector: ");
                break;
            case "nombre":
                txt = true;
                break;
            case "apellido":
                txt = true;
                break;

            default:
                break;
        }
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        if (txt) {
            String data = new String(ch, start, length);
            System.out.print(data + " ");
        }

    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        txt = false;
        if (qName.equals("pelicula") && genero) {
            genero = false;
            System.out.println("\nGenero: " + generoTxt);
        }
    }
}
