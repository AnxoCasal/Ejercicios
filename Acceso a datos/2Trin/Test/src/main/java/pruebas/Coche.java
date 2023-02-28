package pruebas;

import java.util.ArrayList;

import javax.ws.rs.Consumes;
import javax.ws.rs.DefaultValue;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

@Path("/coches")
public class Coche {
	static ArrayList<Car> coches = new ArrayList<Car>();
	@DefaultValue("valor por defecto")
	@QueryParam("valor")
	String text;

	@POST
	@Consumes(MediaType.APPLICATION_XML)
	@Produces(MediaType.APPLICATION_JSON)
	public Response getCar(Car coche) {
		this.coches.add(coche); // Se añade el coche a la lista
		return Response.ok(coche).build(); // Se devuelve el coche
	}

	@GET
	@Produces({ MediaType.APPLICATION_JSON, MediaType.APPLICATION_XML })
	public ArrayList<Car> getXML() {
		Car c = new Car(); // Se crea un coche y se inicializan sus param.
		c.setMarca("Ford");
		c.setModelo("Focus");
		this.coches.add(c); // Se añade el coche a la lista
		return this.coches; // Se devuelve la lista de coches
	}
}
