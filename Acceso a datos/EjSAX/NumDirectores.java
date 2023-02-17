package EjSAX;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class NumDirectores extends DefaultHandler {

    Boolean txt = false;
    String titulo;
    int numDire;
    int cont = 0;

    public NumDirectores(int numDire){
        this.numDire = numDire;
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        if(qName.equals("titulo")){
            txt = true;
        }
        if(qName.equals("director")){
            cont++;
        }
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        if (txt){
            String data = new String(ch, start, length);
            titulo = data;
            txt = false;
        }
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        if(qName.equals("pelicula")){
            if(cont>=numDire){
                System.out.println(titulo);
            }
            cont = 0;
        }
    }
}
