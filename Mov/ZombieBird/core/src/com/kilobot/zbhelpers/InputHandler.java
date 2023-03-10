package com.kilobot.zbhelpers;

import com.badlogic.gdx.Input;
import com.badlogic.gdx.InputProcessor;
import com.kilobot.gameobjects.Bird;
import com.kilobot.gameworld.GameWorld;

public class InputHandler implements InputProcessor {

    private Bird bird;
    private GameWorld world;

    public InputHandler( GameWorld world){
        this.world = world;
        this.bird = world.getBird();
    }

    @Override
    public boolean keyDown(int keycode) {
        return false;
    }

    @Override
    public boolean keyUp(int keycode) {
        return false;
    }

    @Override
    public boolean keyTyped(char character) {
        return false;
    }

    @Override
    public boolean touchDown(int screenX, int screenY, int pointer, int button) {

        if (world.isReady()) {
            world.start();
        }

        bird.onClick();

        if (world.isGameOver()|| world.isHighScore()) {
            // Reset all variables, go to GameState.READ
            world.restart();
        }

        return true;
    }

    @Override
    public boolean touchUp(int screenX, int screenY, int pointer, int button) {
        return false;
    }

    @Override
    public boolean touchDragged(int screenX, int screenY, int pointer) {
        return false;
    }

    @Override
    public boolean mouseMoved(int screenX, int screenY) {
        return false;
    }

    @Override
    public boolean scrolled(float amountX, float amountY) {
        return false;
    }
}
