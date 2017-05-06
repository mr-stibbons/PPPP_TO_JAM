using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public enum MenuStates { Main, Game, Player, ListPlayers, Turncoat, Options, QuitMenu}
	public MenuStates currentState;

	// Menu Panel GameObjects
	public GameObject mainMenu;
	public GameObject playerMenu;
	public GameObject listPlayersMenu;
	public GameObject turncoatMenu;
	public GameObject optionsMenu;
	public GameObject quitMenu;



	// Use this for initialization
	void Awake () {
		currentState = MenuStates.Main;
	}

	void Update() {

		switch (currentState) {
		case MenuStates.Main:
			mainMenu.SetActive(true);
			playerMenu.SetActive(false);
			listPlayersMenu.SetActive(false);
			turncoatMenu.SetActive(false);
			optionsMenu.SetActive(false);
			quitMenu.SetActive(false);
			break;
		case MenuStates.Game:
			mainMenu.SetActive(false);
			playerMenu.SetActive(false);
			listPlayersMenu.SetActive(false);
			turncoatMenu.SetActive(false);
			optionsMenu.SetActive(false);
			quitMenu.SetActive(false);
			break;
		case MenuStates.Player:
			mainMenu.SetActive(false);
			playerMenu.SetActive(true);
			listPlayersMenu.SetActive(false);
			turncoatMenu.SetActive(false);
			optionsMenu.SetActive(false);
			quitMenu.SetActive(false);
			break;
		case MenuStates.ListPlayers:
			mainMenu.SetActive(false);
			playerMenu.SetActive(false);
			listPlayersMenu.SetActive(true);
			turncoatMenu.SetActive(false);
			optionsMenu.SetActive(false);
			quitMenu.SetActive(false);
			break;
		case MenuStates.Turncoat:
			mainMenu.SetActive(false);
			playerMenu.SetActive(false);
			listPlayersMenu.SetActive(false);
			turncoatMenu.SetActive(true);
			optionsMenu.SetActive(false);
			quitMenu.SetActive(false);
			break;
		case MenuStates.Options:
			mainMenu.SetActive(false);
			playerMenu.SetActive(false);
			listPlayersMenu.SetActive(false);
			turncoatMenu.SetActive(false);
			optionsMenu.SetActive(true);
			quitMenu.SetActive(false);
			break;
		case MenuStates.QuitMenu:
			mainMenu.SetActive(false);
			playerMenu.SetActive(false);
			listPlayersMenu.SetActive(false);
			turncoatMenu.SetActive(false);
			optionsMenu.SetActive(false);
			quitMenu.SetActive(true);
			break;
		}


	}

	public void OnMainMenu() {
		currentState = MenuStates.Main;
	}

	public void OnGame() {
		currentState = MenuStates.Game;
	}

	public void OnPlayerMenu() {
		currentState = MenuStates.Player;
	}

	public void OnListPlayersMenu() {
		currentState = MenuStates.ListPlayers;
	}

	public void OnTurncoatMenu() {
		currentState = MenuStates.Turncoat;
	}

	public void OnOptionsMenu() {
		currentState = MenuStates.Options;
	}

	public void OnQuitMenu() {
		currentState = MenuStates.QuitMenu;
	}
}
