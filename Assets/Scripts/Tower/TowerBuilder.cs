using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _colors;

    private List<Block> _blocks;

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        var currentPoint = _buildPoint;
        var indexColor = 0;

        for (int i = 0; i < _towerSize; i++)
        {
            var newBlock = BuildBlock(currentPoint);
            
            //newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            
            newBlock.SetColor(GetNextColor(ref indexColor));
            
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

    private Color GetNextColor(ref int index)
    {
        index++;

        if (index >= _colors.Length)
        {
            index = 0;
        }

        return _colors[index];
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + _block.transform.localScale.y / 2, _buildPoint.position.z);
    }
}
