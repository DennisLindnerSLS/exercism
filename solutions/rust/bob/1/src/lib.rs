pub fn reply(message: &str) -> &str {
    match message.trim() {
        "" => "Fine. Be that way!",
        m if m == m.to_uppercase() && m.chars().filter(|c| c.is_alphabetic()).count() > 0 && m.ends_with('?') => "Calm down, I know what I'm doing!",
        m if m.ends_with('?') => "Sure.",
        m if m.chars().filter(|c| c.is_alphabetic()).count() == 0 => "Whatever.",
        m if m == m.to_uppercase() && !m.ends_with('?') => "Whoa, chill out!",
        _ => "Whatever.",
    }
}
