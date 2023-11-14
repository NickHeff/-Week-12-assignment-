PlayerBehavior.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

Debug.Log (“Lives: “ + Gameobject.Lives);

public class CoinScript : MonoBehaviour {

    public GameObject PickUp;

    void OnTriggerEnter(Collider col)
    {
        PickUp = GameObject.FindGameObjectWithTag("PickUp");

        if (gameObject != null)
        {
            // Do something  
            Destroy(gameObject);
            ScoreTextScript.coinAmount++;
        }  
    }
}

private void MovePlane() {
 
	var inputX = Input.GetAxis("Horizontal");
	 	    if (MovingRight(inputX)) {
	        desiredBankAngle = -maxBankAngle;
	    } else if (MovingLeft(inputX)) {
	        desiredBankAngle = maxBankAngle;
	    } else {
	        desiredBankAngle = 0;
			}
	 
	    currentBankAngle = Mathf.Lerp(currentBankAngle, desiredBankAngle, bankSnapFactor * Time.deltaTime);
	    aircraftTransform.localRotation = Quaternion.Euler(0, 0, currentBankAngle);
	 
	    targetTranslationSpeed = inputX * maxTranslationSpeed * Time.deltaTime;
	    currentTranslationSpeed = Mathf.SmoothDamp(currentTranslationSpeed, targetTranslationSpeed, ref translationSmoothingX, accelerationTime);
	 
	    var targetPositionX = transform.position.x + currentTranslationSpeed;
	    transform.position = new Vector3(targetPositionX, transform.position.y, transform.position.z);
	 
	} 

using UnityEngine;
using System.Collections;
 
public class EnemyHealth : MonoBehaviour
{
  public int maxHealth = 100;
  public int curHealth = 100;
 
  public float healthBarLength;
 
  // Use this for initialization
  void Start()
  {
  healthBarLength = Screen.width / 2;
  }
 
  // Update is called once per frame
  void Update()
  {
  AddjustCurrentHealth(0);
  }
 
  void OnGUI()
  {
  GUI.Box(new Rect(10, 40, healthBarLength, 20), curHealth + "/" + maxHealth);
  }
 
  public void AddjustCurrentHealth(int adj)
  {
  curHealth += adj;
 
  if (curHealth < 0)
  curHealth = 0;
 
  if (curHealth > maxHealth)
  curHealth = maxHealth;
 
  if (maxHealth < 1)
  maxHealth = 1;
 
  healthBarLength = (Screen.width / 4) * (curHealth / (float)maxHealth);
  }
}
 