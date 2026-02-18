enum Line {
    Opening,
    Repition,
    Action,
    Ending,
}

pub fn recite(start_bottles: u32, take_down: u32) -> String {
    let mut sb = String::new();
    let end_bottles = start_bottles - take_down;
    for i in ((end_bottles + 1)..=start_bottles).rev() {
        sb.push_str(&get_line(Line::Opening, i));
        sb.push_str(&get_line(Line::Repition, i));
        sb.push_str(&get_line(Line::Action, i));
        sb.push_str(&get_line(Line::Ending, i - 1));
        if i > 1 {
            sb.push('\n');
        }
    }

    sb
}

pub fn get_number_as_word(num: u32) -> String {
    match num {
        0 => "no".to_string(),
        1 => "one".to_string(),
        2 => "two".to_string(),
        3 => "three".to_string(),
        4 => "four".to_string(),
        5 => "five".to_string(),
        6 => "six".to_string(),
        7 => "seven".to_string(),
        8 => "eight".to_string(),
        9 => "nine".to_string(),
        10 => "ten".to_string(),
        _ => format!("{} bottles", num),
    }
}

fn get_line(line_type: Line, nmbr_of_bottles: u32) -> String {
    match line_type {
        Line::Opening | 
        Line::Repition => format!(
            "{} green bottle{} hanging on the wall,\n",
            get_number_as_word(nmbr_of_bottles).to_capitalized(),
            if nmbr_of_bottles != 1 { "s" } else { "" }
        ),
        Line::Action => format!(
            "And if one green bottle should accidentally fall,\n"
        ),
        Line::Ending => format!(
            "There'll be {} green bottle{} hanging on the wall.\n",
            get_number_as_word(nmbr_of_bottles),
            if nmbr_of_bottles != 1 { "s" } else { "" }
        ),
    }
}

/// Capitalizes only the first letter of a string.
pub trait ToCapitalized {
    fn to_capitalized(&self) -> String;
}

impl ToCapitalized for String {
    fn to_capitalized(&self) -> String {
        let mut chars = self.chars();
        match chars.next() {
            Some(first) => first.to_uppercase().collect::<String>() + chars.as_str(),
            None => String::new(),
        }
    }
}