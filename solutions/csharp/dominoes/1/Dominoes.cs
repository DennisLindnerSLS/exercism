using System;
using System.Collections.Generic;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var currentChain = new List<(int, int)>();
        var solutions = new List<List<(int, int)>>();

        findSolutionViaBacktracking(dominoes.ToList(), currentChain, solutions);

        return solutions.Count > 0;
    }

    private static void findSolutionViaBacktracking(List<(int, int)> dominoes, List<(int, int)> currentChain, List<List<(int, int)>> solutions)
    {
        if (dominoes.Count == 0)
        {
            if (currentChain.Count > 0 && !matches(currentChain.Last(), currentChain.First()))
                return;

            solutions.Add(new(currentChain));
            return;
        }

        for (int i = 0; i < dominoes.Count(); i++)
        {
            var element = dominoes[i];
            if (currentChain.Count > 0 && !matches(currentChain.Last(), element))
            {
                element = flip(element);
                if (currentChain.Count > 0 && !matches(currentChain.Last(), element))
                    continue;
            }

            dominoes.RemoveAt(i);
            currentChain.Add(element);

            findSolutionViaBacktracking(dominoes, currentChain, solutions);

            dominoes.Insert(i, element);
            currentChain.RemoveAt(currentChain.Count - 1);
        }
    }

    private static bool matches((int, int) dominoeA, (int, int) dominoeB)
    {
        return dominoeA.Item2 == dominoeB.Item1;
    }
    
    private static (int, int) flip((int, int) dominoe)
    {
        return (dominoe.Item2, dominoe.Item1);
    }
}
