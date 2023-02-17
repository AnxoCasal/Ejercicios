package com.kilobot.gameworld;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.math.Intersector;
import com.badlogic.gdx.math.Rectangle;
import com.kilobot.gameobjects.Bird;
import com.kilobot.gameobjects.Pipe;
import com.kilobot.gameobjects.ScrollHandler;
import com.kilobot.zbhelpers.AssetLoader;


public class GameWorld {

    private Bird bird;
    private ScrollHandler scroll;
    private Rectangle ground;
    private int score = 0;

    private int midPointY;

    public ScrollHandler getScroller() {
        return scroll;
    }

    public enum GameState {

        READY, RUNNING, GAMEOVER,HIGHSCORE

    }

    private GameState currentState;

    public GameWorld(int midPointY){
        currentState = GameState.READY;
        bird = new Bird(33,midPointY - 5,17,12);
        scroll = new ScrollHandler(this,midPointY+66);
        ground = new Rectangle(0,midPointY+66,136,11);
        this.midPointY = midPointY;
    }

    public void update(float delta) {

        switch (currentState) {
            case READY:
                updateReady(delta);
                break;

            case RUNNING:
                updateRunning(delta);
                break;
            default:
                break;
        }

    }

    private void updateReady(float delta) {
    }

    public void updateRunning(float delta){
        if (delta > .15f) {
            delta = .15f;
        }

        bird.update(delta);
        scroll.update(delta);

        if (scroll.collides(bird) && bird.isAlive()) {
            scroll.stop();
            bird.die();
            AssetLoader.dead.play();
        }

        if (Intersector.overlaps(bird.getBoundingCircle(), ground)) {
            scroll.stop();
            bird.die();
            bird.decelerate();
            currentState = GameState.GAMEOVER;
            if (score > AssetLoader.getHighScore()) {
                AssetLoader.setHighScore(score);
                currentState = GameState.HIGHSCORE;
            }
        }
    }

    public void restart() {
        currentState = GameState.READY;
        score = 0;
        bird.onRestart(midPointY - 5);
        scroll.onRestart();
        currentState = GameState.READY;
    }

    public boolean isReady() {
        return currentState == GameState.READY;
    }

    public void start() {
        currentState = GameState.RUNNING;
    }

    public boolean isGameOver() {
        return currentState == GameState.GAMEOVER;
    }

    public boolean isHighScore() {
        return currentState == GameState.HIGHSCORE;
    }

    public Bird getBird() {
        return bird;
    }

    public ScrollHandler getScroll(){
        return scroll;
    }

    public int getScore() {
        return score;
    }

    public void addScore(int increment) {
        score += increment;
    }
}
