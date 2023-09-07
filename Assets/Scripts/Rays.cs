using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
	public int reflections;
	public float maxLength;

	private LineRenderer lineRenderer;
	private Ray ray;
	private RaycastHit hit;
	private Vector3 direction;

    public GameObject win;
    public GameObject win2;
	public float count = 0f;

	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		ray = new Ray(transform.position, transform.forward);

		lineRenderer.positionCount = 1;
		lineRenderer.SetPosition(0, transform.position);
		double remainingLength = maxLength;
		
		for (int i = 0; i < reflections; i++)
		{
			if(Physics.Raycast(ray.origin, ray.direction, out hit, (int)remainingLength))
			{
				lineRenderer.positionCount += 1;
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
				remainingLength -= Vector3.Distance(ray.origin, hit.point);
				ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
				// if (hit.collider.tag != "Mirror")
				// 	break;
				if (hit.collider.tag == "Target")
				{
					count += 1.0f * Time.deltaTime;
					
					if (SceneManager.GetActiveScene().name == "Level1" && count>=1)
					{
						Invoke("showwin1", 1f);
						Debug.Log("weve won");
						Invoke("level2", 3f);
					}
					else if(count>=1)
					{
                        Invoke("showwin2", 1f);
                        Debug.Log("weve won");
						Invoke("GameComplete", 5f);
                    }
				}
				if (hit.collider.tag != "Mirror")
					break;
			}
			else
			{
				lineRenderer.positionCount += 1;
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * (int)remainingLength);
			}
		}
	}

	public void showwin1()
	{
        win.SetActive(true);
    }

    public void showwin2()
    {
        win2.SetActive(true);
    }
    public void level2()
	{
		SceneManager.LoadScene("Level2");
	}

	public void GameComplete()
	{
        SceneManager.LoadScene(0);
    }
}