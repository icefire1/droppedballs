using UnityEngine;
using System.Collections;

public class Player {
	#region variables
	private int points;
	private string name;
	#endregion
	
	#region Properties
	public int Points{
		get{return points;}
		set{points = value;}
	}
	
	public string Name{
		get{return name;}
		set{name = value;}
	}
	#endregion
	
	#region Constructor
	public Player (){
		name = "< name >";
		points = 0;
	}
	
	public Player (string name){
		this.name = name;
		points = 0;
	}
	#endregion
	
	#region Function
	public void addPoints(int _points){
		points += _points;
	}
	#endregion
}
