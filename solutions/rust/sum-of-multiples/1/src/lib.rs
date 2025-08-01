pub fn sum_of_multiples(limit: u32, factors: &[u32]) -> u32 {
    factors
        .iter()
        .filter(|&&factor| factor != 0)
        .map(|&factor| {
            (1..limit).filter(move |n| n % factor == 0)
        })
        .flatten()
        .collect::<std::collections::HashSet<_>>()
        .iter()
        .collect::<Vec<&u32>>()
        .iter()
        .map(|&&n| n)
        .sum()
}
