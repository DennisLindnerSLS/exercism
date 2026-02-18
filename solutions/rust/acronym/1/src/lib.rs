pub fn abbreviate(phrase: &str) -> String {
    let modified_phrase = split_camel_case(phrase);

    let words = modified_phrase.split(&[' ', '-']);
    words
        .filter(|w| !w.is_empty())
        .flat_map(|w| 
            w.chars()
            .filter(|c| c.is_ascii_alphabetic())
            .next()
            .unwrap()
            .to_uppercase())
        .collect()
}

pub fn split_camel_case(phrase: &str) -> String {
    let mut result = String::new();
    let mut prev_is_lower = false;

    for c in phrase.chars() {
        if prev_is_lower && c.is_uppercase() {
            result.push(' ');
        }
        result.push(c);
        prev_is_lower = c.is_lowercase();
    }

    result
} 
