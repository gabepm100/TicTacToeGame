using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameOverScrene GameOverScrene;
    public CannonController CannonController;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] GameObject TopDownCamera;

    public bool p2turn=true;
    public List<int> column1 = new List<int>() { 0, 0, 0 };
    public List<int> column2 = new List<int>() { 0, 0, 0 };
    public List<int> column3 = new List<int>() { 0, 0, 0 };

    public List<List<int>> Board = new List<List<int>>();
    

    private void Start()
    {
        PlayerCamera.SetActive(true);
        TopDownCamera.SetActive(false);
        Board.Add(column1);
        Board.Add(column2);
        Board.Add(column3);

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }



    void OnGUI()
    {

        string display = (p2turn) ? "Player One" : "Player Two";
        GUI.Label(new Rect(50,50,100,100), display);

    }

    void NextPlayer()
    {
        p2turn = !p2turn;
    }
    public void NextTurn()
    {
        NextPlayer();
        SwitchToTopCamera(); 

    }
    public void SwitchToTopCamera()
    {

        TopDownCamera.SetActive(true);
        PlayerCamera.SetActive(false);
        


    }
    public void SwitchToPlayerCamera()
    {

        TopDownCamera.SetActive(false);
        PlayerCamera.SetActive(true);


    }
    public void GameOver(int Player)
    {
        GameOverScrene.Setup(Player);
    }
    public bool CheckWin(List<List<int>>board)
    {
        //check columns
        if ((board[0][0] == board[0][1]) && (board[0][0] == board[0][2]) && (board[0][1] == board[0][2]) && (board[0][0] != 0)) { return true; }
        if ((board[1][0] == board[1][1]) && (board[1][0] == board[1][2]) && (board[1][1] == board[1][2]) && (board[1][0] != 0)) { return true; }
        if ((board[2][0] == board[2][1]) && (board[2][0] == board[2][2]) && (board[2][1] == board[2][2]) && (board[2][0] != 0)) { return true; }

        //check rows
        if ((board[0][0] == board[1][0]) && (board[0][0] == board[2][0]) && (board[1][0] == board[2][0]) && (board[0][0] != 0)) { return true; }
        if ((board[0][1] == board[1][1]) && (board[0][1] == board[2][1]) && (board[1][1] == board[2][1]) && (board[0][1] != 0)) { return true; }
        if ((board[0][2] == board[1][2]) && (board[0][2] == board[2][2]) && (board[2][2] == board[1][2]) && (board[0][2] != 0)) { return true; }

        // check diags
        if ((board[0][0] == board[1][1]) && (board[0][0] == board[2][2]) && (board[1][1] == board[2][2]) && (board[0][0] != 0)) { return true; }
        if ((board[2][0] == board[1][1]) && (board[2][0] == board[0][2]) && (board[1][1] == board[0][2]) && (board[2][0] != 0)) { return true; }
        

        return false;
    }
    public void PrintBoard(List<List<int>> rows)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Debug.Log(rows[i][j]);
            }
        }
    }
}
