pub fn brackets_are_balanced(string: &str) -> bool {
    //remove all characters that are not brackets
    let filtered: String = string.chars().filter(|c| "[](){}".contains(*c)).collect();
    //check if str len is even
    if filtered.len() % 2 != 0 {
        return false;
    }
    //check if brackets are balanced by checking from outside to inside
    let mut stack: Vec<char> = Vec::new();
    for c in filtered.chars() {
        match c {
            '(' | '[' | '{' => stack.push(c),
            ')' => {
                if stack.is_empty() || stack.pop() != Some('(') {
                    return false;
                }
            }
            ']' => {
                if stack.is_empty() || stack.pop() != Some('[') {
                    return false;
                }
            }
            '}' => {
                if stack.is_empty() || stack.pop() != Some('{') {
                    return false;
                }
            }
            _ => {}
        }
    }
    stack.is_empty()
}
