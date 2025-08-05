pub fn series(digits: &str, len: usize) -> Vec<String> {
    let mut result = Vec::new();

    if len == 0 || digits.is_empty() || len > digits.len() {
        return result;
    }

    digits.chars().collect::<Vec<_>>().windows(len).for_each(|window| {
        result.push(window.iter().collect());
    });
    result
}
