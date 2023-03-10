package com.example.ejer6;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.ActivityNotFoundException;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Calendar;

public class MainActivity extends AppCompatActivity {
    Button showMenu;
    RecyclerView.LayoutManager myLayoutManager;
    RecyclerView.LayoutManager myLayoutManager2;
    Adapter adapter;
    AdapterComplete adapterComplete;
    RecyclerView rv;
    RecyclerView rvComplete;
    TextView tituloSelected;

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.menu,menu);
        return  true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.btnCompleteList:
                if (rv.getVisibility()==View.VISIBLE){
                    rv.setVisibility(View.INVISIBLE);
                    rvComplete.setVisibility(View.VISIBLE);
                }else {
                    rv.setVisibility(View.VISIBLE);
                    rvComplete.setVisibility(View.INVISIBLE);
                }
                return true;
            case R.id.btnFavorites:
                return true;
            case R.id.btnNueva:
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        showMenu = (Button) findViewById(R.id.btnShowMenu);
        ActionBar actionBar = getSupportActionBar();

        ArrayList<Pelicula> peliculas = rellenaPeliculas();
        tituloSelected = (TextView) findViewById(R.id.selectedTitle);
        adapter = new Adapter(peliculas, tituloSelected);
        adapterComplete = new AdapterComplete(peliculas, tituloSelected);
        rv = findViewById(R.id.rv);
        rvComplete = findViewById(R.id.rvComplete);
        myLayoutManager = new LinearLayoutManager(this);
        myLayoutManager2 = new LinearLayoutManager(this);


        rv.setLayoutManager(myLayoutManager);
        rv.setAdapter(adapter);
        rv.setHasFixedSize(true);
        rvComplete.setLayoutManager(myLayoutManager2);
        rvComplete.setAdapter(adapterComplete);
        rvComplete.setHasFixedSize(true);

        showMenu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (actionBar.isShowing()){
                    actionBar.hide();
                } else {
                    actionBar.show();
                }
            }
        });

    }


    public void watchYoutubeVideo(String id) {
        Intent appIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("vnd.youtube:" + id));
        Intent webIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://www.youtube.com/watch?v=" + id));
        try {
            startActivity(appIntent);
        } catch (ActivityNotFoundException ex) {
            startActivity(webIntent);
        }
    }

    public void cambiarTituloSelected(String newText){
        tituloSelected.setText(newText);
    }

    public ArrayList<Pelicula> rellenaPeliculas() {

        ArrayList<Pelicula> peliculas = new ArrayList<Pelicula>();

        Calendar cal = Calendar.getInstance();
        cal.set(1982, 12, 3);
        Pelicula dune = new Pelicula("Dune", "Lynch", 180, cal.getTime(), "Gran v??a", R.drawable.g, R.drawable.dune);
        dune.setSinopsis("Por orden imperial, la familia Atreides deber?? hacerse cargo de la explotaci??n del des??rtico planeta de Arrakis, conocido tambi??n como \"Dune\" " +
                "que es el ??nico planeta donde se encuentra la especia, una potente droga que, adem??s, es necesaria para los vuelos espaciales. Anteriormente, el planeta " +
                "hab??a sido gobernado por los Harkonen, que hab??an ejercido su mandato con pu??o de hierro, dejando una huella indeleble en la poblaci??n ind??gena del planeta" +
                ". Cuando los Harkonen atacan el planeta con el benepl??cito del Emperador para retomar su posici??n dominante sobre el planeta, Paul, el hijo del duque Leto " +
                "Atreides, deber?? huir al desierto, donde le esperan m??ltiples peligros y una ??ltima oportunidad de vengarse y volver a su leg??timo lugar como gobernante de" +
                " Arrakis");
        dune.setIdYoutube("KwPTIEWTYEI");
        peliculas.add(dune);

        cal.set(1972, 3, 5);
        Pelicula a2001 = new Pelicula("2001", "Kubric", 130, cal.getTime(), "Plaza el??ptica", R.drawable.pg, R.drawable.d2001);
        a2001.setSinopsis("La secuencia inicial del filme se inicia con la imagen de la Tierra ascendiendo sobre la Luna, mientras que el Sol asciende a su vez sobre la " +
                "Tierra, todos en alineaci??n. En este momento comienza a escucharse la composici??n musical As?? habl?? Zaratustra de Richard Strauss, la misma que acompa??a, " +
                "en su mayor??a, la primera parte de la pel??cula titulada El Amanecer del Hombre.\n" +
                "El amanecer del hombre\n" +
                "\n" +
                "Presenta la vida cotidiana de un grupo de primates en una ??rida sabana (todo sugiere, como la ciencia lo comprueba, una sabana casi des??rtica (con casi " +
                "todas las probabilidades en lo que hoy es ??frica) unos 7 millones de a??os AP (v??ase: Hominina; aunque tal dataci??n era muy dudosa en la ??poca en que se " +
                "realiz?? el film) donde se les observa ramoneando en busca de alimento y conviviendo aparentemente de forma pac??fica. Despu??s uno de los miembros de esta " +
                "manada es atacado y muerto por un leopardo. Se muestra su disputa con otros grupos de primates muy similares por poder beber el agua de una charca y por el" +
                " espacio vital, pero sin llegar al contacto f??sico. Se muestra c??mo estos primates temen a la obscuridad nocturna y a sus depredadores por lo que descansan" +
                " con sue??o nervioso en el fondo de una peque??a cueva.\n" +
                "\n" +
                "En un amanecer despertado por extra??as vibraciones ac??sticas, uno de los primates se despierta y encuentra enfrente del refugio un monolito negro, un " +
                "bloque orto??drico perfecto de \"color\" negro de varios metros de altura que provoca la alarma en el grupo y un primer momento de confusi??n y miedo. Al " +
                "poco tiempo, se acercan y, confiando prudentemente, llegan incluso a acariciarlo como reverenci??ndolo. A la postre, uno de los simios se da cuenta de c??mo " +
                "utilizar un hueso como herramienta y arma al tiempo que se observan flashbacks mentales del monolito, sugiri??ndose que este ha motivado ciertos cambios en " +
                "la conducta de los primates y les ha dado cierto grado de conciencia sobre los recursos disponibles para sobrevivir debido a que ahora los monos son " +
                "capaces de matar animales y comer carne. A la ma??ana siguiente le arrebatan el control de la charca a la otra manada, matando mediante el hueso usado como " +
                "arma, en el proceso al l??der de la manada rival. Exultante con su triunfo, el primate vencedor lanza su hueso al aire, produci??ndose una enorme elipsis " +
                "temporal en la narraci??n: el hueso que asciende en el aire, pasa a convertirse en un ingenio espacial que surca el espacio entre la Tierra y la Luna en el " +
                "a??o 1999 de nuestra era; se lo ha denominado la ??elipsis m??s larga de la historia del cine?? de 4 millones de a??os.");
        a2001.setIdYoutube("XHjIqQBsPjk");
        peliculas.add(a2001);

        cal.set(1984, 11, 2);
        Pelicula akira = new Pelicula("Akira", "Otomo", 170, cal.getTime(), "Gran v??a", R.drawable.pg13, R.drawable.akira);
        akira.setSinopsis("Neo-Tokyo, 2019. Shotaro Kaneda sale junto con su pandilla de motociclistas (\"Los C??psulas\") a pelear contra un pandilla rival conocida como Los" +
                " Payasos. Sin embargo, el mejor amigo de Kaneda Tetsuo Shima sufre un accidente cuando choca su motocicleta contra Takashi, un ni??o esper que fue liberado " +
                "un laboratorio secreto del gobierno por una organizaci??n revolucionaria clandestina disidente. Takashi es capturado por soldados armados, Tetsuo es " +
                "hospitalizado. y la polic??a arresta a Kaneda y a su pandilla. Durante el interrogatorio de la polic??a, Kaneda se encuentra con Kei, una joven miembro de un" +
                " grupo revolucionario disidente. Kaneda se las arregla para ayudarla a salir y la pone en libertad junto con los miembros de su banda b??s??zoku.\n" +
                "\n" +
                "El Coronel Shikishima y el Doctor Onishi descubren que Tetsuo posee poderes ps??quicos similares a los de Akira, un ni??o esper que caus?? la destrucci??n de " +
                "Tokio 31 a??os atr??s cuando sus poderes se salieron de control, provocando la Tercera Guerra Mundial. Kiyoko, otra Ni??a esper, tiene visiones de la futura " +
                "destrucci??n de Neo-Tokyo, y el Coronel le ordena al Doctor Onishi que mate a Tetsuo en caso de que sus poderes se salgan de control. Tetsuo huye del " +
                "hospital, se re??ne con su novia Kaori, y ambos roban la moto de Kaneda. Tetsuo y Kaori son atrapados por los payasos, pero Kaneda y su pandilla los " +
                "rescatan. De repente, Tetsuo empieza a sufrir fuertes dolores de cabeza, la polic??a aparece de la nada junto con el Doctor Onishi y se llevan a Tetsuo de " +
                "vuelta al hospital.");
        akira.setIdYoutube("T9WTE3Q2G_Y");
        akira.setFavorita(true);
        peliculas.add(akira);

        cal.set(1995, 1, 2);
        Pelicula ia = new Pelicula("IA", "Spielberg", 140, cal.getTime(), "Travesia", R.drawable.r, R.drawable.ia);
        ia.setSinopsis("A mediados del siglo XXI, el calentamiento global provoc?? que las capas de hielo de los polos se derritieran, inundaran las costas y se redujera " +
                "dr??sticamente los recursos del mundo. Hay una nueva clase de robots llamados Mecas, humanoides avanzados capaces de emular pensamientos y emociones. " +
                "Los humanos necesitan gracias a la falta de recursos permisos de natalidad, que eran muy dif??ciles de adquirir. Por esto crean a David (Haley Joel Osment), " +
                "un modelo prototipo creado por Cybertronics de Nueva Jersey, es dise??ado para parecerse a un ni??o humano y mostrar amor para sus poseedores humanos." +
                " Un hijo robot. Ellos analizan su creaci??n con uno de sus empleados, Henry Swinton (Sam Robards), y su esposa M??nica (Frances O'Connor). " +
                "El hijo de los Swinton, Mart??n (Jake Thomas), fue puesto en animaci??n suspendida hasta que se pudiera encontrar una cura para su rara enfermedad. " +
                "Aunque al inicio, M??nica se asusta de David, finalmente siente cari??o por ??l despu??s de activar su protocolo de impresi??n, que irreversiblemente causa que " +
                "David la ame, de la misma forma en que cualquier ni??o amar??a a una madre. Tambi??n se hace amigo de Teddy (Jack Angel), un osito de peluche rob??tico, quien " +
                "vela por el bienestar de David.");
        ia.setIdYoutube("vN_Hx_It3r0");
        peliculas.add(ia);

        cal.set(1999, 6, 23);
        Pelicula matrix = new Pelicula("Matrix", "Lana Wachowski, Lilly Wachowski", 136, cal.getTime(), "Gran v??a", R.drawable.pg13, R.drawable.matrix);
        matrix.setSinopsis("La pel??cula plantea que en el futuro, casi todos los seres humanos han sido esclavizados, tras una dura guerra, por las m??quinas y las " +
                "inteligencias artificiales creadas. Estas los tienen en suspensi??n, y con sus mentes conectadas a una simulaci??n social que representa el final del siglo " +
                "XX, Matrix. Los seres humanos son usados por las m??quinas para obtener energ??a, y los pocos humanos descendientes de los que no cayeron en las redes de los" +
                " robots o que han sido liberados de Matrix, viven en la ciudad Sion. Desde all??, una peque??a flota de naves se mueve por el subsuelo, entrando de forma " +
                "clandestina a Matrix y tratando de liberar cada vez a m??s personas conectadas, buscando a aquellos que intuyen que algo no es correcto en el ilusorio mundo" +
                " en que viven. Algunos de los capitanes de estas naves, como Morfeo (Laurence Fishburne), creen que hay alguien en Matrix que es El Elegido, la persona que" +
                " acabar??a con la guerra, con las m??quinas, seg??n una antigua profec??a. Morfeo se fija en Neo (Keanu Reeves), un pirata inform??tico que vive atrapado en " +
                "Matrix sin saberlo, creyendo que ??l puede ser el elegido.\n" +
                "\n" +
                "Neo es liberado gracias a la acci??n de Trinity (Carrie-Anne Moss), miembro de la tripulaci??n de Morfeo, pero a la vez es perseguido por unos programas de " +
                "Matrix, los agentes, liderados por Smith (Hugo Weaving), que pretenden acceder a los ordenadores de Sion gracias a la traici??n de otro subordinado de " +
                "Morfeo, Cypher. Los agentes consiguen capturar a Morfeo, y Neo es forzado a rescatarle arriesgando su vida. Al final de la primera pel??cula Neo se revela " +
                "como El Elegido y acaba con Smith.\n" +
                "\n" +
                "En las siguientes entregas, la acci??n se divide entre la realidad, donde las m??quinas deciden atacar directamente Zion, y el mundo virtual, donde Smith " +
                "est?? infectando Matrix como un virus.");
        matrix.setIdYoutube("vN_Hx_It3r0");
        peliculas.add(matrix);

        cal.set(1982, 8, 21);
        Pelicula br = new Pelicula("Blade Runner", "Ridley Scott", 117, cal.getTime(), "Plaza el??ptica", R.drawable.pg, R.drawable.blade);
        br.setSinopsis("En la ciudad de Los ??ngeles, en noviembre de 2019, Rick Deckard (Harrison Ford) es llamado de su retiro cuando un Blade Runner excesivamente " +
                "confiado ???Holden (Morgan Paull)??? recibe un tiro mientras llevaba a cabo la prueba Voight-Kampff a Leon (Brion James), un replicante fugitivo.\n" +
                "\n" +
                "Deckard, dubitativo, se encuentra con Bryant (M. Emmet Walsh), su antiguo jefe, quien le informa que la reciente fuga de replicantes Nexus-6 es la peor " +
                "hasta el momento. Bryant informa a Deckard acerca de los replicantes: Roy Batty (Rutger Hauer) es un comando, Leon es soldado y obrero, Zhora (Joanna " +
                "Cassidy) es una trabajadora sexual entrenada como asesina y Pris (Daryl Hannah) un 'modelo b??sico de placer'. Bryant tambi??n le explica que el modelo " +
                "Nexus-6 tiene una vida limitada a cuatro a??os como salvaguarda contra su desarrollo emocional inestable. Deckard es acompa??ado por Gaff (Edward James " +
                "Olmos) a la Tyrell Corporation para comprobar que la prueba Voight-Kampff funciona con los modelos Nexus-6. Ah??, Deckard descubre que Rachael (Sean Young)," +
                " la joven secretaria de Tyrell (Joe Turkel) es una replicante experimental, con recuerdos implantados que le permiten contar con una base emocional.\n" +
                "Ennis House, localizaci??n para la casa de Deckard.\n" +
                "Interior del Bradbury Building, que sirvi?? como localizaci??n de la casa de Sebastian.\n" +
                "\n" +
                "Deckard y Gaff allanan el apartamento de Leon mientras ??l y Roy obligan a Chew (James Hong), un dise??ador gen??tico de ojos, a que les env??e con J.F. " +
                "Sebastian (William Sanderson), pues ??l les puede permitir llegar a Tyrell. M??s tarde, Rachael visita a Deckard en su apartamento para probarle que ella es " +
                "humana, pero huye llorando al enterarse de que sus recuerdos son artificiales. Pris conoce a Sebastian y se aprovecha de su bondad para lograr entrar en su" +
                " apartamento.\n" +
                "\n" +
                "Las pistas encontradas en el apartamento de Leon llevan a Deckard al bar de Taffy Lewis (Hy Pyke), lugar en que la tatuada Zhora realiza su espect??culo con" +
                " una serpiente. Zhora intenta desesperadamente huir de Deckard por las calles atestadas de gente, pero Deckard logra alcanzarla y la \"retira\". Tras el " +
                "tiroteo, Gaff y Bryant aparecen e informan a Deckard que tambi??n hay que \"retirar\" a Rachael. Convenientemente, Deckard observa a Rachael a lo lejos " +
                "pero, mientras la sigue, Leon lo desarma repentinamente, y Deckard recibe una paliza. Rachael dispara a Leon, salvando la vida de Deckard y ambos se " +
                "dirigen al apartamento de Rick, donde discuten las opciones que tiene Rachael. En un tranquilo instante de intimidad musical, ambos se empiezan a enamorar" +
                ".\n" +
                "\n" +
                "Entretanto, Roy llega al apartamento de Sebastian y se vale del encanto de Pris para convencer a Sebastian de ayudarle a reunirse con Tyrell. Ya en la " +
                "habitaci??n de Tyrell, Roy demanda que prolongue su vida y pide perd??n por sus pecados. Al no ver satisfecha ninguna de sus solicitudes, Roy asesina a " +
                "Tyrell y a Sebastian.\n" +
                "\n" +
                "Deckard es enviado al apartamento de Sebastian despu??s de los asesinatos. All??, Pris le prepara una emboscada, aunque Deckard consigue dispararle tras una " +
                "lucha. Roy regresa, atrapando a Deckard en el apartamento, y comienza a perseguirlo a trav??s del edificio Bradbury hasta llegar al tejado. Deckard intenta " +
                "escapar saltando a otro edificio quedando colgado de una viga. Roy cruza con facilidad y mira fijamente a Deckard ???en el momento en que ??ste se desprende " +
                "de la viga, Roy lo sujeta por la mu??eca, salv??ndole la vida???.\n" +
                "\n" +
                "Roy se est?? deteriorando muy r??pidamente (sus cuatro a??os de vida se acaban), se sienta y relata con elocuencia los grandes momentos de su vida " +
                "concluyendo: ??Todos esos momentos se perder??n en el tiempo como l??grimas en la lluvia. Es hora de morir??. Roy muere dejando escapar una paloma que tiene en" +
                " sus manos, mientras que Deckard lo mira en silencio. Gaff llega poco despu??s, y march??ndose, le grita a Deckard: ??L??stima que ella no pueda vivir, pero " +
                "??qui??n vive???.\n" +
                "\n" +
                "Deckard regresa a su apartamento y entra con cuidado, cuando nota que la puerta est?? entreabierta. All?? encuentra a Rachael, viva. Mientras se van del " +
                "lugar, Deckard encuentra un origami que ha dejado Gaff (se??al de que se les ha permitido escapar). Finalmente, la pareja se dirige a un futuro incierto.");
        br.setIdYoutube("LBbDxYuvdm4");
        peliculas.add(br);

        cal.set(1995, 1, 2);
        Pelicula inte = new Pelicula("Interstellar", "Christopher Nolan ", 169, cal.getTime(), "Travesia", R.drawable.g, R.drawable.interstellar);
        inte.setSinopsis("Al ver que la vida en la Tierra est?? llegando a su fin, un grupo de exploradores dirigidos por el piloto Cooper (McConaughey) y la cient??fica Amelia (Hathaway) emprenden una misi??n que puede ser la m??s importante de la historia de la humanidad, Viajan m??s all?? de nuestra galaxia para descubrir otra que pueda garantizar el futuro de la raza humana.");
        inte.setIdYoutube("UoSSbmD9vqc");
        peliculas.add(inte);

        cal.set(1995, 1, 2);
        Pelicula alien = new Pelicula("Alien", "Ridley Scott", 117, cal.getTime(), "Plaza el??ptica", R.drawable.pg13, R.drawable.alien);
        alien.setSinopsis("La nave espacial de transporte comercial U.S.C.S.S. Nostromo regresa a la Tierra proveniente del planeta ficticio Thedus,nota 1 con un remolque " +
                "de veinte millones de toneladas de mena.nota 2 Los siete miembros de la tripulaci??n est??n en un estado de sue??o criog??nico. Al recibir una transmisi??n de " +
                "origen desconocido, procedente al parecer de la luna de un planeta cercano,nota 3 el ordenador central de la nave, ??Madre??,nota 4 nota 5 despierta a la " +
                "tripulaci??n. En un principio creen que est??n en las proximidades de la Tierra, hasta que descubren que se hallan en una regi??n fuera del sistema solar. El " +
                "capit??n Dallas les comenta que la computadora cambi?? el rumbo de la nave para acudir a una se??al anormal que la nave recibe cada doce segundos, y que Madre" +
                " identifica como una alerta de auxilio. Dallas asume la responsabilidad de investigarla y, con la ayuda del oficial cient??fico Ash, persuade al resto del " +
                "equipo para que colabore. Gracias a c??lculos de trayectoria realizados por la nave, descubren que est??n en el sistema extrasolar Zeta II Reticuli, en los " +
                "l??mites de astronavegaci??n, y se dirigen hacia un destino desconocido.nota 6 Finalmente, la Nostromo llega a la luna de un planeta gigantesco gaseoso " +
                "anillado e inexplorado. En ella, la tripulaci??n desengancha a Nostromo del remolque y la nave desciende hacia donde se origin?? la transmisi??n; en su " +
                "aterrizaje, la nave sufre algunos da??os. El capit??n Dallas, el oficial ejecutivo Kane y la navegante Lambert salen a la superficie del planetoide a " +
                "investigar el origen de la se??al, mientras que la suboficial Ellen Ripley, Ash, y los ingenieros Brett y Parker se quedan en la nave para monitorearlos y " +
                "hacer reparaciones.\n" +
                "Fotograf??a de un modelo del xenomorfo.\n" +
                "\n" +
                "Dallas, Kane y Lambert descubren que la se??al viene de lo que parece ser una nave espacial alien??gena varada desde hace tiempo. Dentro encuentran los " +
                "restos fosilizados de un extraterreste gigante sentado en la silla del piloto, con un boquete en su abdomen perforado de adentro hacia afuera. Mientras " +
                "tanto, Ripley ordena a Madre que realice una minuciosa decodificaci??n binaria del c??digo extraterrestre para su interpretaci??n; durante la actividad, se " +
                "percata de que el mensaje es uno de advertencia y no una solicitud de socorro como les hizo creer la computadora. Dentro de la nave abandonada, Kane " +
                "descubre una enorme c??mara llena de numerosos huevos, uno de los cuales libera una criatura que se adhiere a su casco, derritiendo su visor y dej??ndolo " +
                "inconsciente. Dallas y Lambert lo llevan a la Nostromo, donde Ash les permite entrar, a pesar del protocolo de cuarentena activado por Ripley. Una vez en " +
                "el interior de la nave, Dallas y Ash intentan arrancar la alima??a del rostro de Kane, pero descubren que la sangre de la alima??a es un ??cido extremadamente" +
                " corrosivo. Finalmente, la criatura se desprende por s?? sola y cae muerta. Con la nave reparada, la tripulaci??n despega, acopla el remolque y retoma el " +
                "viaje hacia la Tierra.\n" +
                "\n" +
                "Kane despierta aparentemente ileso, pero durante una comida antes de entrar nuevamente en hipersue??o, Kane comienza a asfixiarse convulsivamente hasta que " +
                "una larva emerge violentamente de su pecho, mat??ndolo en el acto, y escapando para ocultarse en la nave. La tripulaci??n decide intentar localizar y " +
                "capturar al monstruo con sensores de movimiento, armas de electrochoque y lanzallamas y descartar el uso de armas convencionales ya que la sangre de la " +
                "criatura podr??a disolver parte del casco de la Nostromo. Mientras Brett busca a ??Jones??, el gato de la tripulaci??n,nota 7 llega a una sala en la que " +
                "encuentra al engendro ya desarrollado,nota 8 que lo asesina antes de desaparecer por los conductos del sistema de ventilaci??n de la nave. Dallas lo sigue " +
                "con la intenci??n de forzar a la cosa a entrar en una esclusa donde pueda ser expulsada hacia el espacio, pero el ser le tiende una emboscada y lo mata. " +
                "Lambert les pide a los dem??s que escapen en una lanzadera, pero Ripley, siguiente al mando, se niega alegando que la lanzadera no podr??a dar soporte vital " +
                "a cuatro personas. Tras acceder a ??Madre??, Ripley descubre que Ash recibi?? secretamente ??rdenes de llevar la nave hasta su corporaci??n propietaria con el " +
                "alien??gena dentro, a expensas de lo que le pudiese ocurrir a los dem??s pasajeros. Ash le ataca bruscamente, pero Lambert y Parker intervienen, siendo este " +
                "??ltimo quien golpea a Ash con un extintor decapit??ndolo, revelando a la tripulaci??n que en realidad Ash es un androide. Antes de ser incinerado, Ash les " +
                "indica a los tripulantes que no sobrevivir??n. M??s tarde, los sobrevivientes idean un plan para activar el sistema de autodestrucci??n de la Nostromo y " +
                "escapar en la lanzadera.\n" +
                "\n" +
                "Mientras Ripley, inicia la secuencia de autodestrucci??n; Lambert y Parker son emboscados y asesinados por la criatura mientras recolectan pertrechos para " +
                "el escape. A continuaci??n, Ripley se dirige a la lanzadera con Jones, pero el Alien le bloquea el camino, pero alcanza a escapar de ??l. La suboficial " +
                "intenta, sin ??xito, abortar la autodestrucci??n, y vuelve a la compuerta de la lanzadera. Para su alivio, el ser ya no se halla ah?? y Ripley logra escapar " +
                "en la c??psula antes de que la Nostromo explote. Mientras se prepara para entrar en hipersue??o, Ripley descubre que el monstruo se encuentra con ella en la " +
                "lanzadera. Tras ponerse un traje espacial, ella despresuriza la lanzadera al abrir la escotilla, logrando finalmente expulsar el organismo fuera de la nave" +
                " con ayuda de un gancho que lanza contra la criatura. Sin embargo el cable del gancho termina atasc??ndose en la puerta y el xenomorfo se mantiene sujeto al" +
                " cable tratando de introducirse en la nave por uno de los motores. Finalmente Ripley activa los motores y el impulsor env??a al monstruo al espacio, " +
                "deshaci??ndose de ??l. En las escenas finales se ve a Ripley entrando en hipersue??o junto con el gato antes de su retorno a la Tierra");
        alien.setIdYoutube("LjLamj-b0I8");
        peliculas.add(alien);

        cal.set(1995, 1, 2);
        Pelicula st = new Pelicula("Star Trek", "J. J. Abrams", 128, cal.getTime(), "Travesia", R.drawable.pg, R.drawable.startrek);
        st.setSinopsis("La nave espacial de la Federaci??n USS Kelvin explora un fen??meno astrof??sico similar a una tormenta el??ctrica, que produce un agujero negro. De este" +
                " sale una inmensa y monstruosa nave negra, que dispara contra los exploradores impidi??ndoles alejarse. Luego les env??a un mensaje que le ordena a su " +
                "capit??n reunirse con ellos para negociar un alto el fuego. Este obedece pidiendo a sus camaradas que evacuen el Kelvin. En la nave es interrogado y " +
                "asesinado por Nero, un romulano que ordena destruir lo que queda del Kelvin. El primer oficial de esa nave, George Kirk, ordena a la tripulaci??n marcharse " +
                "en las lanzaderas. Al da??arse el piloto autom??tico, ??l debe permanecer y utilizar sus armas para proteger al resto. En una de las lanzaderas se encuentra " +
                "su mujer, que est?? dando a luz al hijo de ambos. Cuando nace lo bautizan James Tiberius Kirk antes de que su padre dirija el Kelvin contra la nave enemiga," +
                " haci??ndola colisionar mientras su mujer y el ni??o logran huir.\n" +
                "\n" +
                "Unos diecinueve a??os despu??s, se cuenta la vida de dos j??venes que viven en mundos diferentes. Uno es Kirk, un joven con grandes capacidades, pero con gran" +
                " torpeza para expresarlas, algo c??nico y desorientado. Tras una pelea en un bar, da con ??l un admirador de su padre: el capit??n Christopher Pike de la " +
                "Flota Estelar, quien le recuerda el m??rito de su progenitor y le invita a que se convierta en un oficial. Animado por sus palabras, Kirk decide ingresar en" +
                " la Flota Estelar y acude al muelle del desierto del estado estadounidense de Iowa, donde se est?? construyendo la nave USS Enterprise. All?? se hace amigo " +
                "del m??dico Leonard McCoy, que le acompa??ar?? en su aprendizaje.\n" +
                "Zachary Quinto, el actor que da vida al joven vulcano Spock.\n" +
                "\n" +
                "El otro joven es Spock, hijo de una humana y de un vulcano. Los vulcanos son seres que s??lo se gu??an por la raz??n y la l??gica y rechazan las emociones, a " +
                "las cuales Spock es muy vulnerable debido a su sangre humana. Los dem??s ni??os le rechazan por ser un ser incompleto, pero su padre le asegura tener plena " +
                "capacidad para elegir cualquier camino. Al llegar a su adultez Spock ha tenido un ??xito de aptitud muy superior a la media, lo que le permite ingresar en " +
                "las ??lites acad??micas de su planeta. Antes de decidir aceptar, descubre que los eruditos siguen menospreciando la condici??n humana a trav??s de su madre. " +
                "Ofendido, rechaza los honores y nombramientos, prefiriendo marcharse para ingresar en la Flota Estelar.\n" +
                "\n" +
                "Tres a??os despu??s, Kirk y McCoy est??n finalizando su formaci??n. El primero coquetea con Nyota Uhura, la estudiante de xenoling????stica que conoci?? en el " +
                "bar, pero ??sta lo rechaza varias veces. En una ocasi??n le escucha decir que ha detectado un mensaje de una flota Klingon, destruida por una nave gigantesca" +
                ". Luego, en un intento de impresionarla, ??l afronta por tercera vez la prueba del Kobayashi Maru, una simulaci??n virtual del rescate de una nave rodeada " +
                "por naves de guerra klingon. Ning??n alumno la ha superado, pero inesperadamente Kirk lo logra. Spock, el programador de la prueba, descubre que Kirk la ha " +
                "reprogramado sin permiso y le lleva a un juicio. All?? se conocen y se revela que el test no est?? dise??ado para ser superado sino para que los navegantes " +
                "aprendan a afrontar el miedo. En esa reuni??n, la Flota recibe un mensaje de socorro desde el planeta Vulcano. Spock, Uhura y McCoy son asignados al USS " +
                "Enterprise, bajo el mando del capit??n Pike. Pero Kirk es suspendido por su falta y debe quedarse en la Tierra. McCoy, sin embargo, lo lleva intoxic??ndolo e" +
                " ingres??ndolo en el Enterprise con la excusa m??dica de desintoxicarlo.\n" +
                "\n" +
                "Cuando el USS Enterprise zarpa hacia Vulcano, el joven navegador Pavel Chekov informa de un nuevo mensaje sobre una tormenta el??ctrica. Kirk, alertado, se " +
                "encuentra con Uhura y ella le confirma que la nave de la que se hablaba en el mensaje de los klingon era romulana. Asociando ambas ideas, acude corriendo " +
                "al puente de mando y le advierte al capit??n Pike que la nave romulana podr??a estar atacando Vulcano y esper??ndoles. Spock, a pesar de contrariarse con su " +
                "presencia, la da la raz??n. Al llegar hallan en efecto una gigantesca nave espacial negra, que navega entre los restos flotantes de quienes han llegado " +
                "antes. En el interior de esa nave se encuentra Nero, quien reconoce el Enterprise (y a Spock) y opta por no destruirlo. Pero amenaza con hacerlo si el " +
                "capit??n Pike no acude a la nave negra romulana (conocida como Narada) a negociar. ??ste acepta reunirse. Antes de partir nombra a Spock capit??n y a Kirk, " +
                "primer oficial.");
        st.setIdYoutube("pKFUZ10Wmbw");
        peliculas.add(st);

        cal.set(2015, 9, 24);
        Pelicula martian = new Pelicula("The Martian", "Ridley Scotts", 151, cal.getTime(), "Gran v??a", R.drawable.pg13, R.drawable.martian);
        martian.setSinopsis("Durante una misi??n a Marte de la nave tripulada Ares III, una fuerte tormenta se desata, por lo que, tras haber dado por desaparecido y muerto al astronauta Mark Watney (Matt Damon), sus compa??eros toman la decisi??n de irse; sin embargo, ha sobrevivido, pero est?? solo y sin apenas recursos en el planeta. Con muy pocos medios, deber?? recurrir a sus conocimientos, su sentido del humor y un gran instinto de supervivencia para lograr sobrevivir y comunicar a la Tierra que todav??a est?? vivo, esperando que acudan en su rescate.");
        martian.setIdYoutube("OS23SmNlE3Y");
        peliculas.add(martian);
        return peliculas;
    }

}