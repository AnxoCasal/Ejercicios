
package com.anxo;

import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.time.Instant;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;

import javax.json.Json;
import javax.json.JsonArray;
import javax.json.JsonObject;
import javax.json.JsonReader;
import javax.json.JsonValue;

public class Jsonn {

  public JsonValue leerHttp(String direccion) throws IOException {
    URL url = new URL(direccion);
    try (InputStream is = url.openStream();
        JsonReader reader = Json.createReader(is)) {
      return reader.read();
    }
  }

  public JsonObject objctFromHttp(String direccion) throws IOException {
    URL url = new URL(direccion);
    try (InputStream is = url.openStream();
        JsonReader reader = Json.createReader(is)) {
      return reader.read().asJsonObject();
    }
  }

  // EJERCICIO 1

  public String getTiempoCiudad(String localidad) throws IOException {
    JsonValue json = leerHttp("http://api.openweathermap.org/data/2.5/weather?q=" + localidad
        + ",es&lang=es&APPID=8f8dccaf02657071004202f05c1fdce0&units=metric");
    return json.toString();
  }

  // EJERCICIO 2

  public String getTiempoCoord(double lat, double lon) throws IOException {
    JsonValue json = leerHttp("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon
        + "&APPID=8f8dccaf02657071004202f05c1fdce0");
    return json.toString();
  }

  // EJERCICIO 3

  public String getTiempoCoordCercanas(double lat, double lon, int numResults) throws IOException {
    JsonValue json = leerHttp("http://api.openweathermap.org/data/2.5/find?lat=" + lat + "&lon=" + lon
        + "&cnt=" + numResults + "&APPID=8f8dccaf02657071004202f05c1fdce0");
    return json.toString();
  }

  public JsonValue getTiempoCoordCercanasJsonValue(double lat, double lon, int numResults) throws IOException {
    JsonValue json = leerHttp("http://api.openweathermap.org/data/2.5/find?lat=" + lat + "&lon=" + lon
        + "&cnt=" + numResults + "&APPID=8f8dccaf02657071004202f05c1fdce0");
    return json;
  }

  // EJERCICIO 4

  public double getIdCiudad(String localidad) throws IOException {
    JsonObject json = objctFromHttp("http://api.openweathermap.org/data/2.5/weather?q=" + localidad
        + ",es&lang=es&APPID=8f8dccaf02657071004202f05c1fdce0&units=metric");

    return json.getJsonNumber("id").doubleValue();
  }

  // EJERCICIO 5

  public String getNombreCiudad(int id) throws IOException {
    JsonObject json = objctFromHttp(
        "http://api.openweathermap.org/data/2.5/weather?id=" + id + "&lang=es&APPID=8f8dccaf02657071004202f05c1fdce0");

    return json.getJsonString("name").toString();
  }

  // EJERCICIO 6

  public String[] getCoordCiudad(String localidad) throws IOException {
    JsonObject json = objctFromHttp("http://api.openweathermap.org/data/2.5/weather?q=" + localidad
        + ",es&lang=es&APPID=8f8dccaf02657071004202f05c1fdce0&units=metric");

    String[] coord = { json.getJsonObject("coord").getJsonNumber("lon").toString(),
        json.getJsonObject("coord").getJsonNumber("lat").toString() };
    return coord;

  }

  // EJERCICIO 7

  public String DatosCiudad(String localidad) throws IOException {
    String datos;

    JsonObject json = objctFromHttp("http://api.openweathermap.org/data/2.5/weather?q=" + localidad
        + ",es&lang=es&APPID=8f8dccaf02657071004202f05c1fdce0&units=metric");
    datos = "Date/Time: " + this.unixTimeToString(json.getJsonNumber("dt").longValue()) + "\n";
    datos += "Temperature: " + json.getJsonObject("main").getJsonNumber("temp").toString() + "\n";
    datos += "Humidity: " + json.getJsonObject("main").getJsonNumber("humidity").toString() + "\n";
    datos += "Clouds: " + json.getJsonObject("clouds").getJsonNumber("all").toString() + "\n";
    datos += "Wind Speed: " + json.getJsonObject("wind").getJsonNumber("speed").toString() + "\n";
    JsonArray aux = json.getJsonArray("weather");
    for (int i = 0; i < aux.size(); i++) {
      datos += "Forecast: " + aux.getJsonObject(i).getString("description");
    }

    return datos;
  }

  public String DatosMultiplesCiudades(JsonValue jValue) throws IOException {
    String datos = "";

    JsonObject jsonAux = jValue.asJsonObject();

    JsonArray list = jsonAux.getJsonArray("list");

    for (int i = 0; i < list.size(); i++) {

      JsonObject json = list.getJsonObject(i);
      datos += "\n\nZone: " + json.getJsonString("name").toString() + "\n";
      datos += "Date/Time: " + this.unixTimeToString(json.getJsonNumber("dt").longValue()) + "\n";
      datos += "Temperature: " + json.getJsonObject("main").getJsonNumber("temp").toString() + "\n";
      datos += "Humidity: " + json.getJsonObject("main").getJsonNumber("humidity").toString() + "\n";
      datos += "Clouds: " + json.getJsonObject("clouds").getJsonNumber("all").toString() + "\n";
      datos += "Wind Speed: " + json.getJsonObject("wind").getJsonNumber("speed").toString() + "\n";
      JsonArray aux = json.getJsonArray("weather");
      for (int j = 0; j < aux.size(); j++) {
        datos += "Forecast: " + aux.getJsonObject(j).getString("description");
      }
    }

    return datos;
  }

  // Ejercicio 8

