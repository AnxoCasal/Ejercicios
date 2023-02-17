package com.mygdx.anxo;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector;
import com.badlogic.gdx.math.Vector3;
import com.badlogic.gdx.utils.ScreenUtils;

public class MainGame extends ApplicationAdapter {
    private SpriteBatch batch;
    private Texture playerImg;
    private Texture rockImg;
    private OrthographicCamera camera;
    private Rectangle player;
    private Rectangle rock;

    @Override
    public void create() {
        batch = new SpriteBatch();
        playerImg = new Texture(Gdx.files.internal("player.png"));
        rockImg = new Texture(Gdx.files.internal("rock.jpg"));
        camera = new OrthographicCamera();
        camera.setToOrtho(false, 480, 800);
        player = new Rectangle(0, 400, 120, 120);
        rock = new Rectangle(240, 400, 120, 120);
    }

    @Override
    public void render() {
        ScreenUtils.clear(0, 0, 0, 1);

        if (Gdx.input.isTouched()) {
            Vector3 touchPos = new Vector3();
            touchPos.set(Gdx.input.getX(), Gdx.input.getY(), 0);
            camera.unproject(touchPos);

            if (touchPos.y < 200) {
                jump();
            } else {
                if (touchPos.x < 240 && player.x > 0) {
                    player.x -= 20;
                    if (player.overlaps(rock)) {
                        player.x += 20;
                    }
                } else if (touchPos.x > 240 && player.x < 1900 - player.x) {
                    player.x += 20;
                    if (player.overlaps(rock)) {
                        player.x -= 20;
                    }
                }
            }

        }

        batch.begin();
        batch.draw(playerImg, player.x, player.y, player.width, player.height);
        batch.draw(rockImg, rock.x, rock.y, rock.width, rock.height);
        batch.end();
    }

    public void jump() {

    }

    @Override
    public void dispose() {
        batch.dispose();
    }
}
