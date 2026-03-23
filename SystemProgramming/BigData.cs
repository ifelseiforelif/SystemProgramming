using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming;

internal class BigData
{
    private readonly List<int> _data = new List<int>();
    public List<int[]> Chunks { get; set; }
    public BigData(int n)
    {
        for (int i = 0; i < n; i++)
        {
            _data.Add(Random.Shared.Next(1,10));
        }
    }
    public void CreateChunk(int cores)
    {
        if (cores <= 0) cores = 1;
        int chunkSize = _data.Count / cores;

        // Список для збереження чанків
        Chunks = new List<int[]>();

        // Розбиваємо основний масив numbers на підмасиви (чанки)
        for (int i = 0; i < cores; i++)
        {
            int start = i * chunkSize; // Початок ділянки
            int length = (i == cores - 1) ? _data.Count - start : chunkSize; // Для останнього – решта чисел
            int[] chunk = new int[length];
            Array.Copy(_data.ToArray(), start, chunk, 0, length); // Копіюємо підмасив
            Chunks.Add(chunk); // Додаємо до списку чанків
        }
    }

}
