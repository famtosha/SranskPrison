using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class Wall : MonoBehaviour
{
    public int holeCount;
    public float holeMaxSize;
    public float holeMinSize;
    public GameObject blockPrefub;

    private List<GameObject> currentBlocks = new List<GameObject>();
    private Collider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<Collider2D>();
        Gen();
    }

    private void Clear()
    {
        for (int i = 0; i < currentBlocks.Count; i++)
        {
            Destroy(currentBlocks[i]);
        }
        currentBlocks.Clear();
    }

    private void Gen()
    {
        var holes = CreateHoles(holeCount, holeMinSize, holeMaxSize);
        holes = SortHoles(holes);
        var borders = GetBorders(holes);
        var blocks = GetBlocks(borders);

        var center = boxCollider.bounds.center;
        var size = boxCollider.bounds.size / 2;
        var max = center + new Vector3(0, size.y, 0);
        var min = center - new Vector3(0, size.y, 0);
        InstanceBlocks(blocks, min, max);
        Destroy(gameObject);
    }

    public void InstanceBlocks(List<Block> blocks, Vector3 min, Vector3 max)
    {
        foreach (var block in blocks)
        {
            Vector3 position = Vector3.Lerp(min, max, block.posion);
            float size = Vector3.Distance(min, max) * block.size;

            var blockGO = Instantiate(blockPrefub, position, transform.rotation);
            blockGO.transform.localScale = new Vector3(blockGO.transform.localScale.x, size, blockGO.transform.localScale.z);
            currentBlocks.Add(blockGO);
        }
    }

    public Hole[] CreateHoles(int count, float holeMinSize, float holeMaxSize)
    {
        Hole[] holes = new Hole[count];
        for (int i = 0; i < holes.Length; i++)
        {
            holes[i] = Hole.CreateRandomHole(holeMinSize, holeMaxSize);
        }
        return holes;
    }

    public Hole[] SortHoles(Hole[] holes)
    {
        return holes.OrderBy(x => x.position).ToArray();
    }

    public List<float> GetBorders(Hole[] holes)
    {
        List<float> borders = new List<float>();

        borders.Add(0);
        foreach (var hole in holes)
        {
            borders.Add(Mathf.Clamp(hole.start, 0.05f, 0.95f));
            borders.Add(Mathf.Clamp(hole.end, 0.05f, 0.95f));
        }
        borders.Add(1);
        return borders;
    }

    public List<Block> GetBlocks(List<float> borders)
    {
        List<Block> blocks = new List<Block>();

        for (int i = 0; i < borders.Count; i += 2)
        {
            if (borders[i] < borders[i + 1])
            {
                blocks.Add(new Block(borders[i], borders[i + 1]));
            }
            else
            {
                blocks.Add(new Block(borders[i], borders[i + 1]));
            }
        }

        return blocks;
    }

    public struct Block
    {
        public float start;
        public float end;
        public float size => Mathf.Abs(Mathf.Abs(end) - Mathf.Abs(start));
        public float posion => (end + start) / 2;

        public Block(float start, float end)
        {
            this.start = start;
            this.end = end;
        }
    }
    public struct Hole
    {
        public float size;
        public float position;

        public float start => position - size;
        public float end => position + size;

        public static Hole CreateRandomHole(float holeMinSize, float holeMaxSize)
        {
            Hole hole;
            hole.size = Random.Range(holeMinSize, holeMaxSize);
            hole.position = Random.Range(0, 1f);
            return hole;
        }
    }
}