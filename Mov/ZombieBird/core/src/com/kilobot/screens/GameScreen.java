package com.kilobot.screens;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.GL20;
import com.kilobot.gameworld.GameRenderer;
import com.kilobot.gameworld.GameWorld;
import com.kilobot.zbhelpers.InputHandler;

public class GameScreen implements Screen {

    private GameWorld gameWorld;
    private GameRenderer gameRenderer;
    private float runTime = 0;

    public GameScreen() {

        float screenWidth = Gdx.graphics.getWidth();
        float screenHeight = Gdx.graphics.getHeight();
        float gameWidth = 136;
        float gameHeight = screenHeight / (screenWidth/gameWidth);

        int midPointy = (int)(gameHeight/2);

        gameWorld = new GameWorld(midPointy);
        gameRenderer = new GameRenderer(gameWorld, (int) gameHeight, midPointy);

        Gdx.input.setInputProcessor(new InputHandler(gameWorld));
    }

    @Override
    public void render(float delta) {
        runTime+=delta;
        gameWorld.update(delta);
        gameRenderer.render(runTime);
    }

    @Override
    public void resize(int width, int height) {
    }

    @Override
    public void show() {
    }

    @Override
    public void hide() {
    }

    @Override
    public void pause() {
    }

    @Override
    public void resume() {
    }

    @Override
    public void dispose() {
    }
}
