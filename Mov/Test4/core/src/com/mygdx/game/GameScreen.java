package com.mygdx.game;

import static helper.Constants.PPM;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.ScreenAdapter;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.maps.tiled.renderers.OrthogonalTiledMapRenderer;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.math.Vector3;
import com.badlogic.gdx.physics.box2d.Box2DDebugRenderer;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.utils.ScreenUtils;

import helper.TiledMalpHelper;
import objects.player.Player;

public class GameScreen extends ScreenAdapter {

    private OrthographicCamera camera;
    private SpriteBatch batch;
    private World world;
    private Box2DDebugRenderer renderer;
    private OrthogonalTiledMapRenderer orthogonalTiledMapRenderer;
    private TiledMalpHelper tiledMalpHelper;
    private Player player;

    public GameScreen(OrthographicCamera camera) {
        this.camera = camera;
        this.batch = new SpriteBatch();
        this.world = new World(new Vector2(0, -9.81f), false);
        this.renderer = new Box2DDebugRenderer();

        this.tiledMalpHelper = new TiledMalpHelper(this);
        this.orthogonalTiledMapRenderer = tiledMalpHelper.setupMap();
    }


    @Override
    public void render(float delta) {
        this.update();


        ScreenUtils.clear(0,0,0,1);

        orthogonalTiledMapRenderer.render();

        batch.begin();

        batch.end();
        renderer.render(world, camera.combined.scl(PPM));
    }

    private void update() {
        world.step(1 / 60f, 6, 2);
        cameraUpdate();
        batch.setProjectionMatrix(camera.combined);
        orthogonalTiledMapRenderer.setView(camera);
    }

    private void cameraUpdate(){
        Vector3 position = camera.position;
//        position.x = Math.round(player.getBody().getPosition().x * PPM * 10)/10f;
//        position.y = Math.round(player.getBody().getPosition().y * PPM * 10)/10f;
 //       camera.position.set(position);
        camera.position.set(new Vector3(Gdx.graphics.getWidth()/2, Gdx.graphics.getHeight(), 0));
        camera.update();
    }

    public World getWorld() {
        return world;
    }

    public void setPlayer(Player player){
        this.player = player;
    }
}
