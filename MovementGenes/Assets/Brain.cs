using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class Brain : MonoBehaviour {

    public int DNAlength = 1;
    public float timeAlive;
    public float distanceTravelled;
    public DNA DNA;

    private ThirdPersonCharacter m_character;
    private Vector3 m_Move;
    private bool m_Jump;
    bool alive = true;
    private Vector3 startposition;

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        //initialize DNA
        // 0 forward
        // 1 back
        // 2 left
        // 3 right
        // 4 jump
        // 5 crouch
        DNA = new DNA(DNAlength, 6);
        m_character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
        startposition = this.transform.position;
    }


    private void FixedUpdate()
    {
        //read dna
        float h = 0;
        float v = 0;
        bool crouch = false;
        if (DNA.GetGene(0) == 0) v = 1;
        else if (DNA.GetGene(0) == 1) v = -1;
        else if (DNA.GetGene(0) == 2) h = -1;
        else if (DNA.GetGene(0) == 3) h = 1;
        else if (DNA.GetGene(0) == 4) m_Jump = true;
        else if (DNA.GetGene(0) == 5) crouch = true;

        m_Move = v * Vector3.forward + h * Vector3.right;
        m_character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
        if (alive)
        {
            timeAlive += Time.deltaTime;
            distanceTravelled = Vector3.Distance(this.transform.position, startposition);
        }
    }
    void Start () {
		
	}
	
	void Update () {
		
	}
}
