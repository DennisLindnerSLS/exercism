pub fn collatz(n: u64) -> Option<u64> {
    if n == 0 {
        return None;
    }

    collatz_recursive(n, 0)
}

fn collatz_recursive(n: u64, steps: u64) -> Option<u64> {
    if n == 1 {
        return Some(steps);
    }

    if steps == u64::MAX {
        return None; // Prevent overflow in steps
    }

    if n % 2 == 0 {
        collatz_recursive(n / 2, steps + 1)
    } else {
        collatz_recursive(n.checked_mul(3)?.checked_add(1)?, steps + 1)
    }
}