using UnityEngine;

public class SpriteBPMFlipper : MonoBehaviour
{

    [SerializeField] private float BPM = 120;
    [SerializeField] private SpriteRenderer mySprite;
    private float fliprate;
    private float fliptimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fliprate = 60 / BPM;
        fliptimer -= Time.fixedDeltaTime;
        if(fliptimer < 0)
        {
            if (mySprite != null)
            {
                mySprite.flipX = !mySprite.flipX;
            }
            fliptimer = fliprate;
        }
    }
}
