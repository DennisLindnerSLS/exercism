use unicode_segmentation::UnicodeSegmentation;

pub fn reverse(input: &str) -> String {
    let reverse_string = input
        .graphemes(true)
        .rev()
        .collect::<String>();
    return reverse_string;
}
