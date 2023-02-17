package EjSAX;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class RecorrerFichero extends DefaultHandler {

    boolean okay = false;



    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        switch (qName) {
            case "titulo":
                okay = true;
                break;
            case "nombre":
                okay = true;
                break;
            case "apellido":
                okay = true;
                break;

            default:
                break;
        }
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        if (okay) {
            String data = new String(ch, start, length);
            System.out.println(data);
        }

    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        okay = false;
    }
}
