package com.kilobot.zombiebird;

import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.kilobot.screens.GameScreen;
import com.kilobot.zbhelpers.AssetLoader;

public class ZBGame extends Game {
	@Override
	public void create() {
		Gdx.app.log("ZBGame","created");
		AssetLoader.load();
		setScreen(new GameScreen());
	}

	@Override
	public void dispose() {
		super.dispose();
		AssetLoader.dispose();
	}
}
