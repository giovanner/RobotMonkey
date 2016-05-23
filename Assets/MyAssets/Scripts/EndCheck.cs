using UnityEngine;
using System.Collections;

public class EndCheck : MonoBehaviour {

    public enum whichplayer {P1,P2};

    public whichplayer player;

    private bool inside = false;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (player == whichplayer.P1)
        {
            if (collider.CompareTag("Player1"))
            {
                this.inside = true;
            }
            else
                this.inside = false;

        }else if (player == whichplayer.P2)
        {
            if (collider.CompareTag("Player2"))
            {
                this.inside = true;
            }
            else
                this.inside = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (player == whichplayer.P1)
        {
            if (collider.CompareTag("Player1"))
            {
                this.inside = false;
            }

        }
        else if (player == whichplayer.P2)
        {
            if (collider.CompareTag("Player2"))
            {
                this.inside = false;
            }
        }
    }

    public bool getCheck()
    {
        return this.inside;
    } 
}
