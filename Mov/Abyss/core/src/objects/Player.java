package objects;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Rectangle;

import org.w3c.dom.Text;


public class Player {
    private Rectangle hitBox;
    private Texture img;
    private TextureRegion imgRegion;

    public Player(){
        hitBox = new Rectangle(0,0,64,64);
        img = new Texture(Gdx.files.internal("player.png"));
        imgRegion = new TextureRegion(img);
        imgRegion.flip(false,true);
    }

    public Rectangle getHitBox() {
        return hitBox;
    }

    public TextureRegion getImg() {
        return imgRegion;
    }
}
