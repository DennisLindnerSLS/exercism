pub fn factors(n: u64) -> Vec<u64> {
    let mut factors = Vec::new();
    let mut candidate = 2;
    let mut n = n;

    while n > 1 {
        if n % candidate == 0 {
            factors.push(candidate);
            n /= candidate;
        } else {
            candidate += 1;
        }
    }

    factors
}
