pub fn annotate(garden: &[&str]) -> Vec<String> {
    let mut result = Vec::new();
    
    for line in 0..garden.len() {
        let line_annotation = annotate_line(garden, line);
        result.push(line_annotation);
    }

    return result;
}

pub fn annotate_line(garden: &[&str], line: usize) -> String {
    // get bytes of the line
    let bytes = garden[line].as_bytes();
    let mut result = String::new();

    for i in 0..bytes.len() {
        if bytes[i] == b'*' {
            result.push('*');
            continue; // Skip the current character if it's a flower
        }
        
        let mut cnt = 0;
        //left
        if i > 0 && bytes[i - 1] == b'*' {
            cnt += 1;
        }
        //right
        if i < bytes.len() - 1 && bytes[i + 1] == b'*' {
            cnt += 1;
        }
        //up
        if line > 0 && garden[line - 1].as_bytes()[i] == b'*' {
            cnt += 1;
        }
        //down
        if line < garden.len() - 1 && garden[line + 1].as_bytes()[i] == b'*' {
            cnt += 1;
        }

        //left top diagonal
        if i > 0 && line > 0 && garden[line - 1].as_bytes()[i - 1] == b'*' {
            cnt += 1;
        }
        //right top diagonal
        if i < bytes.len() - 1 && line > 0 && garden[line - 1].as_bytes()[i + 1] == b'*' {
            cnt += 1;
        }

        //left bottom diagonal
        if i > 0 && line < garden.len() - 1 && garden[line + 1].as_bytes()[i - 1] == b'*' {
            cnt += 1;
        }
        //right bottom diagonal
        if i < bytes.len() - 1 && line < garden.len() - 1 && garden[line + 1].as_bytes()[i + 1] == b'*' {
            cnt += 1;
        }

        if cnt > 0 {
            result.push_str(&cnt.to_string());
        } else {
            result.push(' ');
        }
    }

    return result;
}