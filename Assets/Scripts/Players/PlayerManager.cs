using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	public int maxNumberOfPlayers;
	public delegate void OnNextPlayerEvent(Player player);
	public event OnNextPlayerEvent OnNextPlayer;
	
	private GameObject PlayerHudPanel;
	private int playerTurn = -1;
	private List<Player> players = new List<Player> ();

	// Use this for initialization
	void Start(){
		PlayerHudPanel = GameObject.FindGameObjectWithTag ("PlayerHUD");
	}
	
	public void addPoints (int points){
		if (players.Count != 0 && playerTurn > -1) {
			players[playerTurn].addPoints(points);
			Debug.Log (players[playerTurn].Name + " now has: " + players[playerTurn].Points + " points.");
		}
	}
	
	public int getPoints (int playerId){
		return players[playerId].Points;
	}
	
	public int getTurn (){
		return playerTurn;
	}
	
	public Player getPlayerInfo (int playerId) {
		try {
			return players[playerId];
		} catch {
			return null;	
		}
	}
	
	public void nextPlayer(){
		int player;
		if (playerTurn == players.Count -1){
			player = 0;
		}
		else
			player = playerTurn + 1;
		
		nextPlayer(player);
	}
	
	public void nextPlayer (int player){
		playerTurn = Mathf.Clamp(player, 0, players.Count);
		Debug.Log(playerTurn);
		Debug.Log(players[playerTurn]);
		OnNextPlayer(players[playerTurn]);
		Debug.Log (players[playerTurn].Name + "'s turn");
	}

	public Player GetLeadingPlayer() {
		float lowestScore = Mathf.Infinity;
		Player player = null;
		Player winner = player;
		print (getNumberOfPlayers());
		for (int i=0; i<getNumberOfPlayers(); i++) {
			player = getPlayerInfo(0);
			print(player);
			if (player.Points < lowestScore){
				lowestScore = player.Points;
				winner = player;
			}
		}
		return winner;
	}
	
	// Handle the HUD and instantiating of players
	public Player addPlayer () { 
		return addPlayer ("< name >");
	}
	
	public Player addPlayer (string name) {
		if (getNumberOfPlayers () < maxNumberOfPlayers){
			Player player = new Player(name);
			players.Add ( player );
		
			Debug.Log ( player.Name + " was added" );
			return player;
		}else {
			Debug.Log ("Max number of players reached: " + maxNumberOfPlayers);
			return null;
		}
	}
	
	public void removePlayer (Player player) {
		players.Remove (player);
	}
	
	public void removePlayer (int playerId) {
		players.RemoveAt (playerId);
	}
	
	public void clearPlayers () {
		players = null;
	}
	
	public int getNumberOfPlayers () {
		return players.Count;
	}
	
	public void resetScores () {
		foreach (Player player in players) {
			player.Points = 0;
		}
	}
}
