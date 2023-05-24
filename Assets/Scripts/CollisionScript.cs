using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public int row;
    public int column;
    public GameManager GameManager;
    public Material Material1;
    public Material Material2;
    public GameObject ColissionSquare;
    public int Player=0;
    

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.name);
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "CannonBall(Clone)")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            if (ColissionSquare.name=="Ground")
            {
                GameManager.SwitchToPlayerCamera();
            }
            else if (GameManager.p2turn)
            {
                
                ColissionSquare.GetComponent<MeshRenderer>().material = Material1;
                Player = 2;
                CheckHits(ColissionSquare);
                if (GameManager.CheckWin(GameManager.Board))
                {
       
                    GameManager.GameOver(Player);
                }
            }
            else
            {
                
                ColissionSquare.GetComponent<MeshRenderer>().material = Material2;
                Player = 1;
                CheckHits(ColissionSquare);
                if (GameManager.CheckWin(GameManager.Board))
                {

                    GameManager.GameOver(Player);
                }
            }
        }

        GameManager.SwitchToPlayerCamera();
    }
    
    public void CheckHits(GameObject Other)
        
    {
        if (column == 1)
        {
            if (row == 1)
            {
                GameManager.Board[0][0]=Player;
            }
            if (row == 2)
            {
                GameManager.Board[0][1] = Player;
            }
            if (row == 3)
            {
                GameManager.Board[0][2] = Player;
            }
        }
        if (column == 2)
        {
            if (row == 1)
            {
                GameManager.Board[1][0] = Player;

            }
            if (row == 2)
            {
                GameManager.Board[1][1] = Player;

            }
            if (row == 3)
            {
                GameManager.Board[1][2] = Player;

            }
        }
        if (column == 3)
        {
            if (row == 1)
            {
                GameManager.Board[2][0] = Player;

            }
            if (row == 2)
            {
                GameManager.Board[2][1] = Player;

            }
            if (row == 3)
            {
                GameManager.Board[2][2] = Player;
            }
        }
    }
    
    
}
