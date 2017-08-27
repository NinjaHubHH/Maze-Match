using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager beiinhalett ein Dictionary über die Player und deren ID um diese später abzufragen und beliebig viele Spieler mit ihren IDs abzuspeichern
public class GameManager : MonoBehaviour {

    private const string PLAYER_ID_PREFIX = "Player "; //prefix damit die Player auch "Player 1" heißen und nicht nur "1"

    private static Dictionary<string, Player> players = new Dictionary<string, Player>(); //Dictionary

    //trägt den Player mit der ID in das Dictionary "Player 1" als Beispiel
    public static void RegisterPlayer(string _netID, Player _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;

    }

    //nimmt den Spieler aus der Liste (im Falle vom Verbindungsabbruch oder Tod des Spielers)
    public static void UnRegisterPlayer(string _playerID)
    {
        players.Remove(_playerID);
    }

    //vereinfachung um die player ID abzurufen
    public static Player GetPlayer(string _playerID)
    {
        return players[_playerID];
    }

    //just for checking the registered Players in the dictionary - displayed on screen
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();

        foreach(string _playerID in players.Keys)
        {
            GUILayout.Label(_playerID + " - " + players[_playerID].transform.name);
        }
 
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
