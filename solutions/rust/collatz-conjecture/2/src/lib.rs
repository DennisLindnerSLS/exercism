pub fn collatz(n: u64) -> Option<u64> {
    if n == 0 {
        return None;
    }

    Some(collatz_recursive(n, 0))
}

fn collatz_recursive(n: u64, steps: u64) -> u64 {
    if n == 1 {
        return steps;
    }

    if steps == u64::MAX {
        panic!("Reached maximum steps without reaching 1");
    }

    if n % 2 == 0 {
        collatz_recursive(n / 2, steps + 1)
    } else {
        collatz_recursive(3 * n + 1, steps + 1)
    }
}