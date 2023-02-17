package com.mygdx.game;

import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.Box2DDebugRenderer;
import com.badlogic.gdx.physics.box2d.CircleShape;
import com.badlogic.gdx.physics.box2d.Fixture;
import com.badlogic.gdx.physics.box2d.FixtureDef;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.utils.ScreenUtils;

public class MainScreen implements Screen {

    final MainGame mainGame;
    OrthographicCamera camera;
    World world;
    Box2DDebugRenderer renderer;

    public MainScreen(MainGame mainGame){
        this.mainGame = mainGame;
        camera = new OrthographicCamera();
        camera.setToOrtho(false,800,480);

        world = new World(new Vector2(0,-1),false);
        renderer = new Box2DDebugRenderer();
        createBall();
    }

    @Override
    public void render(float delta) {
        ScreenUtils.clear(0,0,0.2f,1);

        world.step(delta,8,6);
    }



    private void createBall(){
        BodyDef bd = new BodyDef();
        bd.type = BodyDef.BodyType.DynamicBody;
        bd.position.set(4,4.5f);

        Body body = world.createBody(bd);

        CircleShape shape = new CircleShape();
        shape.setRadius(6f);

        FixtureDef fixDef = new FixtureDef();
        fixDef.shape = shape;
        fixDef.density = 0.5f;
        fixDef.friction = 0.4f;
        fixDef.restitution = 0.6f;

        Fixture fix = body.createFixture(fixDef);

        shape.dispose();
    }

    @Override
    public void show() {

        camera.update();
        mainGame.batch.setProjectionMatrix(camera.combined);

        camera.update();
        renderer.render(world,camera.combined);

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
