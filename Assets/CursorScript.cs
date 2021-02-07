using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {
    public Animator mouseAnimator;
    Vector2 mousePos; 

    // Start is called before the first frame update
    void Start() {
        mouseAnimator.SetFloat("Cursor_Tempo", (TempoScript.tempo/30 * .1f) + .1f);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //Camere.main.ScreenToWorldPoint turns a sprite's screen coordinates into the ingame world's coord1inates
        transform.position = Vector2.Lerp(transform.position, mousePos, 999999);
    }
}
