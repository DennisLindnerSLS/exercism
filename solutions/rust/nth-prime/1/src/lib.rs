pub fn nth(n: u32) -> u32 {
    let mut count = 0;
    let upper_bound = get_upper_bound(n);
    let nmbr_of_bytes = (upper_bound as f64 / 16.0).ceil() as usize;
    let mut sieve = vec![0u16; nmbr_of_bytes + 1]; // Each u8 holds 8 bits

    for i in 2..=upper_bound {
        let idx = (i as usize) / 16;
        let bit = 1 << (i % 16);
        if sieve[idx] & bit == 0 {
            // i is prime
            count += 1;
            if count == n + 1{
                return i;
            }
            // Mark multiples of i as non-prime
            if let Some(start) = i.checked_mul(i) {
                for j in (start..=upper_bound).step_by(i as usize) {
                    sieve[j as usize / 16] |= 1 << (j % 16);
                }
            }
        }
    }
    panic!("No prime found for n = {}", n);
}

pub fn get_upper_bound(prime_position: u32) -> u32 {
    let n = prime_position as f64 + 1f64;
    if n < 3f64 {
        return (n + 1f64) as u32;
    }
    (n * (n.ln() + (n.ln()).ln())).ceil() as u32
}
