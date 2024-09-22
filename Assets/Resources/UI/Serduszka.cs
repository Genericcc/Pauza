using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serduszka : MonoBehaviour
{
    [SerializeField] private Sprite Heart1;
    [SerializeField] private Sprite Heart2;
    [SerializeField] private Sprite Heart3;
    private Player player;

    private void Start()
    {
       player = Player.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
