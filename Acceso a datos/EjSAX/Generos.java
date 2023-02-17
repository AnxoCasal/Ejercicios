package EjSAX;

import java.util.ArrayList;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class Generos extends DefaultHandler {
    ArrayList<String> Generos = new ArrayList<>();

    boolean exists = false;

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        if(qName.equals("pelicula")){
            for (int i = 0; i < attributes.getLength(); i++) {
                if(attributes.getLocalName(i).equals("genero")){
                    for (String generoExistente : Generos) {
                        if(attributes.getValue(i).equals(generoExistente)){
                            exists = true;
                        }
                    }
                    if(!exists){
                        Generos.add(attributes.getValue(i));
                    }
                }
            }
        }
    }

    @Override
    public void endDocument() throws SAXException {
        for (String string : Generos) {
            System.out.println(string);
        }
    }
}
