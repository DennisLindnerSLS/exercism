use std::collections::HashSet;

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &'a[&str]) -> HashSet<&'a str> {
    let mut anagrams: HashSet<&'a str> = HashSet::new();

    possible_anagrams.iter().for_each(|anagram| {
        if is_anagram(word, anagram) {
            anagrams.insert(*anagram);
        }
    });
    return anagrams;
}

pub fn is_anagram(word: &str, anagram: &str) -> bool {
    let lower_case_anagram = anagram.to_lowercase();
    let lower_case_word = word.to_lowercase();

    if lower_case_word == lower_case_anagram {
        return false; // An anagram cannot be the same as the original word
    }   

    let mut word_chars: Vec<char> = lower_case_word.chars().collect();
    let mut anagram_chars: Vec<char> = lower_case_anagram.chars().collect();

    word_chars.sort();
    anagram_chars.sort();

    return word_chars == anagram_chars;
}
