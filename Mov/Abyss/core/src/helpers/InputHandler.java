package helpers;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.InputProcessor;

import objects.Player;
import screens.GameScreen;

public class InputHandler {

    private GameScreen gameScreen;
    private Player player;

    public InputHandler(GameScreen gameScreen){
        this.gameScreen = gameScreen;
        this.player = gameScreen.getPlayer();
    }

    public void check(){
        if(Gdx.input.isTouched()){
            if(Gdx.input.getX()>Gdx.graphics.getWidth()/2){
                player.getHitBox().x+=4;
            } else {
                player.getHitBox().x-=4;
            }
        }
    }
}
