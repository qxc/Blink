 using UnityEngine;
 using System.Collections;
 
 public class DestroyOnComplete : MonoBehaviour 
 {
     private ParticleSystem ps;
 
 
     public void Start() 
	 
     {
		//  print("Destroy Self");
         ps = GetComponent<ParticleSystem>();
     }
 
     public void Update() 
     {
         if(ps)
         {
             if(!ps.IsAlive())
             {
                 Destroy(gameObject);
             }
         }
     }
 }