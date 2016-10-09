using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        
    }

    public void setPlayer(Transform hero)
    {
        this.player = hero;
    }
}
