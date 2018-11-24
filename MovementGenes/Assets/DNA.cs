using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour {

    List<int> genes = new List<int>();
    int dnalength = 0;
    int maxValues = 0;

    //dynamic gene sequence; set the length of the DNA(number of properties) and the maximum values of the DNA
    public DNA(int l, int v)
    {
        dnalength = l;
        maxValues = v;
        SetRandom();
    }

    //clears out the existing gene sequence and fills with random values
    public void SetRandom()
    {
        genes.Clear();
        for(int i = 0; i < dnalength; i++)
        {
            genes.Add(Random.Range(0, maxValues));
        }
    }

    //method to hardocode values into the sequence
    public void SetInt(int pos, int value)
    {
        genes[pos] = value;
    }

    //splitting the sequence from the parent and putting it back together
    public void Combine(DNA d1, DNA d2)
    {
        for(int i = 0; i < dnalength; i++)
        {
            if (i < dnalength / 2.0)
            {
                int c = d1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }

    //adding randomness to gene sequence
    public void Mutate()
    {
        genes[Random.Range(0, dnalength)] = Random.Range(0, maxValues);
    }

    public int GetGene(int pos)
    {
        return genes[pos];
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
