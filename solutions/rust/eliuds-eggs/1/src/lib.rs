pub fn egg_count(display_value: u32) -> usize {
    let mut count = 0;
    (0..32).for_each(|i| {
        if display_value & (1 << i) != 0 {
            count += 1;
        }
    }
    );
    count
}
