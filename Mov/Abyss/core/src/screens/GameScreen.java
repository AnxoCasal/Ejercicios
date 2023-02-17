package screens;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.glutils.ShapeRenderer;

import helpers.InputHandler;
import objects.Player;

public class GameScreen implements Screen {

    private OrthographicCamera camera;
    private SpriteBatch batch;
    private ShapeRenderer renderer;
    private Player player;
    private InputHandler inputHandler;

    public GameScreen(){
        camera = new OrthographicCamera();
        camera.setToOrtho(true, Gdx.graphics.getWidth()/2,Gdx.graphics.getHeight()/2);
        player = new Player();
        batch = new SpriteBatch();
        renderer = new ShapeRenderer();
        inputHandler = new InputHandler(this);
    }

    @Override
    public void show() {

    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
        batch.setProjectionMatrix(camera.combined);
        renderer.setProjectionMatrix(camera.combined);

        inputHandler.check();

        renderer.begin(ShapeRenderer.ShapeType.Filled);
        renderer.setColor(Color.RED);
        renderer.rect(player.getHitBox().x,player.getHitBox().y,player.getHitBox().getWidth(),player.getHitBox().getHeight());
        renderer.end();

        batch.begin();
        batch.draw(player.getImg(),player.getHitBox().x,player.getHitBox().y,player.getHitBox().getWidth(),player.getHitBox().getHeight());
        batch.end();
    }

    public Player getPlayer() {
        return player;
    }

    @Override
    public void resize(int width, int height) {

    }

    @Override
    public void pause() {

    }

    @Override
    public void resume() {

    }

    @Override
    public void hide() {

    }

    @Override
    public void dispose() {

    }
}
