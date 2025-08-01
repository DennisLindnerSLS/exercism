/// Check a Luhn checksum.
pub fn is_valid(code: &str) -> bool {
    let bytes = code.as_bytes();

    if bytes.is_empty() || 
        bytes.iter()
        .filter(|&& b| b != b' ')
        .any(|&b| b < b'0' || b > b'9') ||
        bytes.iter().filter(|&&b| b != b' ').count() < 2 {
        return false; // invalid code
    }
    
    bytes.iter()
        .filter(|&&b| b != b' ')
        .rev()
        .enumerate()
        .map(|(i, &b)| {
            let mut digit = (b - b'0') as u32;
            if i % 2 == 1 {
                digit = digit * 2;
                if digit > 9 {
                    digit -= 9;
                }
            }
            digit
        })
        .sum::<u32>() % 10 == 0
}
