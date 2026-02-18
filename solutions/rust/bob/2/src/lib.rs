pub fn reply(message: &str) -> &str {
    let msg = message.trim();
    if msg.is_empty() {
        return "Fine. Be that way!";
    }

    let is_question = msg.ends_with('?');
    let is_yelling = msg.chars().any(|c| c.is_alphabetic()) && msg == msg.to_uppercase();
    let has_letters = msg.chars().any(|c| c.is_alphabetic());

    match (is_yelling, is_question, has_letters) {
        (true, true, _) => "Calm down, I know what I'm doing!",
        (true, false, _) => "Whoa, chill out!",
        (_, true, _) => "Sure.",
        (_, _, false) => "Whatever.",
        _ => "Whatever.",
    }
}