  public void DatosZona(String localidad, int numCiudades) throws NumberFormatException, IOException {

    String[] coord = getCoordCiudad(localidad);
    JsonValue datos = getTiempoCoordCercanasJsonValue(Double.parseDouble(coord[1]), Double.parseDouble(coord[0]),
        numCiudades);
    System.out.println(DatosMultiplesCiudades(datos));
  }

  // Pasar dato DATE a string

  public String unixTimeToString(long unixTime) {
    final DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
    return Instant.ofEpochSecond(unixTime).atZone(ZoneId.of("GMT+1")).format(formatter);
  }

  // Ejercicio 9

  public String Trivia() throws IOException {

    String text = "";
    JsonObject json = objctFromHttp("https://opentdb.com/api.php?amount=10&category=18&difficulty=hard&type=multiple");
    JsonArray array = json.getJsonArray("results");
    for (int i = 0; i < array.size(); i++) {
      JsonObject objct = array.getJsonObject(i);

      text += "\nQuestion: " + objct.getJsonString("question") + "\n";
      text += "X - " + objct.getJsonString("correct_answer") + "\n";

      JsonArray answers = objct.getJsonArray("incorrect_answers");
      for (int j = 0; j < answers.size(); j++) {
        text += "0 - " + answers.getString(j) + "\n";
      }
    }
    return text;
  }

  // Ejercicio 10

  public String ticketMaster(String type, String country) throws IOException {

    String data = "";
    JsonObject json = objctFromHttp("https://app.ticketmaster.com/discovery/v2/events.json?classificationName=" + type
        + "&countryCode=" + country + "&apikey=AMXR5Rf8zlr7oGucsebGKvDCLOQmGUGE");
    System.out.println("EVENTS IN " + country + " OF " + type);
    JsonArray lista = json.getJsonObject("_embedded").getJsonArray("events");
    for (int i = 0; i < lista.size(); i++) {
      data += i + " - " + lista.get(i).asJsonObject().getString("name") + "\n\r";
    }

    return data;
  }

  // Ejercicio 11

  public String ticketMasterLugarCompleto(String type, String country) throws IOException {

    String data = "";
    JsonObject json = objctFromHttp("https://app.ticketmaster.com/discovery/v2/events.json?classificationName=" + type
        + "&countryCode=" + country + "&apikey=AMXR5Rf8zlr7oGucsebGKvDCLOQmGUGE");
    System.out.println("EVENTS IN " + country + " OF " + type);
    JsonArray lista = json.getJsonObject("_embedded").getJsonArray("events");
    for (int i = 0; i < lista.size(); i++) {
      data += i + " - " + lista.get(i).asJsonObject().getString("name") + "\n\r";
      JsonArray lista2 = lista.get(i).asJsonObject().getJsonObject("_embedded").getJsonArray("venues");
      for (int j = 0; j < lista2.size(); j++) {
        data += "Pais: " + lista2.get(j).asJsonObject().getJsonObject("city").getJsonString("name") + "\n\r";
        data += "City: " + lista2.get(j).asJsonObject().getJsonObject("country").getJsonString("name") + "\n\r";
        data += "Local: " + lista2.get(j).asJsonObject().getJsonString("name") + "\n\r";
        data += "Codigo Postal: " + lista2.get(j).asJsonObject().getJsonString("postalCode") + "\n\r";
      }
      data+="\n\r";
    }

    return data;
  }

  public String ticketMasterEventoCompleto(String type, String country) throws IOException {

    String data = "";
    JsonObject json = objctFromHttp("https://app.ticketmaster.com/discovery/v2/events.json?classificationName=" + type
        + "&countryCode=" + country + "&apikey=AMXR5Rf8zlr7oGucsebGKvDCLOQmGUGE");
    System.out.println("EVENTS IN " + country + " OF " + type);
    JsonArray lista = json.getJsonObject("_embedded").getJsonArray("events");
    for (int i = 0; i < lista.size(); i++) {
      data += i + " - " + lista.get(i).asJsonObject().getString("name") + "\n\r";
      data += lista.get(i).asJsonObject().getString("type") + "\n\r";
      data += lista.get(i).asJsonObject().getJsonObject("dates").getJsonObject("start").getJsonString("localDate")
          + "\n\r";
      data += lista.get(i).asJsonObject().getJsonObject("dates").getJsonObject("start").getJsonString("localTime")
          + "\n\r\n\r";
    }

    return data;
  }

  // Ejercicio 12

  public String ticketMasterTiempoLocal(String type, String country) throws IOException {

    String data = "";
    JsonObject json = objctFromHttp("https://app.ticketmaster.com/discovery/v2/events.json?classificationName=" + type
        + "&countryCode=" + country + "&apikey=AMXR5Rf8zlr7oGucsebGKvDCLOQmGUGE");
    System.out.println("EVENTS IN " + country + " OF " + type);
    JsonArray lista = json.getJsonObject("_embedded").getJsonArray("events");
    for (int i = 0; i < lista.size(); i++) {
      data += i + " - " + lista.get(i).asJsonObject().getString("name") + "\n\r";
      JsonArray lista2 = lista.get(i).asJsonObject().getJsonObject("_embedded").getJsonArray("venues");
      for (int j = 0; j < lista2.size(); j++) {
        data += "Pais: " + lista2.get(j).asJsonObject().getJsonObject("city").getJsonString("name") + "\n\r";
      }
      data += "Local Time: "+lista.get(i).asJsonObject().getJsonObject("dates").getJsonObject("start").getJsonString("localTime") + "\n\r";
      data+="\n\r";
    }

    return data;
  }

}
