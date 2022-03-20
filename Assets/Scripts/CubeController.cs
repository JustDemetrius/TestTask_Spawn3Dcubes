using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject CubePrefab;

    [Header("Скорость движения кубов")]
    [Range(0.1f, 1.5f)]
    public float Speed;
    [Header("На какое расстояние сместить куб")]
    [Range(5, 45)]
    public float Distance;
    [Header("Частота спавна кубов")]
    public float SpawnTimer;

    public float Timer;


    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= SpawnTimer)
        {
            SpawnCube();
            Timer = 0;
        }
    }

    private void SpawnCube()
    {
        var cube = Instantiate(CubePrefab, new Vector3(Random.Range(-2, 2), 0, 0), Quaternion.identity);
        cube.transform.DOPunchScale(Vector3.one, 0.5f).SetEase(Ease.OutCubic).OnComplete(() => MoveCube(cube.gameObject));
    }
    private void MoveCube(GameObject someCube)
    {
        someCube.transform.DOMoveZ(Distance, 2f - Speed).SetEase(Ease.InOutCirc).OnComplete(() => DestroyCube(someCube.gameObject));

        var _cubeColor = someCube.GetComponent<MeshRenderer>();
        _cubeColor.material.DOColor(GetRandomColor(), 2f - Speed).SetEase(Ease.InOutCirc);
    }
    private void DestroyCube(GameObject someCube)
    {
        someCube.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => Destroy(someCube.gameObject));
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }
}
