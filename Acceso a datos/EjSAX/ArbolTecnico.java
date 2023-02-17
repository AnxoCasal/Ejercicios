package EjSAX;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class ArbolTecnico extends DefaultHandler {

    boolean b=true;
    @Override
    public void startElement(String uri, String localName, String qName,
            Attributes attributes) throws SAXException {

        System.out.print("<" + qName + ">");
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        String titulo = new String(ch, start, length);
        System.out.print(titulo);
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {

        System.out.print("</" + qName + ">");
    }
}