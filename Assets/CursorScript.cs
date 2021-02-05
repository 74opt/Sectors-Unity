using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {
    public Animator animator;

    // Start is called before the first frame update
    void Start() {
        animator.SetFloat("Cursor_Tempo", ((TempoScript.tempo/30) * .1f) + .1f);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
